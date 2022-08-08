using CitizenFX.Core;
using Newtonsoft.Json;
using Proline.CFXExtended.Core;
using Proline.ClassicOnline.CGameLogic;

using System;
using System.Collections.Generic;
using System.Linq;
using Proline.Resource.Framework;
using System.Text;
using System.Threading.Tasks;
using Console = Proline.Resource.Console;
using Proline.ClassicOnline.CGameLogic;

namespace Proline.ClassicOnline.CNetConnection.Commands
{
    public class BuyRandomVehicleCommand : ResourceCommand
    {
        public BuyRandomVehicleCommand() : base("BuyRandomVehicle")
        {
        }

        protected override void OnCommandExecute(params object[] args)
        {

            if (CGameLogicAPI.GetCharacterBankBalance() > 250)
            {
                if (CGameLogicAPI.HasCharacter())
                {
                    if (CGameLogicAPI.GetPersonalVehicle() != null)
                    {
                        CGameLogicAPI.DeletePersonalVehicle();
                    }


                    CGameLogicAPI.SetCharacterBankBalance(250);
                    Array values = Enum.GetValues(typeof(VehicleHash));
                    Random random = new Random();
                    VehicleHash randomBar = (VehicleHash)values.GetValue(random.Next(values.Length));
                    var task = World.CreateVehicle(new Model(randomBar), World.GetNextPositionOnStreet(Game.PlayerPed.Position));
                    task.ContinueWith(e =>
                    {
                        var vehicle = e.Result;
                        CGameLogicAPI.SetCharacterPersonalVehicle(vehicle.Handle);

                        var id = "PlayerVehicle";
                        CDataStream.API.CreateDataFile();
                        CDataStream.API.AddDataFileValue("VehicleHash", vehicle.Model.Hash);
                        CDataStream.API.AddDataFileValue("VehiclePosition", JsonConvert.SerializeObject(vehicle.Position));
                        vehicle.IsPersistent = true;
                        if (vehicle.AttachedBlips.Length == 0)
                            vehicle.AttachBlip();
                        CDataStream.API.SaveDataFile(id);

                    });
                }


            }
        }
    }
}
