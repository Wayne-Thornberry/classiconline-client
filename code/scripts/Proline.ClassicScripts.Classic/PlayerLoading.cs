using CitizenFX.Core;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CitizenFX.Core.Native;

using Proline.Resource;
using Proline.CFXExtended.Core; 
using Proline.ClassicOnline.CGameLogic;
using Proline.ClassicOnline.CGameLogic.Data; 
using Proline.ClassicOnline.CDebugActions; 

namespace Proline.ClassicOnline.SClassic
{
    internal class PlayerLoading
    {
        public async Task Execute(object[] args, CancellationToken token)
        {

            if (!CDataStream.API.IsSaveInProgress())
            {
                // attempt to get the player id
                // fish for the save files from the player id
                CCoreSystem.CCoreSystemAPI.StartNewScript("LoadDefaultOnline");
                while (CCoreSystem.CCoreSystemAPI.GetInstanceCountOfScript("LoadDefaultOnline") > 0)
                {
                    await BaseScript.Delay(1);
                }
                await CDataStream.API.PullSaveFromCloud(); // Sends a load request to the server
                if (CDataStream.API.HasSaveLoaded())
                {
                    PlayerCharacter character = CreateNewCharacter(); 

                    if (CDataStream.API.DoesDataFileExist("PlayerInfo"))
                    {
                        CDataStream.API.SelectDataFile("PlayerInfo");
                        character.Health = CDataStream.API.GetDataFileValue<int>("PlayerHealth");
                        character.Position = CDataStream.API.GetDataFileValue<Vector3>("PlayerPosition");
                        character.BankBalance = CDataStream.API.GetDataFileValue<long>("BankBalance");
                        character.WalletBalance = CDataStream.API.GetDataFileValue<long>("WalletBalance");
                    }

                    if (CDataStream.API.DoesDataFileExist("PlayerStats"))
                    {
                        CDataStream.API.SelectDataFile("PlayerStats");
                        var x = CDataStream.API.GetDataFileValue<int>("MP0_WALLET_BALANCE");
                        var y = CDataStream.API.GetDataFileValue<int>("BANK_BALANCE");
                        character.Stats.SetStat("WALLET_BALANCE", x);
                        character.Stats.SetStat("BANK_BALANCE", y);
                    }
                     
                    if (CDataStream.API.DoesDataFileExist("CharacterLooks"))
                    {
                        CDataStream.API.SelectDataFile("CharacterLooks");
                        var mother = CDataStream.API.GetDataFileValue<int>("Mother");
                        var father = CDataStream.API.GetDataFileValue<int>("Father");
                        var resemblence = CDataStream.API.GetDataFileValue<float>("Resemblance");
                        var skintone = CDataStream.API.GetDataFileValue<float>("SkinTone");

                        CGameLogicAPI.SetPedLooks(Game.PlayerPed.Handle, new CharacterLooks()
                        {
                            Mother = mother,
                            Father = father,
                            Resemblence = resemblence * 0.1f,
                            SkinTone = skintone * 0.1f,
                        });
                    }

                    if (CDataStream.API.DoesDataFileExist("PlayerOutfit"))
                    {
                        CDataStream.API.SelectDataFile("PlayerOutfit");
                        var outfit = CDataStream.API.GetDataFileValue<CharacterOutfit>("CharacterOutfit");
                        var components = outfit.Components;
                        for (int i = 0; i < components.Length; i++)
                        {
                            var component = components[i];
                            API.SetPedComponentVariation(Game.PlayerPed.Handle, i, component.ComponentIndex, component.ComponentTexture, component.ComponentPallet);

                        }
                    }

                    if (CDataStream.API.DoesDataFileExist("PlayerVehicle"))
                    { 
                        CDataStream.API.SelectDataFile("PlayerVehicle");
                        if (CDataStream.API.DoesDataFileValueExist("VehicleHash"))
                        {
                            var pv = (VehicleHash) (uint) CDataStream.API.GetDataFileValue<int>("VehicleHash");
                            var position = CDataStream.API.GetDataFileValue<Vector3>("VehiclePosition");
                            var vehicle = await World.CreateVehicle(new Model(pv), Game.PlayerPed.Position);
                            vehicle.PlaceOnNextStreet();
                            vehicle.IsPersistent = true;
                            if (vehicle.AttachedBlips.Length == 0)
                                vehicle.AttachBlip();
                            CGameLogicAPI.SetCharacterPersonalVehicle(vehicle.Handle);
                        }
                    }

                    if (CDataStream.API.DoesDataFileExist("PlayerWeapon"))
                    {
                        CDataStream.API.SelectDataFile("PlayerWeapon");
                        if (CDataStream.API.DoesDataFileValueExist("WeaponHash"))
                        {
                            var hash = (WeaponHash)CDataStream.API.GetDataFileValue<uint>("WeaponHash");
                            var ammo = CDataStream.API.GetDataFileValue<int>("WeaponAmmo");
                            Game.PlayerPed.Weapons.Give(hash, ammo, true, true);
                        }
                    }

                    CCoreSystem.CCoreSystemAPI.StartNewScript("LoadStats");

                }
                else
                {
                    CDebugActionsAPI.LogDebug("No save file to load from, attempting to create a save...");
                    /// If the player doesnt have basic info, that means the player does not have a save
                    if (!CDataStream.API.DoesDataFileExist("PlayerInfo"))
                    {
                        CCoreSystem.CCoreSystemAPI.StartNewScript("PlayerSetup");
                        while (CCoreSystem.CCoreSystemAPI.GetInstanceCountOfScript("PlayerSetup") > 0)
                        {
                            await BaseScript.Delay(1);
                        }
                        CCoreSystem.CCoreSystemAPI.StartNewScript("SaveNow");
                        while (CCoreSystem.CCoreSystemAPI.GetInstanceCountOfScript("SaveNow") > 0)
                        {
                            await BaseScript.Delay(1);
                        }
                    }
                    CCoreSystem.CCoreSystemAPI.StartNewScript("PlayerLoading");
                }

            }

        }

        private static PlayerCharacter CreateNewCharacter()
        {
            var character = new PlayerCharacter(Game.PlayerPed.Handle);
            character.Stats = new CharacterStats();
            return character;
        }
         
    }
}
