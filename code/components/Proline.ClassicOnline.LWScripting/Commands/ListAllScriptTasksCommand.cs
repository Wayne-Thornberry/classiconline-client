
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
    public class ListAllScriptTasksCommand : ResourceCommand
    {
        public ListAllScriptTasksCommand() : base("ListAllScriptTasks")
        {
        }

        protected override void OnCommandExecute(params object[] args)
        {
            var sm = ScriptTaskManager.GetInstance();
            foreach (var scriptTask in sm.GetAllScriptInstanceTasks())
            {
                Console.WriteLine(string.Format("Task Id {0}, Is Complete {1}, Status {2} ", scriptTask.Id, scriptTask.IsCompleted, scriptTask.Status));
            }
        }
    }
}
