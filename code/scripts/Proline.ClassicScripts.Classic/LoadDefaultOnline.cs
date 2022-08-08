using CitizenFX.Core;
using CitizenFX.Core.Native;
using Proline.ClassicOnline.CGameLogic;
using Proline.ClassicOnline.CGameLogic.Data;
using Proline.ClassicOnline.SClassic.Globals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Proline.ClassicOnline.SClassic
{
    public class LoadDefaultOnline
    {
        public async Task Execute(object[] args, CancellationToken token)
        {
            await Game.Player.ChangeModel(new Model(1885233650)); 
            if (!CDataStream.API.HasSaveLoaded())
            {
                PlayerCharacter character = CreateNewCharacter();
                CCoreSystem.CCoreSystemAPI.StartNewScript("LoadDefaultStats");
                while (CCoreSystem.CCoreSystemAPI.GetInstanceCountOfScript("LoadDefaultStats") > 0)
                {
                    await BaseScript.Delay(1);
                }
                CharacterGlobals.Character = character;
            }

            CGameLogic.CGameLogicAPI.SetPedOutfit("mp_m_defaultoutfit", Game.PlayerPed.Handle);
        }

        private static PlayerCharacter CreateNewCharacter()
        {
            var character = new PlayerCharacter(Game.PlayerPed.Handle);
            character.Stats = new CharacterStats();
            return character;
        }
    
    }
}
