using Proline.ClassicOnline.Common.Data;
using Proline.ClassicOnline.CScriptObjs;
using Proline.ClassicOnline.CScriptObjs.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proline.ClassicOnline.Engine.Parts
{
    public static partial class EngineAPI
    {
        public static int[] GetEntityHandlesByTypes(EntityType type)
        {
            var api = new CScriptBrainAPI();
            return api.GetEntityHandlesByTypes(type);
        }
        public static CitizenFX.Core.Entity GetNeariestEntity(EntityType type)
        { 
            var api = new CScriptBrainAPI();
            return api.GetNeariestEntity(type);
        }
    }
}
