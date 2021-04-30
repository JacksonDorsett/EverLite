namespace EverLite
{
    using System;
    using Microsoft.Xna.Framework;

    public class HitCircle
    {
        private Vector2 mPosition;
        protected float mRadius;

        public HitCircle(Vector2 position, float radius)
        {
            this.mPosition = position;
            this.mRadius = radius;
        }

        public HitCircle(HitCircle other)
        {
            this.mPosition = other.mPosition;
            this.mRadius = other.mRadius;
        }

        public float Radius { get => this.mRadius; }

        public bool Contains(HitCircle other)
        {
            float dx = other.mPosition.X - this.mPosition.X;
            float dy = other.mPosition.Y - this.mPosition.Y;
            return Math.Sqrt(dx * dx + dy * dy) < this.Radius + other.Radius;
        }
    }
}
