using CitizenFX.Core;
using Newtonsoft.Json;
using Proline.ClassicOnline.CGameLogic;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Proline.Resource.Framework;
using System.Threading.Tasks;
using Console = Proline.Resource.Console;
using Proline.ClassicOnline.CShopCatalogue;

namespace Proline.ClassicOnline.CShopCatalogue.Commands
{
    public class BuyVehicleCommand : ResourceCommand
    {
        public BuyVehicleCommand() : base("BuyVehicle")
        {
        }

        protected override void OnCommandExecute(params object[] args)
        {
            if (args.Length > 0)
            {
                var vehicle = args[0].ToString();
                CShopCatalogueAPI.BuyVehicle(vehicle);
            }

        }
    }
}
