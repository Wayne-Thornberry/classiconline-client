using Proline.CFXExtended.Core;
using Proline.ClassicOnline.CDataStream;
using Proline.ClassicOnline.CDebugActions;
using Proline.ClassicOnline.CGameLogic.Internal;
using Proline.ClassicOnline.Engine.Parts;
using System;

namespace Proline.ClassicOnline.CGameLogic
{
    public static partial class CGameLogicAPI
    {
        public static void SetCharacterBankBalance(long value)
        {
            try
            {
                Character.BankBalance = value;
                var bankBalanceStat = MPStat.GetStat<long>("BANK_BALANCE");
                bankBalanceStat.SetValue(Character.BankBalance);
                var id = "PlayerInfo";
                if (EngineAPI.DoesDataFileExist(id))
                {
                    EngineAPI.SelectDataFile(id);
                    if (EngineAPI.DoesDataFileValueExist("BankBalance"))
                        EngineAPI.SetDataFileValue("BankBalance", Character.BankBalance);
                    else
                        EngineAPI.AddDataFileValue("BankBalance", Character.BankBalance);
                }
            }
            catch (Exception e)
            {
                EngineAPI.LogError(e);
            }
        }

        public static long GetCharacterMaxWalletBalance()
        {
            return Character.MaxWalletCapacity;
        }
        public static void SetCharacterMaxWalletBalance(int value)
        {
            Character.MaxWalletCapacity = value;
        }


        public static bool HasBankBalance(long price)
        {
            return Character.BankBalance > price;
        }



        public static void AddValueToBankBalance(long value)
        {
            try
            {

                Character.BankBalance += value;
                var bankBalanceStat = MPStat.GetStat<long>("BANK_BALANCE");
                bankBalanceStat.SetValue(Character.BankBalance);
                var id = "PlayerInfo";
                if (EngineAPI.DoesDataFileExist(id))
                {
                    EngineAPI.SelectDataFile(id);
                    if (EngineAPI.DoesDataFileValueExist("BankBalance"))
                        EngineAPI.SetDataFileValue("BankBalance", Character.BankBalance);
                    else
                        EngineAPI.AddDataFileValue("BankBalance", Character.BankBalance);
                }
            }
            catch (Exception e)
            {
                EngineAPI.LogError(e);
            }
        }


        public static void SubtractValueFromBankBalance(long value)
        {
            try
            {

                Character.BankBalance -= value;
                var bankBalanceStat = MPStat.GetStat<long>("BANK_BALANCE");
                bankBalanceStat.SetValue(Character.BankBalance);
                var id = "PlayerInfo";
                if (EngineAPI.DoesDataFileExist(id))
                {
                    EngineAPI.SelectDataFile(id);
                    if (EngineAPI.DoesDataFileValueExist("BankBalance"))
                        EngineAPI.SetDataFileValue("BankBalance", Character.BankBalance);
                    else
                        EngineAPI.AddDataFileValue("BankBalance", Character.BankBalance);
                }
            }
            catch (Exception e)
            {
                EngineAPI.LogError(e);
            }
        }

        public static void SetCharacterWalletBalance(long value)
        {
            try
            {

                Character.WalletBalance = value;
                var walletBalanceStat = MPStat.GetStat<long>("MP0_WALLET_BALANCE");
                walletBalanceStat.SetValue(Character.WalletBalance);
                var id = "PlayerInfo";
                if (EngineAPI.DoesDataFileExist(id))
                {
                    EngineAPI.SelectDataFile(id);
                    if (EngineAPI.DoesDataFileValueExist("WalletBalance"))
                        EngineAPI.SetDataFileValue("WalletBalance", Character.WalletBalance);
                    else
                        EngineAPI.AddDataFileValue("WalletBalance", Character.WalletBalance);
                }
            }
            catch (Exception e)
            {
                EngineAPI.LogError(e);
            }
        }

        public static void AddValueToWalletBalance(long value)
        {
            try
            {

                Character.WalletBalance += value;
                var walletBalanceStat = MPStat.GetStat<long>("MP0_WALLET_BALANCE");
                walletBalanceStat.SetValue(Character.WalletBalance);
                var id = "PlayerInfo";
                if (EngineAPI.DoesDataFileExist(id))
                {
                    EngineAPI.SelectDataFile(id);
                    if (EngineAPI.DoesDataFileValueExist("WalletBalance"))
                        EngineAPI.SetDataFileValue("WalletBalance", Character.WalletBalance);
                    else
                        EngineAPI.AddDataFileValue("WalletBalance", Character.WalletBalance);
                }
            }
            catch (Exception e)
            {
                EngineAPI.LogError(e);
            }
        }

        public static void SubtractValueFromWalletBalance(long value)
        {
            try
            {

                Character.WalletBalance -= value;
                var walletBalanceStat = MPStat.GetStat<long>("MP0_WALLET_BALANCE");
                walletBalanceStat.SetValue(Character.WalletBalance);
                var id = "PlayerInfo";
                if (EngineAPI.DoesDataFileExist(id))
                {
                    EngineAPI.SelectDataFile(id);
                    if (EngineAPI.DoesDataFileValueExist("WalletBalance"))
                        EngineAPI.SetDataFileValue("WalletBalance", Character.WalletBalance);
                    else
                        EngineAPI.AddDataFileValue("WalletBalance", Character.WalletBalance);
                }
            }
            catch (Exception e)
            {
                EngineAPI.LogError(e);
            }
        }


        public static long GetCharacterWalletBalance()
        {
            try
            {
                return Character.WalletBalance;
            }
            catch (Exception e)
            {
                EngineAPI.LogError(e);
            }
            return 0;
        }

        public static long GetCharacterBankBalance()
        {
            try
            {

                return Character.BankBalance;

            }
            catch (Exception e)
            {
                EngineAPI.LogError(e);
            }
            return 0;
        }
    }
}
