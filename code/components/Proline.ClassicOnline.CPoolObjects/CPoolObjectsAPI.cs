using CitizenFX.Core;
using CitizenFX.Core.Native;
using Proline.ClassicOnline.CPoolObjects.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
