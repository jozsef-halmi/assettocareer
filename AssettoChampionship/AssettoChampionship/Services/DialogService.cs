using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace AssettoChampionship.Services
{
    public static class DialogService
    {
        public static async Task<MessageDialogResult> ShowMessage(
            string message, MessageDialogStyle dialogStyle)
        {
            var metroWindow = (System.Windows.Application.Current.MainWindow as MetroWindow);
            metroWindow.MetroDialogOptions.ColorScheme = MetroDialogColorScheme.Accented;
            return await metroWindow.ShowMessageAsync(
                "MY TITLE", message, dialogStyle, metroWindow.MetroDialogOptions);
        }

        public static Task<MessageDialogResult> ShowMessageBox(string title, string message, MessageDialogStyle style = MessageDialogStyle.Affirmative, MetroDialogSettings settings = null)
        {
            System.Windows.Application.Current.Dispatcher.Invoke(() =>
            {
                var firstMetroWindow = System.Windows.Application.Current.Windows.OfType<MetroWindow>().First();
                return firstMetroWindow.ShowMessageAsync(title, message, style, settings);
            });
            return null;
        }
    }
}
