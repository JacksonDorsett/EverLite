using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EverLite.Models.Weapons.SpawnPatterns
{
    class NoShootPattern : SpawnPattern
    {
        double delay;
        public NoShootPattern(List<Bullet> bullets, double delay) : base(bullets, new NoSprite(), 0, 1, delay)
        {
            this.delay = delay;
        }


        public override SpawnPattern Clone()
        {
            return new NoShootPattern(bulletList, delay);
        }

        protected override void Spawn(Vector2 spawnPosition)
        {
            return;
        }
    }
}
