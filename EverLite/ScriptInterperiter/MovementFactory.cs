using EverLite.Behaviour;
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
                case "B":
                    return makeCurved(type, time, points);
                default:
                    throw new Exception();
            }
        }

        private static Movement makeLinear(string type, int time, List<Vector2> points)
        {
            if (points.Count < 2) throw new Exception("at least 2 points must be given");
            List<float> l = new List<float>();
            float total = 0;
            for(int i = 1; i < points.Count; i++)
            {
                float d = (points[i] - points[i-1]).Length();
                total += d;
                l.Add(d);
            }
            List<Movement> ml = new List<Movement>();
            for (int i = 0; i < l.Count; i++)
            {
                ml.Add(new LifeTimeMovement(l[i] / total * time, new LinearMovement(points[i], points[i + 1])));
            }
            return new AggregateMovement(ml.ToArray());

        }

        private static Movement makeCurved(string type, int time, List<Vector2> points)
        {
            if (points.Count < 2) throw new Exception("needs at least 2 points given.");
            if (points.Count == 2) return new LifeTimeMovement(time, new LinearMovement(points[0], points[1]));
            float totalDist = 0;
            List<float> l = new List<float>();
            for (int i = 1; i < points.Count; ++i)
            {
                float dif = (points[i] - points[i - 1]).Length();
                totalDist += dif;
                l.Add(dif);
            }
            int index = 0;
            List<Movement> ml = new List<Movement>();
            while(index + 2 < points.Count)
            {
                ml.Add(new LifeTimeMovement((l[index] + l[index + 1]) / totalDist*time, new CurvedMovement(points[index], points[index + 2], points[index + 1])));
                index += 2;
            }

            if (index == points.Count - 2) ml.Add(new LifeTimeMovement(l[l.Count-1]/totalDist*time,new LinearMovement(points[index],points[index + 1])));
            return new AggregateMovement(ml.ToArray());
        }
    }
}
