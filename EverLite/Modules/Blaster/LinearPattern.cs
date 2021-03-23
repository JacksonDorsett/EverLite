using EverLite.Modules.Sprites;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EverLite.Modules.Blaster
{
    internal class LinearPattern : SpawnPattern
    {
        private Player mPlayer;
        public LinearPattern(List<Bullet> bullets, SpriteN bulletSprite, int spawnRate, int totalBullets)
            : base(bullets, bulletSprite, spawnRate, totalBullets)
        {
            this.mPlayer = Player.Instance();
        }

        public override void Spawn(Vector2 spawnPosition)
        {
            throw new NotImplementedException();
        }
    }
}
