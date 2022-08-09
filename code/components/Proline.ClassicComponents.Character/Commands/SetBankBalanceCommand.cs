﻿using Proline.Resource.Framework;

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
