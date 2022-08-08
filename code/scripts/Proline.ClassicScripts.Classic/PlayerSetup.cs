using CitizenFX.Core;
using CitizenFX.Core.Native;
using Newtonsoft.Json;
using Proline.CFXExtended.Core;
using Proline.ClassicOnline.CDebugActions;
using Proline.ClassicOnline.CGameLogic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            if (!CDataStream.API.DoesDataFileExist(id))
            {
                CDataStream.API.CreateDataFile();
                CDataStream.API.AddDataFileValue("PlayerHealth", Game.PlayerPed.Health);
                CDataStream.API.AddDataFileValue("PlayerPosition", JsonConvert.SerializeObject(Game.PlayerPed.Position));
                CDataStream.API.AddDataFileValue("BankBalance", 0);
                CDataStream.API.AddDataFileValue("WalletBalance", 0);
                CDataStream.API.SaveDataFile(id);
                CDebugActionsAPI.LogDebug(id + " Created and saved");
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
            if (!CDataStream.API.DoesDataFileExist(id))
            {
                CDataStream.API.CreateDataFile();
                var outfit = new CharacterOutfit();
                outfit.Components = list;
                var json = JsonConvert.SerializeObject(outfit);
                CDataStream.API.AddDataFileValue("CharacterOutfit", json);
                CDataStream.API.SaveDataFile(id);
                CDebugActionsAPI.LogDebug(id + " Created and saved");
            }

            id = "PlayerStats";
            if (!CDataStream.API.DoesDataFileExist(id))
            {
                CDataStream.API.CreateDataFile();
                CDataStream.API.AddDataFileValue("MP0_WALLET_BALANCE", stat.GetValue());
                CDataStream.API.AddDataFileValue("BANK_BALANCE", stat2.GetValue());
                CDataStream.API.SaveDataFile(id);
                CDebugActionsAPI.LogDebug(id + " Created and saved");
            }

        }
    }
}
