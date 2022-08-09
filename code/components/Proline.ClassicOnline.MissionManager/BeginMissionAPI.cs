using Proline.ClassicOnline.CMissionManager.Internal;
using System;

namespace Proline.ClassicOnline.MissionManager
{
    public static partial class MissionAPIs
    {
        public static bool BeginMission()
        {
            try
            {
                if (GetMissionFlag()) return false;
                var instance = PoolObjectTracker.GetInstance();
                if (instance.IsTrackingObjects())
                {
                    instance.DeleteAllPoolObjects();
                    instance.ClearPoolObjects();
                }
                SetMissionFlag(true);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return false;
        }
    }
}
