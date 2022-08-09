using CitizenFX.Core;
using Newtonsoft.Json;
using Proline.ClassicOnline.CDebugActions;
using Proline.ClassicOnline.CCoreSystem.Events;
using Proline.ClassicOnline.CCoreSystem.Internal;
using Proline.Resource.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proline.ClassicOnline.CScriptAreas.Entity;
using Proline.ClassicOnline.CScriptAreas.Data;

namespace Proline.ClassicOnline.CScriptAreas.Scripts
{
    public class InitCore
    {

        public async Task Execute()
        {
            var instance = ScriptPositionManager.GetInstance();
            var data = ResourceFile.Load("data/brain/scriptpositions.json");
            CDebugActionsAPI.LogDebug(data);
            var scriptPosition = JsonConvert.DeserializeObject<ScriptPositions>(data.Load());
            instance.AddScriptPositionPairs(scriptPosition.scriptPositionPairs);
            PosBlacklist.Create();
        }
    }
}
