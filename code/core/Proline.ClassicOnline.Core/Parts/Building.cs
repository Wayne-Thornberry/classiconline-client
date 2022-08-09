using CitizenFX.Core;
using CitizenFX.Core.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proline.ClassicOnline.Engine.Parts
{
    public static partial class EngineAPI
    {
        public static string GetNearestBuilding()
        { 
            return default;
        }

        public static Vector3 GetBuildingPosition(string buildingId)
        {
            return default; 
        }
        public static Vector3 GetBuildingEntrance(string buildingId, int entranceId = 0)
        { 
            return default;
        }

        public static int GetNumOfBuldingEntrances(string buildingId)
        {
            return default; 
        }


        public static string GetBuildingEntranceString(string buildingId, int entranceId = 0)
        {
            return default; 
        }


        public static string GetNearestBuildingEntrance(string building)
        {
            return default; 
        }
        public static Vector3 GetBuildingWorldPos(string buildingId)
        {
            return default;
        }

        public static string EnterBuilding(string buildingId, string buildingEntrance)
        {
            return default;
        }
        public static Vector3 ExitBuilding(string buildingId, string accessPoint, int type = 0)
        {
            return default;
        }
    }
}
