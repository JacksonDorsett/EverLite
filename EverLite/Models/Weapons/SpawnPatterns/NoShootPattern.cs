using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EverLite.Models.Weapons.SpawnPatterns
{
    class NoShootPattern : SpawnPattern
    {
        double delay;
        public NoShootPattern(List<Bullet> bullets, SpriteN bulletSprite, double delay) : base(bullets, bulletSprite, 0, 1, delay)
        {
            this.delay = delay;
        }

        public override SpawnPattern Clone()
        {
            return new NoShootPattern(bulletList, Sprite, delay);
        }

        protected override void Spawn(Vector2 spawnPosition)
        {
            return;
        }
    }
}
