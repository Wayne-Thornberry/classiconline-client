﻿using CitizenFX.Core;
using Newtonsoft.Json;
using Proline.ClassicOnline.CCoreSystem;
using System;
using System.Threading;
using System.Threading.Tasks;

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
