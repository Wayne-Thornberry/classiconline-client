using CitizenFX.Core;
using CitizenFX.Core.Native;
using Newtonsoft.Json;
using Proline.ClassicOnline.CDebugActions;
using Proline.ClassicOnline.CWorldObjects;
using Proline.ClassicOnline.Engine.Parts;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Proline.ClassicOnline.SClassic.Buildings
{
    public class CharacterApts
    {
        private List<Vector3> _buildingEntrances;
        private List<Vector3> _interiorExits;
        private Blip _blip;
        private string _targetPropertyPart;
        private string _targetArea;
        private Vector3 _lastPoint;
        private Vector3 _buildingVector;
        private string _interior;
        private string _enteredBuilding;
        private string _neariestEntrance;
        private string _targetProperty;
        private int[] _vehicles;

        public async Task Execute(object[] args, CancellationToken token)
        {
            // Dupe protection
            if (EngineAPI.GetInstanceCountOfScript("CharacterApts") > 1)
                return;
            var properties = new string[] { "apt_richmaj_he_01", "apt_dpheights_he_01" };
            var stage = 0;
            while (!token.IsCancellationRequested)
            {

                switch (stage)
                {
                    case 0:
                        _buildingEntrances = new List<Vector3>();
                        foreach (var item in properties)
                        {
                            RefreshEntryPoints(item);
                        }
                        stage++;
                        break;
                    case 1:
                        foreach (var entrance in _buildingEntrances)
                        {
                            World.DrawMarker(MarkerType.DebugSphere, entrance, new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(1, 1, 1),
                                System.Drawing.Color.FromArgb(150, 0, 0, 0));
                            if (World.GetDistance(Game.PlayerPed.Position, entrance) < 2f)
                            {
                                _enteredBuilding = CWorldObjects.CWorldObjects.GetNearestBuilding();
                                _neariestEntrance = CWorldObjects.CWorldObjects.GetNearestBuildingEntrance(_enteredBuilding);
                                _buildingVector = CWorldObjects.CWorldObjects.GetBuildingWorldPos(_enteredBuilding);
                                var whereAreYouEntering = CWorldObjects.CWorldObjects.EnterBuilding(_enteredBuilding, _neariestEntrance);
                                _targetProperty = "apt_richmaj_he_01";
                                switch (whereAreYouEntering)
                                {
                                    case "Garage": _targetPropertyPart = CWorldObjects.CWorldObjects.GetPropertyGarage(_targetProperty); break;
                                    case "Apartment": _targetPropertyPart = CWorldObjects.CWorldObjects.GetPropertyApartment(_targetProperty); break;
                                }
                                _targetArea = whereAreYouEntering;
                                //WorldAPI.EnterProperty(PropertyId, _targetProperty, _neariestEntrance);
                                _interior = CWorldObjects.CWorldObjects.GetPropertyInterior(_targetPropertyPart, whereAreYouEntering + "s");
                                var interiorEntry = CWorldObjects.CWorldObjects.GetPropertyEntry(_targetPropertyPart, whereAreYouEntering + "s", _neariestEntrance);
                                _lastPoint = CWorldObjects.CWorldObjects.EnterInterior(_interior, interiorEntry);
                                Game.PlayerPed.Position = _lastPoint;
                                switch (_targetArea)
                                {
                                    case "Garage":
                                        {
                                            var limit = CWorldObjects.CWorldObjects.GetPropertyGarageLimit(_targetProperty);
                                            _vehicles = new int[limit];
                                            for (int i = 0; i < limit; i++)
                                            {
                                                var vehicle = await World.CreateVehicle(new Model(VehicleHash.Buffalo3), Game.PlayerPed.Position);
                                                _vehicles[i] = vehicle.Handle;
                                                CWorldObjects.CWorldObjects.PlaceVehicleInGarageSlot(_targetProperty, i, vehicle);
                                            }
                                        }
                                        break;
                                }
                                RefreshExitPoints();
                                stage++;
                            }
                        }
                        break;
                    case 2:
                        {
                            if (World.GetDistance(Game.PlayerPed.Position, _lastPoint) > 4f)
                            {
                                stage++;
                            }
                        }
                        break;
                    case 3:
                        if (API.GetInteriorFromEntity(Game.PlayerPed.Handle) == 0)
                            stage = 0;

                        if (!Game.PlayerPed.IsInVehicle())
                        {
                            foreach (var exit in _interiorExits)
                            {
                                World.DrawMarker(MarkerType.DebugSphere, exit, new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(1, 1, 1),
                                    System.Drawing.Color.FromArgb(150, 0, 0, 0));
                                if (World.GetDistance(Game.PlayerPed.Position, exit) < 2f)
                                {
                                    var neariestExit = CWorldObjects.CWorldObjects.GetNearestInteriorExit(_interior);
                                    var whereAreYouExiting = CWorldObjects.CWorldObjects.ExitInterior(_interior, neariestExit);
                                    var newExit = CWorldObjects.CWorldObjects.GetPropertyExit(_targetPropertyPart, _targetArea + "s", neariestExit);
                                    var placePosition = CWorldObjects.CWorldObjects.ExitBuilding(_enteredBuilding, newExit, Game.PlayerPed.IsInVehicle() ? 1 : 0);
                                    Game.PlayerPed.Position = placePosition;
                                    _lastPoint = placePosition;
                                    stage++;
                                }
                            }
                        }
                        else
                        {
                            if (Game.IsControlJustPressed(0, Control.VehicleAccelerate))
                            {
                                var neariestExit = CWorldObjects.CWorldObjects.GetNearestInteriorExit(_interior);
                                var whereAreYouExiting = CWorldObjects.CWorldObjects.ExitInterior(_interior, neariestExit);
                                var newExit = CWorldObjects.CWorldObjects.GetPropertyExit(_targetPropertyPart, _targetArea + "s", neariestExit);
                                var placePosition = CWorldObjects.CWorldObjects.ExitBuilding(_enteredBuilding, newExit, Game.PlayerPed.IsInVehicle() ? 1 : 0);
                                Game.PlayerPed.CurrentVehicle.Position = placePosition;
                                _lastPoint = placePosition;
                                stage++;
                            }
                        }
                        break;
                    case 4:
                        {
                            // Cleanup
                            switch (_targetArea)
                            {
                                case "Garage":
                                    {
                                        for (int i = 0; i < _vehicles.Length; i++)
                                        {
                                            var vehicle = new Vehicle(_vehicles[i]);
                                            if (Game.PlayerPed.CurrentVehicle == vehicle)
                                            {
                                                var pv = EngineAPI.GetPersonalVehicle();
                                                pv.Delete();
                                                EngineAPI.SetCharacterPersonalVehicle(_vehicles[i]);
                                                vehicle.AttachBlip();
                                                continue;
                                            }
                                            vehicle.Delete();
                                        }
                                    }
                                    break;
                            }
                            stage++;
                        }
                        break;
                    case 5:
                        {
                            if (World.GetDistance(Game.PlayerPed.Position, _lastPoint) > 4f)
                            {
                                stage = 0;
                                EngineAPI.LogDebug(stage);
                            }
                        }
                        break;
                }

                await BaseScript.Delay(0);
            }
        }

        private void RefreshEntryPoints(string propertyId)
        {
            for (int i = 0; i < CWorldObjects.CWorldObjects.GetNumOfBuldingEntrances(CWorldObjects.CWorldObjects.GetPropertyBuilding(propertyId)); i++)
            {
                _buildingEntrances.Add(CWorldObjects.CWorldObjects.GetBuildingEntrance(CWorldObjects.CWorldObjects.GetPropertyBuilding(propertyId), i));
            };
        }

        private void RefreshExitPoints()
        {
            _interiorExits = new List<Vector3>();
            for (int i = 0; i < CWorldObjects.CWorldObjects.GetNumOfInteriorExits(_interior); i++)
            {
                var x = CWorldObjects.CWorldObjects.GetInteriorExit(_interior, i);
                _interiorExits.Add(x);
                EngineAPI.LogDebug($"{i} {JsonConvert.SerializeObject(x)}");
            };
        }
    }
}
