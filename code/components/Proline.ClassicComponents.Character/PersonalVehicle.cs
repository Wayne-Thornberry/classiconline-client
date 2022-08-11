using CitizenFX.Core;
using Proline.ClassicOnline.CDebugActions;
using Proline.ClassicOnline.CGameLogic.Data;
using Proline.ClassicOnline.CGameLogic.Internal;
using System;

namespace Proline.ClassicOnline.CGameLogic
{
    public static partial class CGameLogicAPI
    {
        public static bool IsInPersonalVehicle()
        {
            var api = new CDebugActionsAPI();
            try
            {
                if (Character.PersonalVehicle == null)
                    return false;
                return Game.PlayerPed.IsInVehicle() && Game.PlayerPed.CurrentVehicle == Character.PersonalVehicle;
            }
            catch (Exception e)
            {
                api.LogError(e);
            }
            return false;
        }
        public static Entity GetPersonalVehicle()
        {
            return Character.PersonalVehicle;
        }

        public static void DeletePersonalVehicle()
        {
            foreach (var item in Character.PersonalVehicle.AttachedBlips)
            {
                item.Delete();
            }
            Character.PersonalVehicle.IsPersistent = false;
            Character.PersonalVehicle.Delete();
        }


        public static void SetCharacterPersonalVehicle(int handle)
        {
            Character.PersonalVehicle = new CharacterPersonalVehicle(handle);
        }
    }
}
