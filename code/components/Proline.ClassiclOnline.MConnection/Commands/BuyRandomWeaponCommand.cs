using CitizenFX.Core;
using Proline.CFXExtended.Core;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Proline.Resource.Framework;
using System.Threading.Tasks;
using Console = Proline.Resource.Console;
using Proline.ClassicOnline.CGameLogic;

namespace Proline.ClassicOnline.CNetConnection.Commands
{
    public class BuyRandomWeaponCommand : ResourceCommand
    {
        public BuyRandomWeaponCommand() : base("BuyRandomWeapon")
        {
        }

        protected override void OnCommandExecute(params object[] args)
        {
            if (CGameLogicAPI.GetCharacterBankBalance() > 250)
            {

                Array values = Enum.GetValues(typeof(WeaponHash));
                Random random = new Random();
                WeaponHash randomBar = (WeaponHash)values.GetValue(random.Next(values.Length));
                var ammo = random.Next(1, 250);
                Game.PlayerPed.Weapons.Give(randomBar, ammo, true, true);

                var id = "PlayerWeapon";
                CDataStream.CDataStreamAPI.CreateDataFile();
                CDataStream.CDataStreamAPI.AddDataFileValue("WeaponHash", randomBar);
                CDataStream.CDataStreamAPI.AddDataFileValue("WeaponAmmo", ammo);
                CDataStream.CDataStreamAPI.SaveDataFile(id);

                CGameLogicAPI.SubtractValueFromBankBalance(250);
            }
        }
    }
}
