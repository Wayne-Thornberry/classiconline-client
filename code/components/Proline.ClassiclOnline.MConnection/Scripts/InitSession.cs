using CitizenFX.Core;
using Proline.ClassicOnline.CNetConnection.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proline.ClassicOnline.CNetConnection.Scripts
{
    public class InitSession
    {
        public async Task Execute()
        {
            PlayerJoinedEvent.InvokeEvent(Game.Player.Name);
        }
    }
}
