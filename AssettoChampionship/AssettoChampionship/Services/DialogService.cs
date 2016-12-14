using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
