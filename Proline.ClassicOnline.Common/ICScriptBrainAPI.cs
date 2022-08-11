using Proline.ClassicOnline.Common.Data; 

namespace Proline.ClassicOnline.Common
{
    public interface ICScriptBrainAPI
    {
        int[] GetEntityHandlesByTypes(EntityType type);
        CitizenFX.Core.Entity GetNeariestEntity(EntityType type);
    }
}