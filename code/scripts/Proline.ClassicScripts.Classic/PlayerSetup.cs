﻿using CitizenFX.Core;
using CitizenFX.Core.Native;
using Newtonsoft.Json;
using Proline.CFXExtended.Core;
using Proline.ClassicOnline.CDebugActions;
using Proline.ClassicOnline.CGameLogic;
using Proline.ClassicOnline.CGameLogic.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Proline.ClassicOnline.SClassic
{
    public class PlayerSetup
    {
        public async Task Execute(object[] args, CancellationToken token)
        {
            var stat = MPStat.GetStat<long>("MP0_WALLET_BALANCE");
            var stat2 = MPStat.GetStat<long>("BANK_BALANCE");

            var list = new OutfitComponent[12];
            for (int i = 0; i < list.Length; i++)
            {
                var component = list[i];
                component.ComponentIndex = API.GetPedDrawableVariation(Game.PlayerPed.Handle, i);
                component.ComponentPallet = API.GetPedPaletteVariation(Game.PlayerPed.Handle, i);
                component.ComponentTexture = API.GetPedTextureVariation(Game.PlayerPed.Handle, i);

            }

            var id = "PlayerInfo";
            if (!CDataStream.CDataStreamAPI.DoesDataFileExist(id))
            {
                CDataStream.CDataStreamAPI.CreateDataFile();
                CDataStream.CDataStreamAPI.AddDataFileValue("PlayerHealth", Game.PlayerPed.Health);
                CDataStream.CDataStreamAPI.AddDataFileValue("PlayerPosition", JsonConvert.SerializeObject(Game.PlayerPed.Position));
                CDataStream.CDataStreamAPI.AddDataFileValue("BankBalance", 0);
                CDataStream.CDataStreamAPI.AddDataFileValue("WalletBalance", 0);
                CDataStream.CDataStreamAPI.SaveDataFile(id);
                CDebugActionsAPI.LogDebug(id + " Created and saved");
                CGameLogicAPI.SetCharacterMaxWalletBalance(1000);
            }



            //ClassicOnline.CDataStream.API.DoesDataFileExist("PlayerVehicle");
            //if (ClassicOnline.CDataStream.API.DoesDataFileValueExist("VehicleHash"))
            //{
            //    var pv = (VehicleHash)ClassicOnline.CDataStream.API.GetDataFileValue<uint>("VehicleHash");
            //    var position = ClassicOnline.CDataStream.API.GetDataFileValue<Vector3>("VehiclePosition");
            //    var vehicle = await World.CreateVehicle(new Model(pv), position);
            //    vehicle.PlaceOnNextStreet();
            //    vehicle.IsPersistent = true;
            //    if (vehicle.AttachedBlips.Length == 0)
            //        vehicle.AttachBlip();
            //    //blip.IsFlashing = true;
            //}

            id = "PlayerOutfit";
            if (!CDataStream.CDataStreamAPI.DoesDataFileExist(id))
            {
                CDataStream.CDataStreamAPI.CreateDataFile();
                var outfit = new CharacterOutfit();
                outfit.Components = list;
                var json = JsonConvert.SerializeObject(outfit);
                CDataStream.CDataStreamAPI.AddDataFileValue("CharacterOutfit", json);
                CDataStream.CDataStreamAPI.SaveDataFile(id);
                CDebugActionsAPI.LogDebug(id + " Created and saved");
            }

            id = "PlayerStats";
            if (!CDataStream.CDataStreamAPI.DoesDataFileExist(id))
            {
                CDataStream.CDataStreamAPI.CreateDataFile();
                CDataStream.CDataStreamAPI.AddDataFileValue("MP0_WALLET_BALANCE", stat.GetValue());
                CDataStream.CDataStreamAPI.AddDataFileValue("BANK_BALANCE", stat2.GetValue());
                CDataStream.CDataStreamAPI.SaveDataFile(id);
                CDebugActionsAPI.LogDebug(id + " Created and saved");
            }

        }
    }
}
