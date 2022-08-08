using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;
using Proline.ClassicOnline.CNativeEvents.Events;

namespace Proline.ClassicOnline.CNativeEvents.Scripts
{
    public class InitCore
    {

        public async Task Execute()
        {
            GameEventTriggered.SubscribeEvent();
        }
    }
}