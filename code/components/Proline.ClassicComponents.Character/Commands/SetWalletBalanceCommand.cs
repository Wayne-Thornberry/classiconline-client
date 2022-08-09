using Proline.Resource.Framework;

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
                CGameLogicAPI.SetCharacterWalletBalance(value);
            }

        }
    }
}
