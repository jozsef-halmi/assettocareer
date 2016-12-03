using Assetto.Common.Framework;
using Assetto.Common.Interfaces.Manager;
using Caliburn.Micro;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace AssettoChampionship.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<ChangePageMessage>
    {
        //public IWindowManager WindowManager;
        public IUnityContainer Container { get; set; }
        public IEventAggregator EventAggregator { get; private set; }

        public ShellViewModel(
            //IWindowManager windowManager
             IEventAggregator eventAggregator
            , IUnityContainer container)
        {
            //this.WindowManager = windowManager;
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
                    ShowSeriesPage();
                    break;
                default:
                    break;
            }
        }

        public void ShowMainPage()
        {
            ActivateItem(Container.Resolve<MainViewModel>());
        }

        public void ShowSeriesPage() {
            ActivateItem(Container.Resolve<SeriesViewModel>());
        }

        //public void ShowPageTwo()
        //{
        //    ActivateItem(new PageTwoViewModel());
        //}
    }
}