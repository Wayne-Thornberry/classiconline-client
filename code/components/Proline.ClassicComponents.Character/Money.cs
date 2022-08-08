using CitizenFX.Core;
using Proline.CFXExtended.Core;
using Proline.ClassicOnline.CDebugActions;
using Proline.ClassicOnline.CGameLogic;
using Proline.ClassicOnline.CDataStream;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proline.ClassicOnline.CGameLogic.Internal;
using Proline.ClassicOnline.CGameLogic.Data;

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
                if (CDataStream.API.DoesDataFileExist(id))
                {
                    CDataStream.API.SelectDataFile(id);
                    if(API.DoesDataFileValueExist("BankBalance"))
                        CDataStream.API.SetDataFileValue("BankBalance", Character.BankBalance);
                    else
                        CDataStream.API.AddDataFileValue("BankBalance", Character.BankBalance);
                }
            }
            catch (Exception e)
            {
                CDebugActionsAPI.LogError(e);
            }
        }

        public static CharacterStats GetChracterStats()
        {
            return Character.PlayerCharacter.Stats;
        }

        public static void SetCharacter(PlayerCharacter character)
        {
            Character.PlayerCharacter = character;
        }

        public static bool HasBankBalance(long price)
        {
            return Character.BankBalance > price;
        }

        public static bool HasCharacter()
        {
            return true;
        }

        public static void DeletePersonalVehicle()
        {
            foreach (var item in Character.PersonalVehicle.AttachedBlips)
            {
                item.Delete();
            }
            Character.PersonalVehicle.IsPersistent = false;
            Character.PersonalVehicle.Delete();
        }

        public static void SetCharacterPersonalVehicle(int handle)
        {
            Character.PersonalVehicle = new CharacterPersonalVehicle(handle);
        }

        public static Entity GetPersonalVehicle()
        {
            return Character.PersonalVehicle;
        }

        public static void AddValueToBankBalance(long value)
        {
            try
            {
                
                Character.BankBalance += value;
                var bankBalanceStat = MPStat.GetStat<long>("BANK_BALANCE");
                bankBalanceStat.SetValue(Character.BankBalance);
                var id = "PlayerInfo";
                if (CDataStream.API.DoesDataFileExist(id))
                {
                    CDataStream.API.SelectDataFile(id);
                    if (API.DoesDataFileValueExist("BankBalance"))
                        CDataStream.API.SetDataFileValue("BankBalance", Character.BankBalance);
                    else
                        CDataStream.API.AddDataFileValue("BankBalance", Character.BankBalance);
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
                if (CDataStream.API.DoesDataFileExist(id))
                {
                    CDataStream.API.SelectDataFile(id);
                    if (API.DoesDataFileValueExist("BankBalance"))
                        CDataStream.API.SetDataFileValue("BankBalance", Character.BankBalance);
                    else
                        CDataStream.API.AddDataFileValue("BankBalance", Character.BankBalance);
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
                if (CDataStream.API.DoesDataFileExist(id))
                {
                    CDataStream.API.SelectDataFile(id);
                    if (API.DoesDataFileValueExist("WalletBalance"))
                        CDataStream.API.SetDataFileValue("WalletBalance", Character.WalletBalance);
                    else
                        CDataStream.API.AddDataFileValue("WalletBalance", Character.WalletBalance); 
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
                if (CDataStream.API.DoesDataFileExist(id))
                {
                    CDataStream.API.SelectDataFile(id);
                    if (API.DoesDataFileValueExist("WalletBalance"))
                        CDataStream.API.SetDataFileValue("WalletBalance", Character.WalletBalance);
                    else
                        CDataStream.API.AddDataFileValue("WalletBalance", Character.WalletBalance);
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
                if (CDataStream.API.DoesDataFileExist(id))
                {
                    CDataStream.API.SelectDataFile(id);
                    if (API.DoesDataFileValueExist("WalletBalance"))
                        CDataStream.API.SetDataFileValue("WalletBalance", Character.WalletBalance);
                    else
                        CDataStream.API.AddDataFileValue("WalletBalance", Character.WalletBalance);
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
