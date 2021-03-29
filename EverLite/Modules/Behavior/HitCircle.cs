using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EverLite.Modules.Behavior
{
    public class HitCircle
    {
        private Vector2 mPosition;
        private float mRadius;

        public HitCircle(Vector2 position, float radius)
        {
            this.mPosition = position;
            this.mRadius = radius;
        }

        public float Radius { get => this.mRadius; }
        
        public bool Contains(HitCircle other)
        {
            float dx = other.mPosition.X - this.mPosition.X;
            float dy = other.mPosition.Y - this.mPosition.Y;
            return Math.Sqrt(dx*dx + dy*dy) < this.Radius + other.Radius;
        }
    }
}
