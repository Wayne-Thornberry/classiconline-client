using Proline.ClassicOnline.CWorldObjects.Data.Ownership;
using System;
using System.Collections.Generic;

namespace Proline.ClassicOnline.CWorldObjects.Internal
{
    internal class InteriorManager
    {
        private static InteriorManager _instance;
        private Dictionary<string, InteriorMetadata> _interiors;

        public InteriorManager()
        {
            _interiors = new Dictionary<string, InteriorMetadata>();
        }

        internal void Register(string interiorName, InteriorMetadata catalouge)
        {
            if (!_interiors.ContainsKey(interiorName))
                _interiors.Add(interiorName, catalouge);
        }

        internal InteriorMetadata GetInterior(string interiorName)
        {
            if (_interiors.ContainsKey(interiorName))
                return _interiors[interiorName];
            return null;
        }

        internal static InteriorManager GetInstance()
        {
            if (_instance == null)
                _instance = new InteriorManager();
            return _instance;
        }
    }
}