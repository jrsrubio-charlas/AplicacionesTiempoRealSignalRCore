using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace SignalRDemo1.Hubs
{
    public class MessageHub : Hub
    {
        //Cuando un usuario se conecta
        //public override Task OnConnectedAsync()
        //{            
        //    return Clients.All.SendAsync("new-message", "     Nuevo cliente conectado");
        //}

        //Cuando un usuario se desconecta
        //public override Task OnDisconnectedAsync(Exception exception)
        //{            
        //    return Clients.All.SendAsync("new-message", "     Un cliente se ha desconectado");
        //}

        public Task BroadcastMessage(string message)
        {
            return Clients.All.SendAsync("new-message", message);
        }
    }
}
