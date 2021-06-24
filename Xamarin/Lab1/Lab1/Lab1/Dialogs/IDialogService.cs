using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Dialogs
{
    interface IDialogService
    {
        Task<bool> ShowMessage(string message, string title, string buttonConfirmText, string buttonCancelText, Action<bool> afterHideCallback);
    }
}
