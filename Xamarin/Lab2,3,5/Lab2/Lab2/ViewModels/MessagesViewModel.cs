using Lab2.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Lab2.ViewModels
{
    class MessagesViewModel : BaseViewModel
    {
        private readonly INavigation navigation;

        public string Message { get; set; }

        public Command NextCommand { get; set; }

        public Command Clear { get; set; }

        public MessagesViewModel(INavigation navigation)
        {
            Title = "Сообщения";
            this.navigation = navigation;
            NextCommand = new Command(async () => await ExecuteNextCommand());
            Clear = new Command(() => Message = "");
            MessagingCenter.Subscribe<Page>(
                    this,
                    "LabelChange",
                    (sender) => 
                    {
                        Message = "Привет";
                        OnPropertyChanged("Message");
                    });
        }

        async Task ExecuteNextCommand()
        {
            await navigation.PushAsync(new MessagesSenderPage());
        }




    }
}
