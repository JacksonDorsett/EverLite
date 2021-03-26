﻿using EverLite.Modules.Behavior;
using EverLite.Modules.Sprites;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EverLite.Modules.Blaster
{
    internal class LinearPattern : SpawnPattern
    {
        //private Player mPlayer;
        private Controller mPlayer;

        public LinearPattern(List<Bullet> bullets, SpriteN bulletSprite, float speed, int totalBullets, double spawnRate)
            : base(bullets, bulletSprite, speed, totalBullets, spawnRate)
        {
            //this.mPlayer = Player.Instance();
            this.mPlayer = Controller.Instance();
        }

        public override SpawnPattern Clone()
        {
            return new LinearPattern(this.bulletList, this.Sprite, (float)this.Speed, this.TotalBullets, this.SpawnRate);
        }

        public override void Spawn(Vector2 spawnPosition)
        {
            //Vector2 dif = this.mPlayer.Position - spawnPosition;
            Vector2 dif = this.mPlayer.Position - spawnPosition;
            dif.Normalize();

            var p = new LinearMovement(spawnPosition, (spawnPosition + dif * 2000));
             var b = new Bullet(this.Sprite, p, 5);
            this.bulletList.Add(b);
        }

        public override void Update(GameTime gameTime, Vector2 position)
        {
            base.Update(gameTime, position);
        }
    }
}
