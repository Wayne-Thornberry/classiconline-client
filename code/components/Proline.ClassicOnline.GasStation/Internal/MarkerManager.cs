﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proline.ClassicOnline.CWorldObjects.Internal
{
    internal class MarkerManager
    {
        private static MarkerManager _instance;
        private Dictionary<int, Marker> _markerDic;
        private int _nextHandle;

        public MarkerManager()
        {
            _markerDic = new Dictionary<int, Marker>();
        }

        internal static MarkerManager GetInstance()
        {
            if (_instance == null)
                _instance = new MarkerManager();
            return _instance;
        }

        internal int AddMarker(Marker marker)
        {
            _nextHandle++;
            _markerDic.Add(_nextHandle, marker);
            return _nextHandle;
        }

        internal Marker GetMarker(int handle)
        {
            return _markerDic[handle];
        }

        internal void RemoveMarker(int handle)
        {
            _markerDic.Remove(handle);
        }
    }
}
