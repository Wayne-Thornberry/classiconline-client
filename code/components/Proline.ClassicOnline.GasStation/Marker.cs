using CitizenFX.Core;
using Proline.ClassicOnline.CDebugActions;
using Proline.ClassicOnline.CWorldObjects.Internal;
using System;

namespace Proline.ClassicOnline.CWorldObjects
{
    public static partial class WorldAPI
    {
        public static int CreateMarker(Vector3 position, float activationRange = 2f)
        {
            var api = new CDebugActionsAPI();
            try
            {
                var instance = MarkerManager.GetInstance();
                var marker = new Marker(position, new Vector3(0, 0, 0), Vector3.One, MarkerType.DebugSphere, System.Drawing.Color.FromArgb(150, 255, 255, 255));
                marker.ActivationRange = activationRange;
                return instance.AddMarker(marker);
            }
            catch (Exception e)
            {
                api.LogError(e);
            }
            return 0;
        }

        public static void DrawMarker(int handle)
        {
            var api = new CDebugActionsAPI();
            try
            {
                var instance = MarkerManager.GetInstance();
                var marker = instance.GetMarker(handle);
                marker.Draw();
            }
            catch (Exception e)
            {
                api.LogError(e);
            }
        }

        public static bool IsInMarker(int handle, int obj)
        {
            var api = new CDebugActionsAPI();
            try
            {
                var instance = MarkerManager.GetInstance();
                var marker = instance.GetMarker(handle);
                var prop = Entity.FromHandle(obj);
                return World.GetDistance(prop.Position, marker.Position) < marker.ActivationRange;
            }
            catch (Exception e)
            {
                api.LogError(e);
            }
            return false;
        }

        public static void DeleteMarker(int handle)
        {
            var api = new CDebugActionsAPI();
            try
            {
                var instance = MarkerManager.GetInstance();
                var marker = instance.GetMarker(handle);
                instance.RemoveMarker(handle);
            }
            catch (Exception e)
            {
                api.LogError(e);
            }
        }
    }
}
