using CitizenFX.Core;
using CitizenFX.Core.Native;
using Newtonsoft.Json;
using Proline.ClassicOnline.CDebugActions;
using Proline.ClassicOnline.CShopCatalogue.Internal;
using Proline.ClassicOnline.GCharacter;
using Proline.ClassicOnline.MGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proline.ClassicOnline.CShopCatalogue
{
    internal static partial class MShopAPI
    {
        public static void BuyVehicle(string vehicleName)
        {
            try
            {
                if (CharacterGlobals.Character != null)
                {
                    var manager = CatalougeManager.GetInstance();
                    var catalouge = manager.GetCatalouge("VehicleCatalouge");
                    if (catalouge == null)
                        throw new Exception("Catalouge not found");
                    var vci = (VehicleCatalougeItem)catalouge.GetItem(vehicleName);

                    if (vci == null)
                        throw new Exception("Catalouge Item not found");
                    var character = CharacterGlobals.Character;
                    if (character.BankBalance > vci.Price)
                    {
                        var currentVehicle = character.PersonalVehicle;
                        if (currentVehicle != null)
                        {
                            foreach (var item in currentVehicle.AttachedBlips)
                            {
                                item.Delete();
                            }
                            currentVehicle.IsPersistent = false;
                            currentVehicle.Delete();
                        }


                        character.BankBalance -= vci.Price;
                        var task = World.CreateVehicle(new Model(vci.Model), World.GetNextPositionOnStreet(Game.PlayerPed.Position));
                        task.ContinueWith(e =>
                        {
                            var createdVehicle = e.Result;
                            character.PersonalVehicle = new GCharacter.Data.CharacterPersonalVehicle(createdVehicle.Handle);

                            var id = "PlayerVehicle";
                            CDataStream.API.CreateDataFile();
                            CDataStream.API.AddDataFileValue("VehicleHash", createdVehicle.Model.Hash);
                            CDataStream.API.AddDataFileValue("VehiclePosition", JsonConvert.SerializeObject(createdVehicle.Position));
                            createdVehicle.IsPersistent = true;
                            if (createdVehicle.AttachedBlips.Length == 0)
                                createdVehicle.AttachBlip();
                            CDataStream.API.SaveDataFile(id);
                            MGameAPI.SetCharacterBankBalance(character.BankBalance);
                        });

                    }
                }

            }
            catch (Exception e)
            {
                CDebugActionsAPI.LogError(e);
            }
        }
    }
}
