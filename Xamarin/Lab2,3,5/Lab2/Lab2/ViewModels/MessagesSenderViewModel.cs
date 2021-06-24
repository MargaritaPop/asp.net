using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Lab2.ViewModels
{
    class MessagesSenderViewModel : BaseViewModel
    {

        private readonly INavigation navigation;

        public Command BackCommand { get; set; }


        public MessagesSenderViewModel(INavigation navigation)
        {
            Title = "Сообщения";
            this.navigation = navigation;
            BackCommand = new Command<Page>(async (page) => await ExecuteBackCommand(page));
            
        }

        async Task ExecuteBackCommand(Page page)
        {
            MessagingCenter.Send(page, "LabelChange");
            await navigation.PopAsync();
        }


    }
}
