using CitizenFX.Core;
using CitizenFX.Core.Native;
using Newtonsoft.Json;
using Proline.ClassicOnline.CDebugActions;
using Proline.ClassicOnline.CWorldObjects;
using Proline.ClassicOnline.CWorldObjects.Data.Ownership;
using Proline.Resource.IO;
using System;
using System.Linq;

namespace Proline.ClassicOnline.Engine.Parts
{
    public static partial class EngineAPI
    {
        public static Vector3 EnterInterior(string interiorId, string entranceId)
        {
            var api = new CWorldObjectsAPI();
            return api.EnterInterior(interiorId, entranceId); 
        }

        public static string ExitInterior(string interiorId, string exitId)
        {

            var api = new CWorldObjectsAPI();
            return api.ExitInterior(interiorId, exitId);

        }


        public static string GetNearestInterior()
        {
            var api = new CWorldObjectsAPI(); 
            return api.GetNearestInterior();

        }

        public static Vector3 GetBuildingInterior(string buildingId)
        { 
            var api = new CWorldObjectsAPI();
            return api.GetBuildingInterior(buildingId);
        }
        public static string GetNearestInteriorExit(string interiorId = null)
        {

            var api = new CWorldObjectsAPI();
            return api.GetNearestInteriorExit(interiorId);

        }

    }
}
