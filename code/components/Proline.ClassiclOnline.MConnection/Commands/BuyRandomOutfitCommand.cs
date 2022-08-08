using CitizenFX.Core;
using Newtonsoft.Json;
using Proline.CFXExtended.Core;
using Proline.ClassicOnline.MGame;
using Proline.Resource.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = Proline.Resource.Console;

namespace Proline.ClassicOnline.CNetConnection.Commands
{
    public class BuyRandomOutfitCommand : ResourceCommand
    {
        public BuyRandomOutfitCommand() : base("BuyRandomOutfit")
        {
        }

        protected override void OnCommandExecute(params object[] args)
        {
            if (MGameAPI.GetCharacterBankBalance() > 250)
            {
                Game.Player.Character.Style.RandomizeOutfit();
                Game.Player.Character.Style.RandomizeProps();
                MGameAPI.SetCharacterBankBalance(250);
            }
        }
    }
}
