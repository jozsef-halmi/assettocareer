using Assetto.Common.Data;
using Assetto.Common.DTO;
using Assetto.Common.Framework;
using Assetto.Common.Interfaces.Manager;
using Caliburn.Micro;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AssettoChampionship.ViewModels
{
    public class NextSessionViewModel : Screen
    {
        // Managers
        public IEventAggregator EventAggregator { get; set; }
        public IEventManager EventManager { get; set; }

        public NextSessionViewModel(
            IEventAggregator eventAggregator
            , IEventManager eventManager)
        {
            this.EventAggregator = eventAggregator;
            this.EventManager = eventManager;


        }

        protected override void OnActivate()
        {
            base.OnActivate();
        }
    }
}
