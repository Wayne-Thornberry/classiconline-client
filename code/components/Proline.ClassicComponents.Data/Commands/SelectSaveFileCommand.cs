﻿using CitizenFX.Core;
using Proline.ClassicOnline.CDataStream.Internal;

using Proline.Resource.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = Proline.Resource.Console;

namespace Proline.ClassicOnline.CDataStream.Commands
{
    public class SelectSaveFileCommand : ResourceCommand
    {
        public SelectSaveFileCommand() : base("SelectSaveFile")
        {
        }

        protected override void OnCommandExecute(params object[] args)
        {
            if (args.Length > 0)
            {
                var identifier = args[0].ToString();
                var sm = DataFileManager.GetInstance();
                var save = sm.GetSave(Game.Player);
                var saveFile = save.GetSaveFile(identifier);
                sm.ActiveFile = saveFile;
            }
        }
    }
}
