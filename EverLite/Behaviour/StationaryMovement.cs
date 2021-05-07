using Microsoft.Xna.Framework;
using System;

namespace EverLite.Behaviour
{
    class StationaryMovement : Movement
    {
        private Vector2 position;
        private float angle = 0;

        public StationaryMovement(Vector2 position)
        {
            this.position = position;
        }


        public override Vector2 Position { get => this.position; protected set => this.position = value; }

        public override float Angle => this.angle;

        public override bool PathCompleted => false;

        public override Movement Clone()
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            return;
        }
    }
}
