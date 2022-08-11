using CitizenFX.Core;
using Newtonsoft.Json;
using Proline.ClassicOnline.CDebugActions;
using Proline.ClassicOnline.CWorldObjects.Data.Ownership;
using Proline.ClassicOnline.CWorldObjects.Internal;
using Proline.Resource.IO;
using System;

namespace Proline.ClassicOnline.CWorldObjects
{
    public static partial class WorldAPI
    {
        // Properties -> Linkage (Building/Garage) -> Building & Interior -> Entrances/Exit & Points
        // apt_dpheights_he_01 apt_dpheights_01 apt_dpheights_ped_frt_ent_01
        // apt_dpheights_he_01 gar_dpheights_01 gar_dpheights_veh_frt_ent_01
        public static Vector3 EnterProperty(string propertyId, string propertyPart, string entranceId)
        {
            var api = new CDebugActionsAPI();
            try
            {
                if (string.IsNullOrEmpty(propertyId))
                    return Vector3.One;
                //var pm = PropertyManager.GetInstance();
                //var property = pm.GetProperty(propertyId);
                //var type = property.Type;
                //var garageString = property.Garage;
                //var aptString = property.Apartment; 

                //ResourceFile resourceData1 = null;
                //ResourceFile resourceData2 = null; 

                //var folderName = GetPropertyPartType(propertyPart);
                //api.LogDebug(folderName);
                //api.LogDebug(propertyPart);

                //// Load the link file
                //resourceData1 = ResourceFile.Load($"data/world/{folderName}/{propertyPart}.json");
                //var buildingInteriorLink = JsonConvert.DeserializeObject<BuildingInteriorLink>(resourceData1.Load()); 
                //var targetEntryPointString = buildingInteriorLink.ExteriorEntrances[entranceId];

                //api.LogDebug(folderName);
                //api.LogDebug(buildingInteriorLink.Interior);
                //// Load interior file
                //resourceData2 = ResourceFile.Load($"data/world/interiors/{buildingInteriorLink.Interior}.json");
                //var interiorMetadata = JsonConvert.DeserializeObject<InteriorMetadata>(resourceData2.Load()); 
                //var targetEntryPoint = interiorMetadata.EntrancePoints.FirstOrDefault(e => e.Id.Equals(targetEntryPointString));
                return Vector3.One;

            }
            catch (Exception e)
            {
                api.LogError(e);
            }
            return Vector3.One;
        }



        public static string GetPropertyExit(string propertyPart, string functionType, string neariestExit)
        {
            var api = new CDebugActionsAPI();
            try
            {
                var resourceData1 = ResourceFile.Load($"data/world/{functionType}/{propertyPart}.json");
                var buildingInteriorLink = JsonConvert.DeserializeObject<BuildingInteriorLink>(resourceData1.Load());
                var targetEntryPointString = buildingInteriorLink.InteriorExits[neariestExit];
                return targetEntryPointString;
            }
            catch (Exception e)
            {
                api.LogError(e);
            }
            return "";
        }

        public static string GetPropertyEntry(string propertyPart, string functionType, string entranceString)
        {
            var api = new CDebugActionsAPI();
            try
            {
                var resourceData1 = ResourceFile.Load($"data/world/{functionType}/{propertyPart}.json");
                var buildingInteriorLink = JsonConvert.DeserializeObject<BuildingInteriorLink>(resourceData1.Load());
                var targetEntryPointString = buildingInteriorLink.ExteriorEntrances[entranceString];
                return targetEntryPointString;
            }
            catch (Exception e)
            {
                api.LogError(e);
            }
            return "";

        }

        public static string GetPropertyApartment(string propertyId)
        {
            var api = new CDebugActionsAPI();
            try
            {
                if (string.IsNullOrEmpty(propertyId))
                    return "";
                var pm = PropertyManager.GetInstance();
                var property = pm.GetProperty(propertyId);
                return property.Apartment;
            }
            catch (Exception e)
            {
                api.LogError(e);
            }
            return "";

        }

        public static string GetPropertyGarage(string propertyId)
        {
            var api = new CDebugActionsAPI();
            try
            {
                if (string.IsNullOrEmpty(propertyId))
                    return "";
                var pm = PropertyManager.GetInstance();
                var property = pm.GetProperty(propertyId);
                return property.Garage;
            }
            catch (Exception e)
            {
                api.LogError(e);
            }
            return "";

        }

        public static string GetPropertyGarageLayout(string propertyId)
        {
            var api = new CDebugActionsAPI();
            try
            {
                if (string.IsNullOrEmpty(propertyId))
                    return "";
                var pm = PropertyManager.GetInstance();
                var property = pm.GetProperty(propertyId);
                return property.Layout;
            }
            catch (Exception e)
            {
                api.LogError(e);
            }
            return "";

        }

