﻿namespace EverLite
{
    using System.Collections.Generic;

    public class EnemyFactory
    {
        private readonly SpriteN sprite;
        private readonly Movement mMovement;
        private List<LifetimeEntity> enemyList;
        private List<LifetimeEntity> spawnerList;
        private BulletSpawner bulletSpawnerPrototype;

        public EnemyFactory(List<LifetimeEntity> enemyList, List<LifetimeEntity> bulletSpawnerList, BulletSpawner spawner, SpriteN sprite, Movement movement)
        {
            this.bulletSpawnerPrototype = spawner;
            this.enemyList = enemyList;
            this.spawnerList = bulletSpawnerList;
            this.sprite = sprite;
            this.mMovement = movement;
        }

        public void Spawn()
        {
            Enemy e2 = new Enemy(this.sprite, mMovement.Clone());
            BulletSpawner b = this.bulletSpawnerPrototype.Clone();
            this.enemyList.Add(e2);
            this.spawnerList.Add(b);
            e2.OnDeath += (sender, e1) =>
            {
                this.spawnerList.Remove(b);
            };
        }
    }
}
