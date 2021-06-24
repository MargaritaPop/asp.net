using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Lab1.Dialogs
{
    class DialogService : IDialogService
    {
        public async Task<bool> ShowMessage(string message, string title, string buttonConfirmText, string buttonCancelText, Action<bool> afterHideCallback)
        {
            var result = await Application.Current.MainPage.DisplayAlert(
                            title,
                            message,
                            buttonConfirmText,
                            buttonCancelText);

            afterHideCallback?.Invoke(result);
            return result;
        }
    }
}
