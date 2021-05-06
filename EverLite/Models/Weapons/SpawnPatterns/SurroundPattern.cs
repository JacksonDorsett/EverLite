using EverLite.Models.PlayerModel;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EverLite.Models.Weapons.SpawnPatterns
{
    class SurroundPattern : SpawnPattern
    {
        private readonly Player rPlayer;
        private int fireCount;

        public SurroundPattern(List<Bullet> bulletList, SpriteN bulletSprite, float speed, int spawnCount, float spawnRate, int fireCount = 10)
            : base(bulletList, bulletSprite, speed, spawnCount, spawnRate)
        {
            rPlayer = Player.Instance();
            this.fireCount = fireCount;
        }

        public override SpawnPattern Clone()
        {
            return new SurroundPattern(bulletList, Sprite, (float)Speed, TotalBullets, (float)SpawnRate, fireCount);
        }

        protected override void Spawn(Vector2 spawnPosition)
        {
            var dif = rPlayer.Position - spawnPosition;
            float iTheta = (float)Math.Atan(dif.Y / dif.X);
            float dTheta = (float)(2 * Math.PI) / fireCount;
            for (int i = 0; i < fireCount; i++)
            {
                bulletList.Add(CreateBullet(iTheta + dTheta * i, spawnPosition));
            }

        }

        private Bullet CreateBullet(float angle, Vector2 startPosition)
        {
            Vector2 final = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)) * 10 + startPosition;
            LinearVectorMovement m = new LinearVectorMovement(startPosition, final, (float)Speed);

            return new Bullet(Sprite, m);
        }
    }
}
