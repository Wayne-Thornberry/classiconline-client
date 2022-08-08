using CitizenFX.Core;
using Newtonsoft.Json;
using Proline.ClassicOnline.CGameLogic;

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
    public class SetBankBalanceCommand : ResourceCommand
    {
        public SetBankBalanceCommand() : base("SetBankBalance")
        {
        }

        protected override void OnCommandExecute(params object[] args)
        {
            if (args.Length > 0)
            {
                long.TryParse(args[0].ToString(), out var value);
                CGameLogicAPI.SetCharacterBankBalance(value);
            }

        }
    }
}
