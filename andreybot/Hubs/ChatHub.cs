using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.SignalR;
using andreybot.Models;

namespace andreybot.Hubs
{
    public class ChatHub : Hub
    {
        static List<User> Users = new List<User>();
        public BotBox botBox = new BotBox();
        // Отправка сообщений
        public void Send(string name, string message, string response)
        {
            var result = botBox.andreybot.Chat(Convert.ToString(message));
            response = string.Format("{0}\n{1}", result.BotMessage, response);
            Clients.All.addMessage(name, message, response);
            
           
        }

        // Подключение нового пользователя
        public void Connect(string userName)
        {
            var id = Context.ConnectionId;


            if (Users.Count(x => x.ConnectionId == id) == 0)
            {
                Users.Add(new User { ConnectionId = id, Name = userName });

                // Посылаем сообщение текущему пользователю
                Clients.Caller.onConnected(id, userName, Users);

                // Посылаем сообщение всем пользователям, кроме текущего
                Clients.AllExcept(id).onNewUserConnected(id, userName);
            }
        }

        // Отключение пользователя
        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            var item = Users.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
            if (item != null)
            {
                Users.Remove(item);
                var id = Context.ConnectionId;
                Clients.All.onUserDisconnected(id, item.Name);
            }

            return base.OnDisconnected(stopCalled);
        }
    }
}