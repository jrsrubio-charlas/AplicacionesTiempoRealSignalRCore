﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRDemo1Azure.Hubs;

namespace SignalRDemo1Azure.Controllers
{
    public class HomeController : Controller
    {
        IHubContext<MessageHub> context;
        public HomeController(IHubContext<MessageHub> hub)
        {
            context = hub;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Message()
        {
            return View();
        }

        public void AddMessage(string message)
        {
            context.Clients.All.SendAsync("new-message", message);         
        }

        
    }
}
