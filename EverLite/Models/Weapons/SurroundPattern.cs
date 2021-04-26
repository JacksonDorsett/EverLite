using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EverLite.Models.Weapons
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
            return new SurroundPattern(bulletList, this.Sprite, (float)Speed, this.TotalBullets, (float)this.SpawnRate, fireCount);
        }

        public override void Spawn(Vector2 spawnPosition)
        {
            var dif = rPlayer.Position - spawnPosition;
            float iTheta = (float)Math.Atan((double)(dif.Y / dif.X));
            float dTheta = (float)(2 * Math.PI) / (float)this.fireCount;
            for(int i = 0; i < this.fireCount; i++)
            {
                bulletList.Add(CreateBullet(iTheta + dTheta * i, spawnPosition));
            }

        }

        private Bullet CreateBullet(float angle, Vector2 startPosition)
        {
            Vector2 final = new Vector2((float)Math.Cos((double)angle), (float)Math.Sin((double)angle)) * 10 + startPosition;
            LinearVectorMovement m = new LinearVectorMovement(startPosition, final, (float)this.Speed);

            return new Bullet(Sprite, m);
        }
    }
}
