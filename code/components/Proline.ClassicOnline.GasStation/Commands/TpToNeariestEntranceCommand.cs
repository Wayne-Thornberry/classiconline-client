using CitizenFX.Core;
using Proline.Resource.Framework;

namespace Proline.ClassicOnline.CWorldObjects.Commands
{
    public class TpToNeariestEntrance : ResourceCommand
    {
        public TpToNeariestEntrance() : base("TpToNeariestEntrance")
        {
        }

        protected override void OnCommandExecute(params object[] args)
        {
            var entrance = WorldAPI.GetBuildingPosition(WorldAPI.GetNearestBuilding());
            Game.PlayerPed.Position = entrance;
        }
    }
}
