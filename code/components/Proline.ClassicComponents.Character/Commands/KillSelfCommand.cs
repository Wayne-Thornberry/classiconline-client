
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Proline.Resource.Framework;
using System.Threading.Tasks;
using Proline.ClassicOnline.CGameLogic;
using CitizenFX.Core;

namespace Proline.ClassicOnline.CGameLogic.Commands
{
    public class KillSelfCommand : ResourceCommand
    {
        public KillSelfCommand() : base("KillSelf")
        {
        }

        protected override void OnCommandExecute(params object[] args)
        {
            Game.PlayerPed.Kill(); 
        }
    }
}
