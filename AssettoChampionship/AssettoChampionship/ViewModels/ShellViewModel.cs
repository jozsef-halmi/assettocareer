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

        public ShellViewModel(
            IWindowManager windowManager
            , IEventAggregator eventAggregator
            , IUnityContainer container)
        {
            this.WindowManager = windowManager;
            this.Container = container;
            this.EventAggregator = eventAggregator;

            this.EventAggregator.Subscribe(this); //You should Unsubscribe when message handling is no longer needed

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

        public void ShowMainPage()
        {
            ActivateItem(Container.Resolve<MainViewModel>());
        }

        public void ShowSeriesPage(ChangePageParameters parameters) {
            ActivateItem(Container.Resolve<SeriesViewModel>());
        }

        public void ShowEventsPage(ChangePageParameters parameters)
        {
            var eventsVM = Container.Resolve<EventsViewModel>();
            ActivateItem(eventsVM);
            eventsVM.SetSeries(parameters.Parameter as SeriesData);
        }

        public void ShowSessionsPage(ChangePageParameters parameters)
        {
            ActivateItem(Container.Resolve<SessionsViewModel>());
        }

        //public void ShowPageTwo()
        //{
        //    ActivateItem(new PageTwoViewModel());
        //}
    }
}