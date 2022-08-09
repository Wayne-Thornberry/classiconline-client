using Newtonsoft.Json;
using Proline.ClassicOnline.CDebugActions;
using Proline.ClassicOnline.CShopCatalogue.Internal;

using Proline.Resource.IO;
using System.Threading.Tasks;

namespace Proline.ClassicOnline.CShopCatalogue.Scripts
{
    internal class InitCore
    {
        public async Task Execute()
        {
            var data = ResourceFile.Load("data/catalogue/catalogue-vehicles.json");
            CDebugActionsAPI.LogDebug(data);
            CatalougeManager.GetInstance().Register("VehicleCatalouge", JsonConvert.DeserializeObject<VehicleCatalouge>(data.Load()));
        }
    }
}
