using CitizenFX.Core;
using Proline.ClassicOnline.CGameLogic;
using Proline.ClassicOnline.CGameLogic.Data;
using Proline.ClassicOnline.Engine.Parts;
using System.Threading;
using System.Threading.Tasks;

namespace Proline.ClassicOnline.SClassic
{
    public class LoadDefaultOnline
    {
        public async Task Execute(object[] args, CancellationToken token)
        {
            await Game.Player.ChangeModel(new Model(1885233650));
            if (!EngineAPI.HasSaveLoaded())
            {
                PlayerCharacter character = CreateNewCharacter();
                EngineAPI.StartNewScript("LoadDefaultStats");
                while (EngineAPI.GetInstanceCountOfScript("LoadDefaultStats") > 0)
                {
                    await BaseScript.Delay(1);
                }
                EngineAPI.SetCharacter(character);
            }

            EngineAPI.SetPedOutfit("mp_m_defaultoutfit", Game.PlayerPed.Handle);
        }

        private static PlayerCharacter CreateNewCharacter()
        {
            var character = new PlayerCharacter(Game.PlayerPed.Handle);
            character.Stats = new CharacterStats();
            return character;
        }

    }
}
