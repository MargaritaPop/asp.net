using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace ASPLabs5.Hubs
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {

            Clients     // Доступ к списку подключенных клиентов через свойство Clients (Microsoft.AspNet.SignalR.Hub.Clients)
                   .All // Выбрать всех подключенных клиентов
                   .addNewMessage(name, message); // Новое сообщение отобразить у всех.
        }
    }
}