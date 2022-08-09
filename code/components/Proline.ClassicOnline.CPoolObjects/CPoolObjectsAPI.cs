using Proline.ClassicOnline.CPoolObjects.Internal;

namespace Proline.ClassicOnline.CPoolObjects
{
    public static class CPoolObjectsAPI
    {
        public static int[] GetAllExistingPoolObjects()
        {
            return PoolObjectManager.TrackedHandles;
        }
    }
}
