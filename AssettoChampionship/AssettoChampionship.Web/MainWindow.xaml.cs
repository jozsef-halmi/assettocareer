using Microsoft.AspNet.SignalR.Client;
using System;
using System.Windows;
using System.Windows.Media;

namespace AssettoChampionship.Web
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
     
        HubConnection hubConnection;
        IHubProxy mainHubProxy;
        public MainWindow()
        {
            InitializeComponent();

            hubConnection = new HubConnection(App.baseWebSignalRAddress);
            mainHubProxy = hubConnection.CreateHubProxy("MainHub");
            mainHubProxy.On<string, string>("addMessage", (invoker, data) =>
            {
                //if (invoker == "htmlbutton" && data == "blue")
                //    Dispatcher.InvokeAsync(() => LoadContent.Background = Brushes.Blue);
            });
            hubConnection.Start();
        }

        private void LoadContent_Click(object sender, RoutedEventArgs e)
        {
            mainHubProxy.Invoke("Send", new object[] { "button", "getdata" });
        }
    }
}
