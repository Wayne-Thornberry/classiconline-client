using CitizenFX.Core;
using Proline.ClassicOnline.CWorldObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Proline.ClassicOnline.SClassic
{
    public class MarkerTest
    {

        public async Task Execute(object[] args, CancellationToken token)
        {
            // Dupe protection
            if (CCoreSystem.CCoreSystemAPI.GetInstanceCountOfScript("MarkerTest") > 1)
                return;

            var handle = WorldAPI.CreateMarker(Game.PlayerPed.Position);

            while (!token.IsCancellationRequested)
            {
                WorldAPI.DrawMarker(handle);
                if(WorldAPI.IsInMarker(handle, Game.PlayerPed.Handle))
                {
                    break;
                }
                await BaseScript.Delay(0);
            }
            WorldAPI.DeleteMarker(handle);
        }
    }
}
