using Proline.Resource.Framework;

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
