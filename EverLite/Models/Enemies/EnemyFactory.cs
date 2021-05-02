namespace EverLite.Models.Enemies
{
    using global::EverLite.Models.Weapons.SpawnPatterns;
    using System.Collections.Generic;

    public class EnemyFactory
    {
        private readonly SpriteN sprite;
        private readonly Movement mMovement;
        private List<LifetimeEntity> enemyList;
        private List<LifetimeEntity> spawnerList;
        private float delay;
        private int health;

        private BulletSpawner bulletSpawner;
        
        public EnemyFactory(List<LifetimeEntity> enemyList, List<LifetimeEntity> bulletSpawnerList, BulletSpawner spawner, SpriteN sprite, Movement movement, int health = 100, float delay = 0)
        {
            bulletSpawner = spawner;
            this.enemyList = enemyList;
            spawnerList = bulletSpawnerList;
            this.sprite = sprite;
            mMovement = movement;
            this.health = health;
        }

        public void Spawn()
        {
            Enemy e2 = new Enemy(sprite, mMovement.Clone(), health);
            BulletSpawner b = this.bulletSpawner.Clone();
            enemyList.Add(e2);
            spawnerList.Add(b);
            e2.OnDeath += (sender, e1) =>
            {
                spawnerList.Remove(b);
            };
        }
    }
}