        public static string GetPropertyInterior(string propertyId, string propertyType)
        {
            var api = new CDebugActionsAPI();
            try
            {
                var pm = PropertyManager.GetInstance();
                var property = pm.GetProperty(propertyId);
                var resourceData1 = ResourceFile.Load($"data/world/{propertyType}/{propertyId}.json");
                var buildingInteriorLink = JsonConvert.DeserializeObject<BuildingInteriorLink>(resourceData1.Load());
                return buildingInteriorLink.Interior;

            }
            catch (Exception e)
            {
                api.LogError(e);
            }
            return "";
        }


        public static string GetPropertyPartType(string partName)
        {
            var api = new CDebugActionsAPI();
            try
            {
                var propertyType = partName.Split('_')[0];
                switch (propertyType)
                {
                    case "apt":
                        return "apartments";
                        break;
                    case "gar":
                        return "garages";
                        break;
                }
            }
            catch (Exception e)
            {
                api.LogError(e);
            }
            return "";
        }
        //apt_high_pier_01_ext_ped_01
        public static string ExitProperty(string propertyId, string propertyPart, string exitId)
        {
            var api = new CDebugActionsAPI();
            try
            {
                //if (string.IsNullOrEmpty(propertyId))
                //    return "";
                //var pm = PropertyManager.GetInstance();
                //var property = pm.GetProperty(propertyId);
                //var type = property.Type;
                //var garageString = property.Garage;
                //var aptString = property.Apartment; 

                //ResourceFile resourceData1 = null;
                //ResourceFile resourceData2 = null; 

                //var propertyType = propertyPart.Split('_')[0];
                //var abc = GetPropertyPartType(propertyPart);

                //api.LogDebug("tes");
                //api.LogDebug(exitId);

                //resourceData1 = ResourceFile.Load($"data/world/{abc}/{propertyPart}.json");
                //var buildingInteriorLink = JsonConvert.DeserializeObject<BuildingInteriorLink>(resourceData1.Load()); 
                //var targetEntryPointString = buildingInteriorLink.InteriorExits[exitId];


                //resourceData2 = ResourceFile.Load($"data/world/buildings/{buildingInteriorLink.Building}.json");
                //var interiorMetadata = JsonConvert.DeserializeObject<BuildingMetadata>(resourceData2.Load()); 
                //var targetEntryPoint = interiorMetadata.ExitPoints.FirstOrDefault(e => e.Id.Equals(targetEntryPointString));

                //api.LogDebug("tes");
                //api.LogDebug(propertyPart);

                //Game.PlayerPed.Position = targetEntryPoint.Position;
                //return targetEntryPoint.Id;
            }
            catch (Exception e)
            {
                api.LogError(e);
            }
            return "";
        }

        public static string GetPropertyBuilding(string propertyId)
        {
            var api = new CDebugActionsAPI();
            try
            {
                if (string.IsNullOrEmpty(propertyId))
                    return "";
                var pm = PropertyManager.GetInstance();
                var property = pm.GetProperty(propertyId);
                return property.Building;
            }
            catch (Exception e)
            {
                api.LogError(e);
            }
            return "";
        }

        public static string GetInteriorExitString(string interiorId, int exitId = 0)
        {
            var api = new CDebugActionsAPI();
            try
            {
                ResourceFile resourceData3 = null;
                resourceData3 = ResourceFile.Load($"data/world/interiors/{interiorId}.json");
                var interiorMetadata = JsonConvert.DeserializeObject<InteriorMetadata>(resourceData3.Load());
                var targetEntryPoint = interiorMetadata.AccessPoints[exitId];
                return targetEntryPoint.Id;
            }
            catch (Exception e)
            {
                api.LogError(e);
            }
            return "";
        }

        public static Vector3 GetInteriorExit(string interiorId, int exitId = 0)
        {
            var api = new CDebugActionsAPI();
            try
            {
                ResourceFile resourceData3 = null;
                resourceData3 = ResourceFile.Load($"data/world/interiors/{interiorId}.json");
                var interiorMetadata = JsonConvert.DeserializeObject<InteriorMetadata>(resourceData3.Load());
                var targetEntryPoint = interiorMetadata.AccessPoints[exitId];
                return targetEntryPoint.DoorPosition;
            }
            catch (Exception e)
            {
                api.LogError(e);
            }
            return Vector3.One;
        }





        public static int GetNumOfInteriorExits(string interiorId)
        {
            var api = new CDebugActionsAPI();
            try
            {
                ResourceFile resourceData = null;
                resourceData = ResourceFile.Load($"data/world/interiors/{interiorId}.json");
                var interiorMetadata = JsonConvert.DeserializeObject<InteriorMetadata>(resourceData.Load());
                return interiorMetadata.AccessPoints.Count;
            }
            catch (Exception e)
            {
                api.LogError(e);
            }
            return 0;
        }


    }
}
