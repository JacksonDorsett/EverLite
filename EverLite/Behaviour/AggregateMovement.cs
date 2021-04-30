using Microsoft.Xna.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace EverLite.Behaviour
{
    class AggregateMovement : Movement
    {
        Movement[] movements;
        int currentIndex;
        Vector2 lastPos;
        float mAngle;

        public AggregateMovement(Movement[] movements)
        {
            this.movements = movements;
            currentIndex = 0;
        }

        public override Vector2 Position {
            get
            {
                if (this.PathCompleted)
                {

                }
                if (!this.PathCompleted) this.lastPos = movements[currentIndex].Position;
                return lastPos;
            }
            protected set { throw new NotImplementedException(); } }

        public override float Angle
        {
            get
            {
                if (!this.PathCompleted) mAngle = movements[currentIndex].Angle;
                return mAngle;
            }
            
        }

        public override bool PathCompleted => currentIndex >= movements.Length;

        public override Movement Clone()
        {
            List<Movement> m = new List<Movement>();
            foreach(var move in movements)
            {
                m.Add(move.Clone() as Movement);
            }
            return new AggregateMovement(m.ToArray());
        }

        public override void Update(GameTime gameTime)
        {

            if (currentIndex >= this.movements.Length) return;
            movements[currentIndex].Update(gameTime);
            if (this.movements[currentIndex].PathCompleted)
            {
                currentIndex++;
            }

             


        }
    }
}
