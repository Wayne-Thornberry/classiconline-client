using CitizenFX.Core;

namespace Proline.ClassicOnline.MissionManager
{
    public interface ICMissionManagerAPI
    {
        bool BeginMission();
        void EndMission();
        bool GetMissionFlag();
        bool IsInMissionVehicle();
        void SetMissionFlag(bool enable);
        void TrackPoolObjectForMission(PoolObject obj);
    }
}