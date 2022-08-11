using CitizenFX.Core;
using CitizenFX.Core.Native;
using Proline.ClassicOnline.Common.Data;
using Proline.ClassicOnline.Engine.Parts;
using System.Threading;
using System.Threading.Tasks;

namespace Proline.ClassicOnline.SClassic
{
    internal class PlayerLoading
    {
        public async Task Execute(object[] args, CancellationToken token)
        {

            if (!EngineAPI.IsSaveInProgress())
            {
                // attempt to get the player id
                // fish for the save files from the player id
                EngineAPI.StartNewScript("LoadDefaultOnline");
                while (EngineAPI.GetInstanceCountOfScript("LoadDefaultOnline") > 0)
                {
                    await BaseScript.Delay(1);
                }
                await EngineAPI.PullSaveFromCloud(); // Sends a load request to the server
                if (EngineAPI.HasSaveLoaded())
                {
                    PlayerCharacter character = CreateNewCharacter();

                    if (EngineAPI.DoesDataFileExist("PlayerInfo"))
                    {
                        EngineAPI.SelectDataFile("PlayerInfo");
                        character.Health = EngineAPI.GetDataFileValue<int>("PlayerHealth");
                        character.Position = EngineAPI.GetDataFileValue<Vector3>("PlayerPosition");
                        EngineAPI.SetCharacterBankBalance(EngineAPI.GetDataFileValue<long>("BankBalance"));
                        EngineAPI.SetCharacterWalletBalance(EngineAPI.GetDataFileValue<long>("WalletBalance"));
                    }

                    if (EngineAPI.DoesDataFileExist("PlayerStats"))
                    {
                        EngineAPI.SelectDataFile("PlayerStats");
                        var x = EngineAPI.GetDataFileValue<int>("MP0_WALLET_BALANCE");
                        var y = EngineAPI.GetDataFileValue<int>("BANK_BALANCE");
                        character.Stats.SetStat("WALLET_BALANCE", x);
                        character.Stats.SetStat("BANK_BALANCE", y);
                    }

                    if (EngineAPI.DoesDataFileExist("CharacterLooks"))
                    {
                        EngineAPI.SelectDataFile("CharacterLooks");
                        var mother = EngineAPI.GetDataFileValue<int>("Mother");
                        var father = EngineAPI.GetDataFileValue<int>("Father");
                        var resemblence = EngineAPI.GetDataFileValue<float>("Resemblance");
                        var skintone = EngineAPI.GetDataFileValue<float>("SkinTone");

                        EngineAPI.SetPedLooks(Game.PlayerPed.Handle, new CharacterLooks()
                        {
                            Mother = mother,
                            Father = father,
                            Resemblence = resemblence * 0.1f,
                            SkinTone = skintone * 0.1f,
                        });
                    }

                    if (EngineAPI.DoesDataFileExist("PlayerOutfit"))
                    {
                        EngineAPI.SelectDataFile("PlayerOutfit");
                        var outfit = EngineAPI.GetDataFileValue<CharacterOutfit>("CharacterOutfit");
                        var components = outfit.Components;
                        for (int i = 0; i < components.Length; i++)
                        {
                            var component = components[i];
                            API.SetPedComponentVariation(Game.PlayerPed.Handle, i, component.ComponentIndex, component.ComponentTexture, component.ComponentPallet);

                        }
                    }

                    if (EngineAPI.DoesDataFileExist("PlayerVehicle"))
                    {
                        EngineAPI.SelectDataFile("PlayerVehicle");
                        if (EngineAPI.DoesDataFileValueExist("VehicleHash"))
                        {
                            var pv = (VehicleHash)(uint)EngineAPI.GetDataFileValue<int>("VehicleHash");
                            var position = EngineAPI.GetDataFileValue<Vector3>("VehiclePosition");
                            var vehicle = await World.CreateVehicle(new Model(pv), Game.PlayerPed.Position);
                            vehicle.PlaceOnNextStreet();
                            vehicle.IsPersistent = true;
                            if (vehicle.AttachedBlips.Length == 0)
                                vehicle.AttachBlip();
                            EngineAPI.SetCharacterPersonalVehicle(vehicle.Handle);
                        }
                    }

                    if (EngineAPI.DoesDataFileExist("PlayerWeapon"))
                    {
                        EngineAPI.SelectDataFile("PlayerWeapon");
                        if (EngineAPI.DoesDataFileValueExist("WeaponHash"))
                        {
                            var hash = (WeaponHash)EngineAPI.GetDataFileValue<uint>("WeaponHash");
                            var ammo = EngineAPI.GetDataFileValue<int>("WeaponAmmo");
                            Game.PlayerPed.Weapons.Give(hash, ammo, true, true);
                        }
                    }

                    EngineAPI.SetCharacter(character);
                    EngineAPI.StartNewScript("LoadStats");

                }
                else
                {
                    EngineAPI.LogDebug("No save file to load from, attempting to create a save...");
                    /// If the player doesnt have basic info, that means the player does not have a save
                    if (!EngineAPI.DoesDataFileExist("PlayerInfo"))
                    {
                        EngineAPI.StartNewScript("PlayerSetup");
                        while (EngineAPI.GetInstanceCountOfScript("PlayerSetup") > 0)
                        {
                            await BaseScript.Delay(1);
                        }
                        EngineAPI.StartNewScript("SaveNow");
                        while (EngineAPI.GetInstanceCountOfScript("SaveNow") > 0)
                        {
                            await BaseScript.Delay(1);
                        }
                    }
                    EngineAPI.StartNewScript("PlayerLoading");
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
