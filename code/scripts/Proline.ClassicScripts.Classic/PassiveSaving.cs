using CitizenFX.Core;
using CitizenFX.Core.UI;
using Newtonsoft.Json;
using Proline.ClassicOnline.CGameLogic;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Proline.CFXExtended.Core;
using CitizenFX.Core.Native;
using Proline.ClassicOnline.CCoreSystem;

namespace Proline.ClassicOnline.SClassic
{
    public class PassiveSaving
    {

        public async Task Execute(object[] args, CancellationToken token)
        {
            var nextSaveTime = DateTime.UtcNow.AddMinutes(1);
            while (!token.IsCancellationRequested)
            {
                if (DateTime.UtcNow > nextSaveTime)
                {
                    var id = "PlayerInfo";
                    if (CDataStream.CDataStreamAPI.DoesDataFileExist(id))
                    {
                        CDataStream.CDataStreamAPI.SelectDataFile(id);
                        CDataStream.CDataStreamAPI.SetDataFileValue("PlayerPosition", JsonConvert.SerializeObject(Game.PlayerPed.Position));
                    }
                    CCoreSystemAPI.StartNewScript("SaveNow");
                    while (CCoreSystemAPI.GetInstanceCountOfScript("SaveNow") > 0)
                    {
                        await BaseScript.Delay(1);
                    }
                    nextSaveTime = DateTime.UtcNow.AddMinutes(1);
                }
                await BaseScript.Delay(0);
            }

        }
    }
}
