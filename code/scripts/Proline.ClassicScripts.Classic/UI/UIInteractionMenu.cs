using System.Threading;
using System.Threading.Tasks;
using CitizenFX.Core;
using Proline.ClassicOnline.CCoreSystem;
using Proline.ClassicOnline.CScreenRendering.Menus.MenuItems;
using Proline.ClassicOnline.CScreenRendering.Menus;

namespace Proline.ClassicOnline.SClassic.UI
{
    public class UIInteractionMenu
    {
        public UIInteractionMenu()
        {
        }

        public async Task Execute(object[] args, CancellationToken token)
        {
            var menu = new Menu("Test");
            MenuController.AddMenu(menu);
            var controller = new MenuController();
            menu.OpenMenu();
            while (!token.IsCancellationRequested)
            {
                await controller.Process();
                if (!menu.Visible)
                {
                    CCoreSystemAPI.MarkScriptAsNoLongerNeeded(this);
                }
                await BaseScript.Delay(0);
            }
        }
    }
}
