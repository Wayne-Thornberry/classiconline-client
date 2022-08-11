using CitizenFX.Core.Native;
using Newtonsoft.Json;
using Proline.ClassicOnline.CDebugActions;
using Proline.ClassicOnline.CGameLogic;

using Proline.ClassicOnline.CGameLogic.Internal;
using Proline.ClassicOnline.CPoolObjects;
using Proline.Resource.IO;
using System;

namespace Proline.ClassicOnline.Engine.Parts
{

    public static partial class EngineAPI
    {

       public static int[] GetAllExistingPoolObjects()
        {
            var api = new CPoolObjectsAPI();
            return api.GetAllExistingPoolObjects();
        }
    }
}
