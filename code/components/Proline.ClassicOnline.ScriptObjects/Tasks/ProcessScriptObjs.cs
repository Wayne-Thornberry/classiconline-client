using CitizenFX.Core;
using CitizenFX.Core.Native;
using Proline.ClassicOnline.CCoreSystem;
using Proline.ClassicOnline.CPoolObjects;
using Proline.ClassicOnline.CScriptObjs.Entity;
using Proline.Resource.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proline.ClassicOnline.CScriptObjs.Tasks
{
    public class ProcessScriptObjs
    {
        private static Log _log = new Log();

        public ProcessScriptObjs()
        {
            _sm = ScriptObjectManager.GetInstance();
            _oldList = new List<int>();
        }


        private ScriptObjectManager _sm;
        private List<int> _oldList;

        public async Task Execute()
        {
            var currentHandles = CPoolObjectsAPI.GetAllExistingPoolObjects();
            foreach (var handle in currentHandles)
            {
                if (!API.DoesEntityExist(handle)) continue;
                var modelHash = API.GetEntityModel(handle);
                if (!_sm.ContainsSO(handle) && _sm.ContainsKey(modelHash))
                {
                    _log.Debug(handle + " Oh boy, we found a matching script object with that model hash from that handle, time to track it");
                    _sm.AddSO(handle, new ScriptObject()
                    {
                        Data = _sm.Get(modelHash),
                        Handle = handle,
                        State = 0,
                    });
                }
            }
            var newLsit = new List<int>(currentHandles);
            var removed = newLsit.Except(_oldList).ToArray();

            foreach (var handle in removed)
            {
                if (API.DoesEntityExist(handle)) continue;
                var modelHash = API.GetEntityModel(handle);
                if (!_sm.ContainsKey(modelHash)) continue;
                if (_sm.ContainsKey(handle))
                    _sm.Remove(handle);
            }
            _oldList = newLsit;

            ProcessScriptObjects();

        }



        private void ProcessScriptObjects()
        {
            var values = _sm.GetValues();
            if (values == null)
                return;
            var quew = new Queue<ScriptObject>(values);
            while (quew.Count > 0)
            {
                var so = quew.Dequeue();
                ProcessScriptObject(so);
            }
        }

        private void ProcessScriptObject(ScriptObject so)
        {
            if (!API.DoesEntityExist(so.Handle))
            {
                _sm.Remove(so.Handle);
                return;
            }
            var entity = CitizenFX.Core.Entity.FromHandle(so.Handle);
            foreach (var item in so.Data)
            {
                if (IsEntityWithinActivationRange(entity, Game.PlayerPed, item.ActivationRange) && so.State == 0)
                {
                    _log.Debug(so.Handle + " Player is within range here, we should start the script and no longer track this for processing");
                    CCoreSystemAPI.StartNewScript(item.ScriptName, so.Handle);
                    so.State = 1;
                    _sm.Remove(so.Handle);
                    return;
                }
            }
        }


        private bool IsEntityWithinActivationRange(CitizenFX.Core.Entity entity, CitizenFX.Core.Entity playerPed, float activationRange)
        {
            var pos = Game.PlayerPed.Position;
            var pos2 = entity.Position;
            return API.Vdist2(pos.X, pos.Y, pos.Z, pos2.X, pos2.Y, pos2.Z) <= activationRange;
        }



    }
}