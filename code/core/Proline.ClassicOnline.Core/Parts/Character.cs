using Proline.ClassicOnline.CGameLogic;
using Proline.ClassicOnline.Common.Data;

namespace Proline.ClassicOnline.Engine.Parts
{

    public static partial class EngineAPI
    {

        public static void SetPedLooks(int pedHandle, CharacterLooks looks)
        {
            var api = new CGameLogicAPI();
            api.SetPedLooks(pedHandle, looks);
        }

        public static void SetPedOutfit(string outfitName, int handle)
        {
            var api = new CGameLogicAPI();
            api.SetPedOutfit(outfitName, handle);
        }

        public static void AddValueToBankBalance(object payout)
        {
            var api = new CGameLogicAPI();
            api.AddValueToBankBalance(payout);
        }

        public static CharacterLooks GetPedLooks(int pedHandle)
        {
            var api = new CGameLogicAPI();
            return api.GetPedLooks(pedHandle);
        }

        public static CharacterStats GetChracterStats()
        {
            var api = new CGameLogicAPI();
            return api.GetCharacterStats();
        }

        public static void SetCharacter(PlayerCharacter character)
        {
            var api = new CGameLogicAPI();
            api.SetCharacter(character);
        }
        public static bool HasCharacter()
        {
            var api = new CGameLogicAPI();
            return api.HasCharacter();
        }

        public static void SetPedGender(int handle, char gender)
        {
            var api = new CGameLogicAPI();
            api.SetPedGender(handle, gender);
        }
    }
}
