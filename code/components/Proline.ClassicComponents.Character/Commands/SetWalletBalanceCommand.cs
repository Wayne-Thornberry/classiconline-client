
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Proline.Resource.Framework;
using System.Threading.Tasks;
using Proline.ClassicOnline.MGame;

namespace Proline.ClassicOnline.CGameLogic.Commands
{
    public class SetWalletBalanceCommand : ResourceCommand
    {
        public SetWalletBalanceCommand() : base("SetWalletBalance")
        {
        }

        protected override void OnCommandExecute(params object[] args)
        {
            if (args.Length > 0)
            {
                long.TryParse(args[0].ToString(), out var value);
                MGameAPI.SetCharacterWalletBalance(value);
            }

        }
    }
}
