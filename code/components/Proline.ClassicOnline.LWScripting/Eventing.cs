using Proline.ClassicOnline.CCoreSystem.Internal;
using System;
using System.Linq;

namespace Proline.ClassicOnline.CCoreSystem
{
    public static partial class CCoreSystemAPI
    {
        public static void TriggerScriptEvent(string eventName, params object[] args)
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

        public static bool GetEventExitsts(object scriptInstance, string eventName)
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

        public static object[] GetEventData(object scriptInstance, string eventName)
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
