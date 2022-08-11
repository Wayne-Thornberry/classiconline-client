using Proline.ClassicOnline.CPoolObjects.Internal;

namespace Proline.ClassicOnline.CPoolObjects
{
    public class CPoolObjectsAPI : ICPoolObjectsAPI
    {
        public int[] GetAllExistingPoolObjects()
        {
            return PoolObjectManager.TrackedHandles;
        }
    }
}
