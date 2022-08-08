﻿using CitizenFX.Core;
using Proline.ClassicOnline.CPoolObjects.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proline.ClassicOnline.CPoolObjects.Scripts
{
    public class InitSession
    {
        public async Task Execute()
        {
            var gc = new PoolObjectTracker();
            while (true)
            {
                var task = Task.Factory.StartNew(gc.Execute);
                await BaseScript.Delay(500);
            }
        }
    }
}
