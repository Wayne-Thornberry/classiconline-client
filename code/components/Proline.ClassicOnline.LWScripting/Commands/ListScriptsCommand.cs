using CitizenFX.Core;
using CitizenFX.Core.Native;

using System;
using System.Collections.Generic;
using System.Linq;
using Proline.Resource.Framework;
using System.Text;
using System.Threading.Tasks;
using Console = Proline.Resource.Console;
using Proline.ClassicOnline.CCoreSystem.Internal;

namespace Proline.ClassicOnline.CCoreSystem.Commands
{
    public class ListScriptsCommand : ResourceCommand
    {
        public ListScriptsCommand() : base("ListScripts")
        {
        }

        protected override void OnCommandExecute(params object[] args)
        {
            var sm = ScriptTypeLibrary.GetInstance();
            foreach (var item in sm.Keys)
            {
                Console.WriteLine(item);
            }
        }
    }
}
