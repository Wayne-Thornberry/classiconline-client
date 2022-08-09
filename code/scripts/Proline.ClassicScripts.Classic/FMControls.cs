using CitizenFX.Core;
using Proline.ClassicOnline.CCoreSystem;
using System.Threading;
using System.Threading.Tasks;

namespace Proline.ClassicOnline.SClassic
{
    public class FMControls
    {
        public FMControls()
        {
        }

        public async Task Execute(object[] args, CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                if (Game.IsControlJustReleased(0, Control.InteractionMenu))
                {
                    CCoreSystemAPI.StartNewScript("UIInteractionMenu");
                }
                await BaseScript.Delay(0);
            }
        }
    }
}
