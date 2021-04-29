using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EverLite.Behaviour
{
    class AggregateMovement : Movement
    {
        LifeTimeMovement[] movements;
        int currentIndex;
        public AggregateMovement(LifeTimeMovement[] movements)
        {
            this.movements = movements;
            currentIndex = 0;
        }

        public override Vector2 Position { get => movements[currentIndex].Position; protected set => throw new NotImplementedException(); }

        public override float Angle => movements[currentIndex].Angle;

        public override bool PathCompleted => currentIndex >= movements.Length;

        public override Movement Clone()
        {
            List<LifeTimeMovement> m = new List<LifeTimeMovement>();
            foreach(var move in movements)
            {
                m.Add(move.Clone() as LifeTimeMovement);
            }
            return new AggregateMovement(m.ToArray());
        }

        public override void Update(GameTime gameTime)
        {
            var currentMovement = movements[currentIndex];
            currentMovement.Update(gameTime);
            if (currentMovement.PathCompleted) this.currentIndex++;
            
        }
    }
}
