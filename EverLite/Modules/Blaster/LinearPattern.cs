using EverLite.Modules.Behavior;
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

        public LinearPattern(List<Bullet> bullets, SpriteN bulletSprite, float speed, int totalBullets, double spawnRate)
            : base(bullets, bulletSprite, speed, totalBullets, spawnRate)
        {
            this.mPlayer = Player.Instance();
        }

        public override void Spawn(Vector2 spawnPosition)
        {
            Vector2 dif = this.mPlayer.GetPosition() - spawnPosition;
            dif.Normalize();

            var p = new LinearMovement(spawnPosition, spawnPosition * dif * 2000);
            var b = new Bullet(this.Sprite, p, 20);
        }
    }
}
