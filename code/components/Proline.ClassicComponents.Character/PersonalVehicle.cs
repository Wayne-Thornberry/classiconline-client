using CitizenFX.Core;
using Proline.ClassicOnline.CDebugActions;
using Proline.ClassicOnline.CGameLogic;
using Proline.ClassicOnline.CGameLogic.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proline.ClassicOnline.CGameLogic
{
    public static partial class CGameLogicAPI
    {
        public static bool IsInPersonalVehicle()
        {
            try
            {
                if (Character.PersonalVehicle == null)
                    return false;
                return Game.PlayerPed.IsInVehicle() && Game.PlayerPed.CurrentVehicle == Character.PersonalVehicle;
            }
            catch (Exception e)
            {
                CDebugActionsAPI.LogError(e);
            }
            return false;
        }
    }
}
