using CitizenFX.Core;
using CitizenFX.Core.Native;
using Proline.ClassicOnline.CCoreSystem;
using Proline.ClassicOnline.CGameLogic;
using Proline.ClassicOnline.CScriptBrain;
using Proline.ClassicOnline.CScriptBrain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Proline.ClassicOnline.SClassic
{
    public class MoneyBagController
    {
        public async Task Execute(object[] args, CancellationToken token)
        {
            // Dupe protection
            if (CCoreSystemAPI.GetInstanceCountOfScript("MoneyBagController") > 1)
                return; 

            while (!token.IsCancellationRequested)
            {
                if(CCoreSystemAPI.GetEventExitsts(this, "CEventNetworkPlayerCollectedPickup"))
                {
                    var test = CCoreSystemAPI.GetEventData(this, "CEventNetworkPlayerCollectedPickup");
                    foreach (var item in test)
                    {
                        CDebugActions.CDebugActionsAPI.LogDebug(item);
                    }
                    var id = int.Parse(test[4].ToString());
                    var money = int.Parse(test[3].ToString());
                    if (id == API.GetHashKey("xm_prop_x17_bag_01b"))
                    {
                        CGameLogicAPI.AddValueToWalletBalance(money);
                        API.SetPedPropIndex(Game.PlayerPed.Handle, 9, 1, 0, true);
                    }
                }
                await BaseScript.Delay(0);
            }
        }
    }
}
