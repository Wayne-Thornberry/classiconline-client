using Proline.ClassicOnline.CCoreSystem;
using Proline.ClassicOnline.CCoreSystem.Events;
using Proline.ClassicOnline.CCoreSystem.Internal;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proline.ClassicOnline.CCoreSystem.Scripts
{
    public class InitSession
    {
        public async Task Execute()
        {
            CCoreSystemAPI.StartNewScript("Main");
        }
    }
}
