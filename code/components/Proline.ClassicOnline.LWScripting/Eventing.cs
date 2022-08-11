using Proline.ClassicOnline.CCoreSystem.Internal;
using Proline.ClassicOnline.CCoreSystem.Parts;
using System;
using System.Linq;

namespace Proline.ClassicOnline.CCoreSystem
{
    public partial class CCoreSystemAPI : ICCoreSystem
    {
        public void TriggerScriptEvent(string eventName, params object[] args)
        {
            try
            {
                var sm = ListOfLiveScripts.GetInstance();
                foreach (var item in sm)
                {
                    item.EnqueueEvent(eventName, args);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public bool GetEventExitsts(object scriptInstance, string eventName)
        {
            try
            {
                var sm = ListOfLiveScripts.GetInstance();
                var script = sm.FirstOrDefault(e => e.Instance == scriptInstance);
                return script.HasEvent(eventName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return false;
        }

        public object[] GetEventData(object scriptInstance, string eventName)
        {
            try
            {
                var sm = ListOfLiveScripts.GetInstance();
                var script = sm.FirstOrDefault(e => e.Instance == scriptInstance);
                return script.DequeueEvent(eventName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return new object[0];
        }
    }
}
