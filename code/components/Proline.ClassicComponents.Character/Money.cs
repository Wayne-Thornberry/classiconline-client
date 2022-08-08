using CitizenFX.Core;
using Proline.CFXExtended.Core;
using Proline.ClassicOnline.CDebugActions;
using Proline.ClassicOnline.GCharacter;
using Proline.ClassicOnline.CDataStream;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proline.ClassicOnline.MGame
{
    public static partial class MGameAPI
    { 
        public static void SetCharacterBankBalance(long value)
        {
            try
            {
                var character = CharacterGlobals.Character;
                character.BankBalance = value;
                var bankBalanceStat = MPStat.GetStat<long>("BANK_BALANCE");
                bankBalanceStat.SetValue(character.BankBalance);
                var id = "PlayerInfo";
                if (CDataStream.API.DoesDataFileExist(id))
                {
                    CDataStream.API.SelectDataFile(id);
                    if(API.DoesDataFileValueExist("BankBalance"))
                        CDataStream.API.SetDataFileValue("BankBalance", character.BankBalance);
                    else
                        CDataStream.API.AddDataFileValue("BankBalance", character.BankBalance);
                }
            }
            catch (Exception e)
            {
                CDebugActionsAPI.LogError(e);
            }
        }

        public static void AddValueToBankBalance(long value)
        {
            try
            {
                var character = CharacterGlobals.Character;
                character.BankBalance += value;
                var bankBalanceStat = MPStat.GetStat<long>("BANK_BALANCE");
                bankBalanceStat.SetValue(character.BankBalance);
                var id = "PlayerInfo";
                if (CDataStream.API.DoesDataFileExist(id))
                {
                    CDataStream.API.SelectDataFile(id);
                    if (API.DoesDataFileValueExist("BankBalance"))
                        CDataStream.API.SetDataFileValue("BankBalance", character.BankBalance);
                    else
                        CDataStream.API.AddDataFileValue("BankBalance", character.BankBalance);
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
                var character = CharacterGlobals.Character;
                character.BankBalance -= value;
                var bankBalanceStat = MPStat.GetStat<long>("BANK_BALANCE");
                bankBalanceStat.SetValue(character.BankBalance);
                var id = "PlayerInfo";
                if (CDataStream.API.DoesDataFileExist(id))
                {
                    CDataStream.API.SelectDataFile(id);
                    if (API.DoesDataFileValueExist("BankBalance"))
                        CDataStream.API.SetDataFileValue("BankBalance", character.BankBalance);
                    else
                        CDataStream.API.AddDataFileValue("BankBalance", character.BankBalance);
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
                var character = CharacterGlobals.Character;
                character.WalletBalance = value;
                var walletBalanceStat = MPStat.GetStat<long>("MP0_WALLET_BALANCE");
                walletBalanceStat.SetValue(character.WalletBalance);
                var id = "PlayerInfo";
                if (CDataStream.API.DoesDataFileExist(id))
                {
                    CDataStream.API.SelectDataFile(id);
                    if (API.DoesDataFileValueExist("WalletBalance"))
                        CDataStream.API.SetDataFileValue("WalletBalance", character.WalletBalance);
                    else
                        CDataStream.API.AddDataFileValue("WalletBalance", character.WalletBalance); 
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
                var character = CharacterGlobals.Character;
                character.WalletBalance += value;
                var walletBalanceStat = MPStat.GetStat<long>("MP0_WALLET_BALANCE");
                walletBalanceStat.SetValue(character.WalletBalance);
                var id = "PlayerInfo";
                if (CDataStream.API.DoesDataFileExist(id))
                {
                    CDataStream.API.SelectDataFile(id);
                    if (API.DoesDataFileValueExist("WalletBalance"))
                        CDataStream.API.SetDataFileValue("WalletBalance", character.WalletBalance);
                    else
                        CDataStream.API.AddDataFileValue("WalletBalance", character.WalletBalance);
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
                var character = CharacterGlobals.Character;
                character.WalletBalance -= value;
                var walletBalanceStat = MPStat.GetStat<long>("MP0_WALLET_BALANCE");
                walletBalanceStat.SetValue(character.WalletBalance);
                var id = "PlayerInfo";
                if (CDataStream.API.DoesDataFileExist(id))
                {
                    CDataStream.API.SelectDataFile(id);
                    if (API.DoesDataFileValueExist("WalletBalance"))
                        CDataStream.API.SetDataFileValue("WalletBalance", character.WalletBalance);
                    else
                        CDataStream.API.AddDataFileValue("WalletBalance", character.WalletBalance);
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
                var character = CharacterGlobals.Character;
                return character.WalletBalance; 
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
                var character = CharacterGlobals.Character;
                return character.BankBalance;

            }
            catch (Exception e)
            {
                CDebugActionsAPI.LogError(e);
            }
            return 0;
        }
    }
}
