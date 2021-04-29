namespace EverLite
{
    using System;
    using Microsoft.Xna.Framework;

    public class LinearMovement : IMovement
    {
        private Vector2 mInitialPos;
        private Vector2 diff;

        /// <summary>
        /// Initializes a new instance of the <see cref="LinearMovement"/> class.
        /// </summary>
        /// <param name="initialPos">Initial Position of path.</param>
        /// <param name="finalPos">Final position of path.</param>
        public LinearMovement(Vector2 initialPos, Vector2 finalPos)
        {
            this.mInitialPos = initialPos;
            this.diff = finalPos - initialPos;
        }

        public float Distance => (float)Math.Sqrt(diff.X * diff.X + diff.Y * diff.Y);

        public float Angle(double halfLife)
        {
            if (this.diff.X == 0)
            {
                if (this.diff.Y >= 0) return (float)Math.PI / 2;
                else return 3 * (float)Math.PI / 2;
            }
            var angle = (float)Math.Atan((double)this.diff.Y / (double)this.diff.X);
            if (diff.X >= 0) angle += (float)Math.PI;
            return angle;
        }

        // inheritdoc
        public Vector2 GetPosition(double halfLife)
        {
            return this.mInitialPos + ((float)halfLife * this.diff);
        }
    }
}
