using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EverLite.Behaviour
{
    class EnemyHitCircle : HitCircle
    {
        public EnemyHitCircle(HitCircle hitCircle) : base(hitCircle)
        {
            this.mRadius *= 1.3f;
        }
    }
}
