using CitizenFX.Core;
using CitizenFX.Core.Native;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proline.ClassicOnline.Engine.Parts
{
    public static partial class EngineAPI
    {
        public static void Draw2DBox(float x, float y, float width, float heigth, Color color)
        {
            
        }

        public static Vector3 ScreenRelToWorld(Vector3 camPos, Vector3 camRot, Vector2 coord, out Vector3 forwardDirection)
        {
            return default;
        }

        private static bool World3DToScreen2D(Vector3 pos, out Vector2 result)
        {
            return default;
        }

        private static float DegToRad(float _deg)
        {
            return default;
        }

        private static Vector3 RotationToDirection(Vector3 rotation)
        {
            return default; 
        }


        public static void DrawDebug2DBox(PointF start, PointF end, Color color)
        {
           
        }

        public static void DrawDebugText2D(string text, PointF vector2, float scale, int font)
        {
           
        }
    }
}
