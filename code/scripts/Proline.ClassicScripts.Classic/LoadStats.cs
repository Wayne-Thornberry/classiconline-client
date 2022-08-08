using Proline.CFXExtended.Core;
using Proline.ClassicOnline.CDebugActions;
using Proline.ClassicOnline.CGameLogic; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Proline.ClassicOnline.SClassic
{
    public class LoadStats
    {
        public async Task Execute(object[] args, CancellationToken token)
        { 
            if(CGameLogicAPI.HasCharacter())
            {
                var stats = CGameLogicAPI.GetChracterStats();
                if (stats == null)
                    return;
                var walletBalanceStat = MPStat.GetStat<long>("MP0_WALLET_BALANCE");
                var bankBalanceStat = MPStat.GetStat<long>("BANK_BALANCE");


                var walletBalance = stats.GetStat("WALLET_BALANCE");
                var bankBalance = stats.GetStat("BANK_BALANCE");

                CDebugActionsAPI.LogDebug(walletBalance);
                CDebugActionsAPI.LogDebug(bankBalance);

                walletBalanceStat.SetValue(Convert.ToInt64(CGameLogicAPI.GetCharacterWalletBalance()));
                bankBalanceStat.SetValue(Convert.ToInt64(CGameLogicAPI.GetCharacterBankBalance()));
            }
        }
    }
}
