

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


        /// <summary>
        /// Initializes a new instance of the <see cref="EnemyFactory"/> class.
        /// </summary>
        /// <param name=""></param>
        public EnemyFactory(SpriteN sprite, IMovement movement, float lifespan)
        {
            this.sprite = sprite;
            this.movement = movement;
            this.lifespan = lifespan;

        }
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
            Enemy e = new Enemy(this.sprite, this.movement, this.lifespan);
            BulletSpawner b = this.bulletSpawnerPrototype.Clone();
            this.enemyList.Add(e);
            this.spawnerList.Add(b);
            e.OnDeath += (sender, e1) =>
            {
                this.spawnerList.Remove(b);
            };

        }
    }
}
