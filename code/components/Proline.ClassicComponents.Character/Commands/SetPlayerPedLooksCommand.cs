using CitizenFX.Core;
using Proline.ClassicOnline.Common.Data;
using Proline.Resource.Framework;

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
                var api = new CGameLogicAPI();
                looks.Father = int.Parse(args[0].ToString());
                looks.Mother = int.Parse(args[1].ToString());
                looks.Resemblence = float.Parse(args[2].ToString());
                api.SetPedLooks(Game.PlayerPed.Handle, looks);
            }

        }
    }
}
