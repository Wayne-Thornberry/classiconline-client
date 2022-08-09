using Proline.ClassicOnline.CMissionManager.Internal;
using System;

namespace Proline.ClassicOnline.MissionManager
{
    public static partial class MissionAPIs
    {
        public static void EndMission()
        {
            try
            {
                if (!GetMissionFlag()) return;
                var instance = PoolObjectTracker.GetInstance();
                if (instance.IsTrackingObjects())
                {
                    instance.DeleteAllPoolObjects();
                    instance.ClearPoolObjects();
                }
                SetMissionFlag(false);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
