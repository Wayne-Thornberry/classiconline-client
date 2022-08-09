﻿using CitizenFX.Core;
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
        private bool _updated;

        public async Task Execute(object[] args, CancellationToken token)
        {
            // Dupe protection
            if (CCoreSystemAPI.GetInstanceCountOfScript("MoneyBagController") > 1)
                return; 

            if(CGameLogicAPI.GetCharacterWalletBalance() > CGameLogicAPI.GetCharacterMaxWalletBalance())
            {
                //GiveMoneyBag();
            }

            while (!token.IsCancellationRequested)
            {
                if(CCoreSystemAPI.GetEventExitsts(this, "CEventNetworkPlayerCollectedAmbientPickup"))
                {
                    var test = CCoreSystemAPI.GetEventData(this, "CEventNetworkPlayerCollectedAmbientPickup");
                    foreach (var item in test)
                    {
                        CDebugActions.CDebugActionsAPI.LogDebug(item);
                    }
                    var id = int.Parse(test[3].ToString());
                    var money = int.Parse(test[1].ToString());
                    if (id == API.GetHashKey("xm_prop_x17_bag_01b"))
                    {
                        if (API.GetPedDrawableVariation(Game.PlayerPed.Handle, 5) != 45)
                        {
                            GiveMoneyBag();
                        }
                        CGameLogicAPI.AddValueToWalletBalance(money);
                    }
                }

                if (CGameLogicAPI.GetCharacterWalletBalance() > CGameLogicAPI.GetCharacterMaxWalletBalance())
                {
                    var _value = (int)(CGameLogicAPI.GetCharacterWalletBalance() - CGameLogicAPI.GetCharacterMaxWalletBalance());
                    CGameLogicAPI.SubtractValueFromWalletBalance(_value);
                    var pickup = await World.CreateAmbientPickup(PickupType.MoneyDepBag, Game.PlayerPed.Position + (Game.PlayerPed.ForwardVector * 2), new Model("xm_prop_x17_bag_01b"), _value);
                    pickup.AttachBlip();
                    pickup.IsPersistent = true; 
                }

                if (API.GetPedDrawableVariation(Game.PlayerPed.Handle, 5) == 45 && !_updated)
                { 
                    CGameLogicAPI.SetCharacterMaxWalletBalance(1000000);
                    _updated = true;
                }
                else if (API.GetPedDrawableVariation(Game.PlayerPed.Handle, 5) != 45 && _updated)
                {
                    CGameLogicAPI.SetCharacterMaxWalletBalance(1000);
                    _updated = false;
                }

                await BaseScript.Delay(0);
            }
        }

        private void GiveMoneyBag()
        {
            API.SetPedComponentVariation(Game.PlayerPed.Handle, 5, 45, 0, 0);
        }
    }
}