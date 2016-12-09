using Assetto.Common.Data;
using Assetto.Common.Framework;
using Assetto.Common.Interfaces.Manager;
using AssettoChampionship.Servies;
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

namespace AssettoChampionship.ViewModels
{
    public class ShellViewModel : Conductor<object>
        , IHandle<ChangePageMessage>
        , IHandle<OpenDialogMessage>
        , IHandle<UpdateDialogMessage>
    {
        public IWindowManager WindowManager;
        public IUnityContainer Container { get; set; }
        public IEventAggregator EventAggregator { get; private set; }

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


        public ShellViewModel(
            IWindowManager windowManager
            , IEventAggregator eventAggregator
            , IUnityContainer container)
        {
            this.WindowManager = windowManager;
            this.Container = container;
            this.EventAggregator = eventAggregator;

            this.EventAggregator.Subscribe(this); //You should Unsubscribe when message handling is no longer needed
            this.BackStack = new Stack<object>();
            ShowMainPage();
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
                default:
                    break;
            }
        }

        public void Handle(OpenDialogMessage message)
        {
            //WindowManager.ShowDialog(Container.Resolve<LoadingViewModel>(), null,null);
            var loadingVM = Container.Resolve<LoadingViewModel>();
            ActivateItem(loadingVM);
            loadingVM.Text = message.Data.Text;


        }

        public void Handle(UpdateDialogMessage message)
        {
            var loadingVM = Container.Resolve<LoadingViewModel>();
            loadingVM.Text = message.Data.Text;
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
          
        }

        public void GoBack()
        {
            ActivateItem(this._backStack.Pop());
            this.BackStack = _backStack;
        }

        public bool CanGoBack
        {
            get { return this.BackStack != null && this.BackStack.Count > 1; }
        }

        public void ShowMainPage()
        {
            OpenPage(Container.Resolve<MainViewModel>());
            //ActivateItem(Container.Resolve<MainViewModel>());
        }

        public void ShowSeriesPage(ChangePageParameters parameters) {
            //ActivateItem(Container.Resolve<SeriesViewModel>());
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

        //public void ShowPageTwo()
        //{
        //    ActivateItem(new PageTwoViewModel());
        //}
    }
}