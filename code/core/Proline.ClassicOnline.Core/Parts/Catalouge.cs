using Proline.ClassicOnline.CShopCatalogue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proline.ClassicOnline.Engine.Parts
{
    public static partial class EngineAPI
    {

        public static void BuyVehicle(string vehicleName)
        {
            var api = new CShopCatalogueAPI();
            api.BuyVehicle(vehicleName);
        }
    }
}
