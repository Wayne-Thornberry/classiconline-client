using Newtonsoft.Json;
using Proline.ClassicOnline.CDataStream.Data;
using Proline.ClassicOnline.CDebugActions;
using Proline.Resource.IO;
using System;
using System.Collections.Generic;

namespace Proline.ClassicOnline.CDataStream
{
    public static partial class CDataStreamAPI
    {
        public static int GetNumOfAudioSamples()
        {
            try
            {
                var resourceData2 = ResourceFile.Load($"data/audio/fronend_usages.json");
                var buildingMetaData = JsonConvert.DeserializeObject<List<SoundExample>>(resourceData2.Load());
                return buildingMetaData.Count;
            }
            catch (Exception e)
            {
                CDebugActionsAPI.LogError(e.ToString());
            }
            return 0;
        }

        public static void GetAudioSamplesAtIndex(int id, out string audioId, out string audioRef, out bool enabled)
        {
            audioId = "";
            audioRef = "";
            enabled = false;
            try
            {
                var resourceData2 = ResourceFile.Load($"data/audio/fronend_usages.json");
                var buildingMetaData = JsonConvert.DeserializeObject<List<SoundExample>>(resourceData2.Load());
                audioId = buildingMetaData[id].AudioId;
                audioRef = buildingMetaData[id].AudioRef;
                enabled = buildingMetaData[id].Enabled;
            }
            catch (Exception e)
            {
                CDebugActionsAPI.LogError(e.ToString());
            }
        }
    }
}
