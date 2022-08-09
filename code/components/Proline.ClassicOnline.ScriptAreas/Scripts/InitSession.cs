using CitizenFX.Core; 
using Proline.ClassicOnline.CCoreSystem.Events;
using Proline.ClassicOnline.CCoreSystem.Internal; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proline.ClassicOnline.CScriptAreas.Tasks;

namespace Proline.ClassicOnline.CScriptAreas.Scripts
{
    public class InitSession
    {
        public async Task Execute()
        {
            var gc = new ProcessScriptAreas();
            while (true)
            {
                var task = Task.Factory.StartNew(gc.Execute);
                await BaseScript.Delay(1000);
            }
        }
    }
}
