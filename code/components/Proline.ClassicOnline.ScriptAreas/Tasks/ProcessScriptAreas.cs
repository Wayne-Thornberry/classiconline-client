using CitizenFX.Core;
using CitizenFX.Core.Native;
using Newtonsoft.Json;

using Proline.Resource.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 
using Proline.ClassicOnline.CDataStream;
using Proline.CFXExtended.Core;
using Proline.Resource;
using Proline.ClassicOnline.CDebugActions;
using System.Reflection;
using Proline.ClassicOnline.CCoreSystem;
using Proline.Resource.IO;
using Proline.ClassicOnline.CPoolObjects;
using Proline.ClassicOnline.CScriptAreas.Entity;

namespace Proline.ClassicOnline.CScriptAreas.Tasks
{
    public class ProcessScriptAreas
    {
        private static Log _log = new Log();

        public ProcessScriptAreas()
        {
        }


        public async Task Execute()
        {
            var instance = ScriptPositionManager.GetInstance();
            //return; 

            if (instance.HasScriptPositionPairs())
            {
                foreach (var positionsPair in instance.GetScriptPositionsPairs())
                {
                    var vector = new Vector3(positionsPair.X, positionsPair.Y, positionsPair.Z);
                    if (World.GetDistance(vector, Game.PlayerPed.Position) < 10f && !PosBlacklist.Contains(positionsPair))
                    {
                        Resource.Console.WriteLine(_log.Debug("In range"));
                        CCoreSystemAPI.StartNewScript(positionsPair.ScriptName, vector);
                        PosBlacklist.Add(positionsPair);
                    }
                    else if (World.GetDistance(vector, Game.PlayerPed.Position) > 10f && PosBlacklist.Contains(positionsPair))
                    {
                        PosBlacklist.Remove(positionsPair);
                    };
                }
            }
        }
    }
}