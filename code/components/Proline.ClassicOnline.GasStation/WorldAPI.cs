using CitizenFX.Core;
using Newtonsoft.Json;
using Proline.ClassicOnline.CDebugActions;
using Proline.ClassicOnline.CWorldObjects.Data;
using Proline.ClassicOnline.CWorldObjects.Data.Ownership;
using Proline.ClassicOnline.CWorldObjects.Internal;
using Proline.Resource.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proline.ClassicOnline.CWorldObjects
{
    public static partial class WorldAPI
    {
        public static void PlaceVehicleInGarageSlot(string propertyId, int index, Entity vehicle)
        {
            try
            {
                var garage = GetPropertyGarage(propertyId);
                var layout = GetPropertyGarageLayout(propertyId);
                var limit = GetPropertyGarageLimit(propertyId);
                if (index > limit)
                    return;
                var resourceData1 = ResourceFile.Load($"data/world/garages/{garage}.json");
                var garageInterior = JsonConvert.DeserializeObject<BuildingInteriorLink>(resourceData1.Load());

                var resourceData2 = ResourceFile.Load($"data/world/interiors/{garageInterior.Interior}.json");
                var interior = JsonConvert.DeserializeObject<InteriorMetadata>(resourceData2.Load());


                var resourceData3 = ResourceFile.Load($"data/world/garages/layouts/{layout}.json");
                var garageLayout = JsonConvert.DeserializeObject<GarageLayout>(resourceData3.Load());


                CDebugActionsAPI.LogDebug(garageLayout.VehicleSlots.Count());
                CDebugActionsAPI.LogDebug(index);
                var slot = garageLayout.VehicleSlots[index];
                if (slot == null)
                    throw new Exception($"Slot not found");
                vehicle.Position = slot.Position;
                vehicle.Heading = slot.Heading;
            }
            catch (Exception e)
            {
                CDebugActionsAPI.LogError(e);
            }
        }

        public static int GetPropertyGarageLimit(string propertyId)
        { 
            if (string.IsNullOrEmpty(propertyId))
                return 0;
            var pm = PropertyManager.GetInstance();
            var property = pm.GetProperty(propertyId);
            return property.VehicleCap;
        }

        public static void DrawMarker()
        {

        }

        public static Vector3 GetBuildingWorldPos(object neariestBulding)
        {
            throw new NotImplementedException();
        }
    }
}
