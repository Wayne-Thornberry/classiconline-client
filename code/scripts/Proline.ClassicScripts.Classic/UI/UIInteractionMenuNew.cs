using System.Threading;
using System.Threading.Tasks;
using CitizenFX.Core;
using Proline.ClassicOnline.CCoreSystem; 
namespace Proline.ClassicOnline.SClassic.UI
{
    public class UIInteractionMenuNew
    {
        public UIInteractionMenuNew()
        {
        }

        public async Task Execute(object[] args, CancellationToken token)
        {
            // Dupe protection
            if (CCoreSystem.CCoreSystemAPI.GetInstanceCountOfScript("ScriptTemplate") > 1)
                return;


            while (!token.IsCancellationRequested)
            {

                await BaseScript.Delay(0);
            }
        }
    }
}
