using CitizenFX.Core;
using Proline.ClassicOnline.CWorldObjects;
using Proline.ClassicOnline.Engine.Parts;
using System.Threading;
using System.Threading.Tasks;

namespace Proline.ClassicOnline.SClassic
{
    public class MarkerTest
    {

        public async Task Execute(object[] args, CancellationToken token)
        {
            // Dupe protection
            if (EngineAPI.GetInstanceCountOfScript("MarkerTest") > 1)
                return;

            var handle = CWorldObjects.CWorldObjects.CreateMarker(Game.PlayerPed.Position);

            while (!token.IsCancellationRequested)
            {
                CWorldObjects.CWorldObjects.DrawMarker(handle);
                if (CWorldObjects.CWorldObjects.IsInMarker(handle, Game.PlayerPed.Handle))
                {
                    break;
                }
                await BaseScript.Delay(0);
            }
            CWorldObjects.CWorldObjects.DeleteMarker(handle);
        }
    }
}
