using CitizenFX.Core;
using Proline.ClassicOnline.CMissionManager.Internal;
using System;

namespace Proline.ClassicOnline.MissionManager
{
    public static partial class MissionAPIs
    {
        public static void TrackPoolObjectForMission(PoolObject obj)
        {
            try
            {
                if (!GetMissionFlag()) return;
                var instance = PoolObjectTracker.GetInstance();
                instance.TrackPoolObject(obj);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return;
        }
    }
}
