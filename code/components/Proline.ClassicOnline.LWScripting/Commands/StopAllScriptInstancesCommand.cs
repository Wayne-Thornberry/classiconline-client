﻿using Proline.ClassicOnline.CCoreSystem.Internal;
using Proline.Resource.Framework;
using System.Linq;

namespace Proline.ClassicOnline.CCoreSystem.Commands
{
    public class StopAllScriptInstancesCommand : ResourceCommand
    {
        public StopAllScriptInstancesCommand() : base("StopAllScriptInstances")
        {
        }

        protected override void OnCommandExecute(params object[] args)
        {
            var sm = ListOfLiveScripts.GetInstance();
            if (args.Count() == 0)
            {
                foreach (var script in sm)
                {
                    script.Terminate();
                }
            }
            else
            {
                var scriptName = args[0].ToString();
                var scripts = sm.Where(e => e.Name.Equals(scriptName));
                foreach (var script in scripts)
                {
                    script.Terminate();
                }
            }
        }
    }
}
