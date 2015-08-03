using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Messages.Events;
using Microsoft.AspNet.SignalR;

namespace UI.Handlers
{
    public static class ClientPossiblyStolenHandler 
    {
        public static void Handle(ClientPossiblyStolen message)
        {
            var hub = GlobalHost.ConnectionManager.GetHubContext<NonPersistentHub>();
            hub.Clients.All.clientPossiblyStolen(message);
        }
    }
}