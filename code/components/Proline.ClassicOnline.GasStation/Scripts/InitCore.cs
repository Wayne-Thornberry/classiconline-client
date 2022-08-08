using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using CitizenFX.Core;
using Newtonsoft.Json;
using Proline.ClassicOnline.CWorldObjects.Data; 
using Proline.Resource.IO;
using Proline.ClassicOnline.CWorldObjects.Data.Ownership;
using Proline.ClassicOnline.CWorldObjects.Internal;
using Proline.ClassicOnline.CDebugActions;

namespace Proline.ClassicOnline.CWorldObjects.Scripts
{
    public class InitCore
    {


        public async Task Execute()
        {
            try
            {
                var apartmentData = ResourceFile.Load("data/world/apt_properties.json");
                var pm = PropertyManager.GetInstance();
                var apartmentInteriors = JsonConvert.DeserializeObject<List<PropertyMetadata>>(apartmentData.Load());
                foreach (var item in apartmentInteriors)
                {
                    pm.Register(item.Id, item);
                }
            }
            catch (System.Exception e)
            {
                CDebugActionsAPI.LogDebug(e);
            }

        }


    }
}
