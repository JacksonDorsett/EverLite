using EverLite.Modules.Enemies;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EverLite.Modules.Behavior
{
    class LifeTimeMovement : Movement
    {

        IMovement movement;
        Lifespan lifeSpan;
        double totalLifeSpan;
        public LifeTimeMovement(double lifeSpan, IMovement movementType)
        {
            this.movement = movementType;
            this.lifeSpan = new Lifespan(lifeSpan);
            this.totalLifeSpan = lifeSpan;
        }

        public override Vector2 Position
        {
            get
            {
                return this.movement.GetPosition(lifeSpan.Halflife);
            }
            protected set
            {
                return;
            }
        }

        public override float Angle => movement.Angle((double)lifeSpan.Halflife);

        public override bool PathCompleted => lifeSpan.Halflife < 1;

        public override Movement Clone()
        {
            return new LifeTimeMovement(totalLifeSpan, movement);
        }

        public override void Update(GameTime gameTime)
        {
            this.lifeSpan.Update(gameTime);
        }
    }
}
