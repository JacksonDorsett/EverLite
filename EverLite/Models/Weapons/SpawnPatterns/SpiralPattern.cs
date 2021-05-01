using EverLite.Models.PlayerModel;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EverLite.Models.Weapons.SpawnPatterns
{
    class SpiralPattern : SpawnPattern
    {
        double angle;
        double distance;
        double finalDistance;

        int rotations;
        public SpiralPattern(List<Bullet> bullets, SpriteN bulletSprite, float speed, int totalBullets, double spawnRate, int rotations = 1, float finalDist = 300) : base(bullets, bulletSprite, speed, totalBullets, spawnRate)
        {
            finalDistance = finalDist;
            this.rotations = rotations;
        }

        private double AngleDif => rotations * 2 * Math.PI / TotalBullets;
        private double DistanceDif => finalDistance / TotalBullets;
        public override SpawnPattern Clone()
        {
            return new SpiralPattern(bulletList, Sprite, (float)Speed, TotalBullets, SpawnRate, rotations, (float)finalDistance);
        }

        public override void Spawn(Vector2 spawnPosition)
        {
            Vector2 dif = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
            dif.Normalize();
            dif *= (float)distance;
            bulletList.Add(new Bullet(Sprite, new LinearVectorMovement(spawnPosition + dif, Player.Instance().Position, (float)Speed)));
            angle += AngleDif;
            distance += DistanceDif;
        }
    }
}
