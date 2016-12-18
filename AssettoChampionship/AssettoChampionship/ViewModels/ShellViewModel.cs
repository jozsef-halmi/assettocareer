using Assetto.Common.Data;
using Assetto.Common.Framework;
using Assetto.Common.Interfaces.Manager;
using AssettoChampionship.Services;
using AssettoChampionship.ViewModels.Dialog;
using AssettoChampionship.Views;
using Caliburn.Micro;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Threading;
using Assetto.Common.Interfaces.Service;

namespace AssettoChampionship.ViewModels
{
    public class ShellViewModel : Conductor<object>
        , IHandle<ChangePageMessage>
        , IHandle<OpenDialogMessage>
        , IHandle<UpdateDialogMessage>
        , IHandle<NotificationMessage>
        , IHandle<GoBackMessage>

    {
        public IWindowManager WindowManager;
        public IUnityContainer Container { get; set; }
        public IEventAggregator EventAggregator { get; private set; }
        public IConfigManager ConfigManager { get; set; }
        public ILogService LogService { get; set; }
        public IConfigService ConfigService { get; set; }



        private string _windowTitle;
        public string WindowTitle
        {
            get { return _windowTitle; }
            set
            {
                _windowTitle = value + " Version " + System.Reflection.Assembly.GetExecutingAssembly()
                                           .GetName()
                                           .Version
                                           .ToString();

                NotifyOfPropertyChange(() => WindowTitle);
                //Insert your property change code here (not sure of the caliburn micro version)
            }
        }

        private string _activeViewModel;
        public string ActiveViewModel
        {
            get
            {
                return _activeViewModel;
            }
            set
            {
                _activeViewModel = value;
                NotifyOfPropertyChange(() => ActiveViewModel);
                NotifyOfPropertyChange(() => CanOpenSettings);
                NotifyOfPropertyChange(() => CanOpenAbout);
            }
        }

        private Stack<object> _backStack;

        public Stack<object> BackStack {
            get { return _backStack; }
            set
            {
                _backStack = value;
                NotifyOfPropertyChange(() => BackStack);
                NotifyOfPropertyChange(() => CanGoBack);
            }
        }

        private string _pageTitle;
        public string PageTitle { get
            {
                return _pageTitle;
            }
            set
            {
                _pageTitle = value;
                NotifyOfPropertyChange(() => PageTitle);

            }
        }

        private string _notification;
        public string Notification
        {
            get
            {
                return _notification;
            }
            set
            {
                _notification = value;
                NotifyOfPropertyChange(() => Notification);

            }
        }

        public ShellViewModel(
            IWindowManager windowManager
            , IEventAggregator eventAggregator
            , IUnityContainer container
            , IConfigManager configManager
            , ILogService logService
            , IConfigService configService)
        {
            this.WindowManager = windowManager;
            this.Container = container;
            this.EventAggregator = eventAggregator;
            this.ConfigManager = configManager;
            this.LogService = logService;
            this.ConfigService = configService;

            this.EventAggregator.Subscribe(this); //You should Unsubscribe when message handling is no longer needed
            this.BackStack = new Stack<object>();
            ShowMainPage();
            this.PageTitle = this.WindowTitle = "Assetto Corsa 3rd party career mode";
            //ConfigManager.GetSettings();
            LogService.Log("Startup");
        }


        public void Handle(ChangePageMessage message)
        {

            switch (message.ViewModelType.Name)
            {
                case "SeriesViewModel":
                    ShowSeriesPage(message.Data);
                    break;
                case "EventsViewModel":
                    ShowEventsPage(message.Data);
                    break;
                case "SessionsViewModel":
                    ShowSessionsPage(message.Data);
                    break;
                case "ResultsViewModel":
                    ShowResultsPage(message.Data);
                    break;
                case "VideoViewModel":
                    ShowVideoPage(message.Data);
                    break;
                case "AboutViewModel":
                    ShowAboutPage();
                    break;
                default:
                    break;
            }
        }

        public void Handle(OpenDialogMessage message)
        {
            //WindowManager.ShowDialog(Container.Resolve<LoadingViewModel>(), null,null);
            var loadingVM = Container.Resolve<LoadingViewModel>();
            ActivateItem(loadingVM);
            loadingVM.UpdateData(message.Data.Text, message.Data.ImageUrl);
            //loadingVM.Text = message.Data.Text;


        }

        public void Handle(UpdateDialogMessage message)
        {
            var loadingVM = Container.Resolve<LoadingViewModel>();
            //loadingVM.Text = message.Data.Text;
            loadingVM.UpdateData(message.Data.Text, message.Data.ImageUrl);

            //var loadingVM = Container.Resolve<LoadingViewModel>();
            //if (loadingVM.IsOpen)
            //{
            //    loadingVM.UpdateData(message.Data);

            //}
        }

        private void OpenPage(object screen)
        {
            this._backStack.Push(this.ActiveItem);
            this.BackStack = _backStack;
            ActivateItem(screen);
            ActiveViewModel = screen.GetType().ToString();
        }

        public void GoBack()
        {
            var vm = this._backStack.Pop();
            ActivateItem(vm);
            this.BackStack = _backStack;
            ActiveViewModel = vm.GetType().ToString();
        }


        public bool CanGoBack
        {
            get { return this.BackStack != null && this.BackStack.Count > 1; }
        }

        public void OpenSettings()
        {
            OpenPage(Container.Resolve<SettingsViewModel>());
        }


        public bool CanOpenSettings
        {
            get {
                return ActiveViewModel != Container.Resolve<SettingsViewModel>().GetType().ToString();
            }
        }

        public void OpenAbout()
        {
            ShowAboutPage();
        }

        public bool CanOpenAbout
        {
            get
            {
                return ActiveViewModel != Container.Resolve<AboutViewModel>().GetType().ToString();
            }
        }

        public void ShowMainPage()
        {
            OpenPage(Container.Resolve<MainViewModel>());
        }

        public void ShowSeriesPage(ChangePageParameters parameters) {
            OpenPage(Container.Resolve<SeriesViewModel>());

        }

        public void ShowEventsPage(ChangePageParameters parameters)
        {
            var eventsVM = Container.Resolve<EventsViewModel>();
            eventsVM.SetSeries(parameters.SelectedSeriesId);
            OpenPage(eventsVM);

        }

        public void ShowSessionsPage(ChangePageParameters parameters)
        {
            var sessionsVM = Container.Resolve<SessionsViewModel>();
            sessionsVM.SetEvent(parameters.SelectedSeriesId, parameters.SelectedEventId);
            OpenPage(sessionsVM);

        }

        public void ShowResultsPage(ChangePageParameters parameters)
        {
            var resultsVM = Container.Resolve<ResultsViewModel>();
            ActivateItem(resultsVM);
            resultsVM.SetResults(parameters.ACExeTerminatedDto);
        }

        public void ShowVideoPage(ChangePageParameters parameters)
        {
            var videoVM = Container.Resolve<VideoViewModel>();
            OpenPage(videoVM);
            videoVM.SetVideo(parameters.Parameter as string);
        }

        public void ShowAboutPage()
        {
            var aboutVM = Container.Resolve<AboutViewModel>();
            OpenPage(aboutVM);
        }


        public void ShowSettings()
        {
            var settingsVM = Container.Resolve<SettingsViewModel>();
            ActivateItem(settingsVM);
        }

        //public void ShowPageTwo()
        //{
        //    ActivateItem(new PageTwoViewModel());
        //}

        public async Task ShowMessageAndHide(string message)
        {
            Notification = message;
            await Task.Delay(5000);
            Notification = string.Empty;
        }

        public async void ShowNotification(string msg) {
            await ShowMessageAndHide(msg);
        }

        public void Handle(NotificationMessage data)
        {
            ShowNotification(data.Message);
        }

        public void Handle(GoBackMessage message)
        {
            this.GoBack();
        }

        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            if (!ConfigService.IsSettingsAvailable())
            {
                DialogService.ShowMessageBox("Welcome! ", "It looks like you haven't set your Assetto Corsa install location. Please take the time and do that!");
                OpenSettings();
            }
            ConfigManager.GetSettings();


        }


    }
}