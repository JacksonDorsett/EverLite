using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EverLite.ScriptInterperiter
{
    class MovementFactory
    {
        public static Movement Create(string type, int time, List<Vector2> points)
        {
            switch (type)
            {
                case "A":
                    return makeLinear(type, time, points);
                    break;
            }
            return null;
        }

        private static Movement makeLinear(string type, int time, List<Vector2> points)
        {
            if (points.Count < 2) throw new Exception("at least 2 points must be given");
            return null;

        }
    }
}
