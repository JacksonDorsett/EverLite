using EverLite.Modules.Behavior;
using EverLite.Modules.Sprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace EverLite.Modules.Blaster
{
    class AbstractBulletSpawner
    {
        private IMovement movementPattern;
        private double lifetime;
        private SpawnPattern spawnPattern;
        SpriteN bulletSprite;
        int totalBullets;
        double spawnRate;

        public AbstractBulletSpawner(IMovement movement, double lifetime, SpriteN bulletSprite, int totalBullets, double spawnRate)
        {
            this.movementPattern = movement;
            this.lifetime = lifetime;
            this.bulletSprite = bulletSprite;
            this.totalBullets = totalBullets;
            this.spawnRate = spawnRate;
        }
   

        public BulletSpawner GetSpawner()
        {
            return new BulletSpawner(movementPattern, lifetime, spawnPattern)
        }
    }
}
