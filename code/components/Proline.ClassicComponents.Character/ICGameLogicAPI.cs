using CitizenFX.Core;
using Proline.ClassicOnline.Common.Data;

namespace Proline.ClassicOnline.CGameLogic
{
    public interface ICGameLogicAPI
    {
        void AddValueToBankBalance(long value);
        void AddValueToBankBalance(object payout);
        void AddValueToWalletBalance(long value);
        void DeletePersonalVehicle();
        long GetCharacterBankBalance();
        long GetCharacterMaxWalletBalance();
        long GetCharacterWalletBalance();
        CharacterStats GetCharacterStats();
        CharacterLooks GetPedLooks(int pedHandle);
        Entity GetPersonalVehicle();
        bool HasBankBalance(long price);
        bool HasCharacter();
        bool IsInPersonalVehicle();
        void SetCharacter(PlayerCharacter character);
        void SetCharacterBankBalance(long value);
        void SetCharacterMaxWalletBalance(int value);
        void SetCharacterPersonalVehicle(int handle);
        void SetCharacterWalletBalance(long value);
        void SetPedGender(int handle, char gender);
        void SetPedLooks(int pedHandle, CharacterLooks looks);
        void SetPedOutfit(string outfitName, int handle);
        void SubtractValueFromBankBalance(long value);
        void SubtractValueFromWalletBalance(long value);
    }
}