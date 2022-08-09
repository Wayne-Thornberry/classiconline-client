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

            if (!CDataStream.CDataStreamAPI.IsSaveInProgress())
            {
                // attempt to get the player id
                // fish for the save files from the player id
                CCoreSystem.CCoreSystemAPI.StartNewScript("LoadDefaultOnline");
                while (CCoreSystem.CCoreSystemAPI.GetInstanceCountOfScript("LoadDefaultOnline") > 0)
                {
                    await BaseScript.Delay(1);
                }
                await CDataStream.CDataStreamAPI.PullSaveFromCloud(); // Sends a load request to the server
                if (CDataStream.CDataStreamAPI.HasSaveLoaded())
                {
                    PlayerCharacter character = CreateNewCharacter(); 

                    if (CDataStream.CDataStreamAPI.DoesDataFileExist("PlayerInfo"))
                    {
                        CDataStream.CDataStreamAPI.SelectDataFile("PlayerInfo");
                        character.Health = CDataStream.CDataStreamAPI.GetDataFileValue<int>("PlayerHealth");
                        character.Position = CDataStream.CDataStreamAPI.GetDataFileValue<Vector3>("PlayerPosition");
                        CGameLogicAPI.SetCharacterBankBalance(CDataStream.CDataStreamAPI.GetDataFileValue<long>("BankBalance"));
                        CGameLogicAPI.SetCharacterWalletBalance(CDataStream.CDataStreamAPI.GetDataFileValue<long>("WalletBalance"));
                    }

                    if (CDataStream.CDataStreamAPI.DoesDataFileExist("PlayerStats"))
                    {
                        CDataStream.CDataStreamAPI.SelectDataFile("PlayerStats");
                        var x = CDataStream.CDataStreamAPI.GetDataFileValue<int>("MP0_WALLET_BALANCE");
                        var y = CDataStream.CDataStreamAPI.GetDataFileValue<int>("BANK_BALANCE");
                        character.Stats.SetStat("WALLET_BALANCE", x);
                        character.Stats.SetStat("BANK_BALANCE", y);
                    }
                     
                    if (CDataStream.CDataStreamAPI.DoesDataFileExist("CharacterLooks"))
                    {
                        CDataStream.CDataStreamAPI.SelectDataFile("CharacterLooks");
                        var mother = CDataStream.CDataStreamAPI.GetDataFileValue<int>("Mother");
                        var father = CDataStream.CDataStreamAPI.GetDataFileValue<int>("Father");
                        var resemblence = CDataStream.CDataStreamAPI.GetDataFileValue<float>("Resemblance");
                        var skintone = CDataStream.CDataStreamAPI.GetDataFileValue<float>("SkinTone");

                        CGameLogicAPI.SetPedLooks(Game.PlayerPed.Handle, new CharacterLooks()
                        {
                            Mother = mother,
                            Father = father,
                            Resemblence = resemblence * 0.1f,
                            SkinTone = skintone * 0.1f,
                        });
                    }

                    if (CDataStream.CDataStreamAPI.DoesDataFileExist("PlayerOutfit"))
                    {
                        CDataStream.CDataStreamAPI.SelectDataFile("PlayerOutfit");
                        var outfit = CDataStream.CDataStreamAPI.GetDataFileValue<CharacterOutfit>("CharacterOutfit");
                        var components = outfit.Components;
                        for (int i = 0; i < components.Length; i++)
                        {
                            var component = components[i];
                            API.SetPedComponentVariation(Game.PlayerPed.Handle, i, component.ComponentIndex, component.ComponentTexture, component.ComponentPallet);

                        }
                    }

                    if (CDataStream.CDataStreamAPI.DoesDataFileExist("PlayerVehicle"))
                    { 
                        CDataStream.CDataStreamAPI.SelectDataFile("PlayerVehicle");
                        if (CDataStream.CDataStreamAPI.DoesDataFileValueExist("VehicleHash"))
                        {
                            var pv = (VehicleHash) (uint) CDataStream.CDataStreamAPI.GetDataFileValue<int>("VehicleHash");
                            var position = CDataStream.CDataStreamAPI.GetDataFileValue<Vector3>("VehiclePosition");
                            var vehicle = await World.CreateVehicle(new Model(pv), Game.PlayerPed.Position);
                            vehicle.PlaceOnNextStreet();
                            vehicle.IsPersistent = true;
                            if (vehicle.AttachedBlips.Length == 0)
                                vehicle.AttachBlip();
                            CGameLogicAPI.SetCharacterPersonalVehicle(vehicle.Handle);
                        }
                    }

                    if (CDataStream.CDataStreamAPI.DoesDataFileExist("PlayerWeapon"))
                    {
                        CDataStream.CDataStreamAPI.SelectDataFile("PlayerWeapon");
                        if (CDataStream.CDataStreamAPI.DoesDataFileValueExist("WeaponHash"))
                        {
                            var hash = (WeaponHash)CDataStream.CDataStreamAPI.GetDataFileValue<uint>("WeaponHash");
                            var ammo = CDataStream.CDataStreamAPI.GetDataFileValue<int>("WeaponAmmo");
                            Game.PlayerPed.Weapons.Give(hash, ammo, true, true);
                        }
                    }

                    CGameLogicAPI.SetCharacter(character);
                    CCoreSystem.CCoreSystemAPI.StartNewScript("LoadStats");

                }
                else
                {
                    CDebugActionsAPI.LogDebug("No save file to load from, attempting to create a save...");
                    /// If the player doesnt have basic info, that means the player does not have a save
                    if (!CDataStream.CDataStreamAPI.DoesDataFileExist("PlayerInfo"))
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
