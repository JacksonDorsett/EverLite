

namespace EverLite.Modules.Wave
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EverLite.Modules.Behavior;
    using EverLite.Modules.Blaster;
    using EverLite.Modules.Enemies;
    using EverLite.Modules.Sprites;

    /// <summary>
    /// Spawns the type of enemies.
    /// </summary>
    public class EnemyFactory
    {
        private readonly SpriteN sprite;
        private readonly IMovement movement;
        private readonly float lifespan;
        private List<LifetimeEntity> enemyList;
        private List<LifetimeEntity> spawnerList;
        private BulletSpawner bulletSpawnerPrototype;

        public EnemyFactory(List<LifetimeEntity> enemyList, List<LifetimeEntity> bulletSpawnerList, BulletSpawner spawner, SpriteN sprite, IMovement movement, float lifespan)
        {
            this.bulletSpawnerPrototype = spawner;
            this.enemyList = enemyList;
            this.spawnerList = bulletSpawnerList;
            this.sprite = sprite;
            this.movement = movement;
            this.lifespan = lifespan;

        }


        public void Spawn()
        {
            Enemy e2 = new Enemy(this.sprite, new LifeTimeMovement(this.lifespan, this.movement));
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
