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
                CDataStream.API.CreateDataFile();
                CDataStream.API.AddDataFileValue("WeaponHash", randomBar);
                CDataStream.API.AddDataFileValue("WeaponAmmo", ammo);
                CDataStream.API.SaveDataFile(id);

                CGameLogicAPI.SubtractValueFromBankBalance(250);
            }
        }
    }
}
