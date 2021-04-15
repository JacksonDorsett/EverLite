using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EverLite.Modules.Behavior
{
    class LinearVectorMovement : VectorMovement
    {
        Vector2 Velocity;
        double angle;

        public LinearVectorMovement(Vector2 StartPosition, Vector2 finalPos, float speed)
            : base(StartPosition)
        {
            var dif = finalPos - StartPosition;
            this.angle = Math.Atan((double)(dif.Y / (double)dif.X));
            dif.Normalize();
            this.Velocity = dif * speed;
        }

        public override float Angle
        {
            get
            {
                return (float)angle;
            }
        }

        public override Movement Clone()
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            Position += (float)gameTime.ElapsedGameTime.TotalSeconds * Velocity * 50;

        }
    }
}
