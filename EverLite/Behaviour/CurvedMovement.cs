namespace EverLite
{
    using System;
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Represents a curved movement segment.
    /// </summary>
    public class CurvedMovement : IMovement
    {

        private CurveKeyCollection keyCollection;
        private Curve curve;
        private Vector2 start;
        private Vector2 end;
        private Vector2 mid;

        /// <summary>
        /// Initializes a new instance of the <see cref="CurvedMovement"/> class.
        /// </summary>
        /// <param name="start">starting position.</param>
        /// <param name="end">ending position.</param>
        /// <param name="midPoint">mid point.</param>
        public CurvedMovement(Vector2 start, Vector2 end, Vector2 midPoint)
        {
            this.start = start;
            this.end = end;
            this.mid = midPoint;
            this.curve = new Curve();
            this.keyCollection = this.curve.Keys;
            this.keyCollection.Add(new CurveKey(start.X, start.Y));
            this.keyCollection.Add(new CurveKey(midPoint.X, midPoint.Y));
            this.keyCollection.Add(new CurveKey(end.X, end.Y));
        }

        public float Distance {
            get
            {
                var dif1 = mid - start;
                var dif2 = end - mid;
                return (mid - start).Length() + (end - mid).Length();
            }
        }
        public float Angle(double halfLife)
        {
            var dif = this.GetPosition(halfLife) - this.GetPosition(halfLife - .0001d);
            //handle divide by zero case
            if (dif.X == 0)
            {
                if (dif.Y >= 0) return (float)Math.PI / 2;
                else return 3 * (float)Math.PI / 2;
            }
            var angle = (float)Math.Atan((double)dif.Y / (double)dif.X);
            if (dif.X > 0) angle += (float)Math.PI;
            return angle;
        }

        public Vector2 GetPosition(double halfLife)
        {
            var delta = this.end.X - this.start.X;
            var diff = (float)halfLife * delta;

            float x = this.start.X + diff;
            return new Vector2(x, this.curve.Evaluate(x));
        }
    }
}
