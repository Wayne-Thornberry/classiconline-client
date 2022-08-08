﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Proline.Resource.Framework;
using System.Threading.Tasks;
using Console = Proline.Resource.Console;
using Proline.ClassicOnline.CCoreSystem.Internal;

namespace Proline.ClassicOnline.CCoreSystem.Commands
{
    public class ListActiveScriptsCommand : ResourceCommand
    {
        public ListActiveScriptsCommand() : base("ListScriptTasks")
        {
        }

        protected override void OnCommandExecute(params object[] args)
        {
            var sm = ListOfLiveScripts.GetInstance();
            foreach (var script in sm)
            {
                var instances = sm.Where(e => e.Name.Equals(script.Name));
                var count = instances.Count();
                Console.WriteLine(string.Format("Script: {0} Instances: {1}", script.Name, count));
                foreach (var instance in instances)
                {
                    Console.WriteLine(string.Format("-GUID: {0}", script.InstanceId));
                    var scriptTask = script.ExecutionTask;
                    Console.WriteLine(string.Format("-Task Id {0}, Is Complete {1}, Status {2} ", scriptTask.Id, scriptTask.IsCompleted, scriptTask.Status));
                }
            }
        }
    }
}
