using CitizenFX.Core;
using Proline.ClassicOnline.CGameLogic;
using Proline.Resource.Framework;

namespace Proline.ClassicOnline.CNetConnection.Commands
{
    public class BuyRandomOutfitCommand : ResourceCommand
    {
        public BuyRandomOutfitCommand() : base("BuyRandomOutfit")
        {
        }

        protected override void OnCommandExecute(params object[] args)
        {
            if (CGameLogicAPI.GetCharacterBankBalance() > 250)
            {
                Game.Player.Character.Style.RandomizeOutfit();
                Game.Player.Character.Style.RandomizeProps();
                CGameLogicAPI.SetCharacterBankBalance(250);
            }
        }
    }
}
