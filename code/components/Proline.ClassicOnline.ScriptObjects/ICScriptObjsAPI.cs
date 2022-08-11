using Proline.ClassicOnline.Common.Data;

namespace Proline.ClassicOnline.CScriptObjs
{
    public interface ICScriptObjsAPI
    {
        int[] GetEntityHandlesByTypes(EntityType type);
        CitizenFX.Core.Entity GetNeariestEntity(EntityType type);
    }
}