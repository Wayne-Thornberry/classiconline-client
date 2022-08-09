﻿using Proline.Resource.Configuration;
using System.Collections.Generic;

namespace Proline.ClassicOnline.CCoreSystem.Internal
{
    internal class ScriptingConfigSection
    {
        internal static ScriptingConfigSection ModuleConfig => Configuration.GetSection<ScriptingConfigSection>("scriptingConfigSection");
        public List<string> LevelScriptAssemblies { get; set; }
    }
}
