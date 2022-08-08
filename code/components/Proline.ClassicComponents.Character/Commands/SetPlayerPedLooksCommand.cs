using CitizenFX.Core;
using Newtonsoft.Json;
using Proline.ClassicOnline.CGameLogic;
using Proline.ClassicOnline.CGameLogic.Data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Proline.Resource.Framework;
using System.Threading.Tasks;
using Console = Proline.Resource.Console;
using Proline.ClassicOnline.CGameLogic;

namespace Proline.ClassicOnline.CGameLogic.Commands
{
    public class SetPlayerPedLooksCommand : ResourceCommand
    {
        public SetPlayerPedLooksCommand() : base("SetPlayerPedLooks")
        {
        }

        protected override void OnCommandExecute(params object[] args)
        {
            var looks = new CharacterLooks();
            if (args.Length == 3)
            {
                looks.Father = int.Parse(args[0].ToString());
                looks.Mother = int.Parse(args[1].ToString());
                looks.Resemblence = float.Parse(args[2].ToString());
                CGameLogicAPI.SetPedLooks(Game.PlayerPed.Handle, looks);
            }

        }
    }
}
