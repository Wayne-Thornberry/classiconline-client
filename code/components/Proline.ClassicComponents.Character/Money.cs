using Proline.CFXExtended.Core;
using Proline.ClassicOnline.CDataStream;
using Proline.ClassicOnline.CDebugActions;
using Proline.ClassicOnline.CGameLogic.Internal;
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
                if (CDataStream.CDataStreamAPI.DoesDataFileExist(id))
                {
                    CDataStream.CDataStreamAPI.SelectDataFile(id);
                    if (CDataStreamAPI.DoesDataFileValueExist("BankBalance"))
                        CDataStream.CDataStreamAPI.SetDataFileValue("BankBalance", Character.BankBalance);
                    else
                        CDataStream.CDataStreamAPI.AddDataFileValue("BankBalance", Character.BankBalance);
                }
            }
            catch (Exception e)
            {
                CDebugActionsAPI.LogError(e);
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
                if (CDataStream.CDataStreamAPI.DoesDataFileExist(id))
                {
                    CDataStream.CDataStreamAPI.SelectDataFile(id);
                    if (CDataStreamAPI.DoesDataFileValueExist("BankBalance"))
                        CDataStream.CDataStreamAPI.SetDataFileValue("BankBalance", Character.BankBalance);
                    else
                        CDataStream.CDataStreamAPI.AddDataFileValue("BankBalance", Character.BankBalance);
                }
            }
            catch (Exception e)
            {
                CDebugActionsAPI.LogError(e);
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
                if (CDataStream.CDataStreamAPI.DoesDataFileExist(id))
                {
                    CDataStream.CDataStreamAPI.SelectDataFile(id);
                    if (CDataStreamAPI.DoesDataFileValueExist("BankBalance"))
                        CDataStream.CDataStreamAPI.SetDataFileValue("BankBalance", Character.BankBalance);
                    else
                        CDataStream.CDataStreamAPI.AddDataFileValue("BankBalance", Character.BankBalance);
                }
            }
            catch (Exception e)
            {
                CDebugActionsAPI.LogError(e);
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
                if (CDataStream.CDataStreamAPI.DoesDataFileExist(id))
                {
                    CDataStream.CDataStreamAPI.SelectDataFile(id);
                    if (CDataStreamAPI.DoesDataFileValueExist("WalletBalance"))
                        CDataStream.CDataStreamAPI.SetDataFileValue("WalletBalance", Character.WalletBalance);
                    else
                        CDataStream.CDataStreamAPI.AddDataFileValue("WalletBalance", Character.WalletBalance);
                }
            }
            catch (Exception e)
            {
                CDebugActionsAPI.LogError(e);
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
                if (CDataStream.CDataStreamAPI.DoesDataFileExist(id))
                {
                    CDataStream.CDataStreamAPI.SelectDataFile(id);
                    if (CDataStreamAPI.DoesDataFileValueExist("WalletBalance"))
                        CDataStream.CDataStreamAPI.SetDataFileValue("WalletBalance", Character.WalletBalance);
                    else
                        CDataStream.CDataStreamAPI.AddDataFileValue("WalletBalance", Character.WalletBalance);
                }
            }
            catch (Exception e)
            {
                CDebugActionsAPI.LogError(e);
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
                if (CDataStream.CDataStreamAPI.DoesDataFileExist(id))
                {
                    CDataStream.CDataStreamAPI.SelectDataFile(id);
                    if (CDataStreamAPI.DoesDataFileValueExist("WalletBalance"))
                        CDataStream.CDataStreamAPI.SetDataFileValue("WalletBalance", Character.WalletBalance);
                    else
                        CDataStream.CDataStreamAPI.AddDataFileValue("WalletBalance", Character.WalletBalance);
                }
            }
            catch (Exception e)
            {
                CDebugActionsAPI.LogError(e);
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
                CDebugActionsAPI.LogError(e);
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
                CDebugActionsAPI.LogError(e);
            }
            return 0;
        }
    }
}
