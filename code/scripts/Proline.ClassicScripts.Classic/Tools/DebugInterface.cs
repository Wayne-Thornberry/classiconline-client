using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using Proline.ClassicOnline.CScreenRendering;
using Proline.ClassicOnline.CDebugActions;
using Proline.ClassicOnline.CGameRendering;

namespace Proline.ClassicOnline.SClassic.Tools
{
    public class DebugInterface
    {
        private List<int> _handles;

        public DebugInterface()
        {
            _handles = new List<int>();
        }


        public async Task Execute(object[] args, CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                var t = Game.PlayerPed.Position.ToString() + "H:" + Game.PlayerPed.Heading + "\n"
                   + Game.PlayerPed.Model.Hash + "\n"
                   + Game.PlayerPed.Health + "\n"
                   + Game.PlayerPed.Handle + "\n" +
                   _handles.Count + " Entities in the world ";
                CScreenRenderingAPI.DrawDebugText2D(t, new PointF(0.01f, 0.05f), 0.3f, 0);
                await BaseScript.Delay(0);
            }
        }
    }
}
