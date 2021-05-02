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
        private SpawnPattern spawnPattern;

        private BulletSpawner bulletSpawner;
        public EnemyFactory(List<LifetimeEntity> enemyList, List<LifetimeEntity> bulletSpawnerList, SpawnPattern pattern, SpriteN sprite, Movement movement, float delay = 0)
        {
            spawnPattern = pattern;
            this.enemyList = enemyList;
            spawnerList = bulletSpawnerList;
            this.sprite = sprite;
            mMovement = movement;
            this.delay = delay;

        }
        public EnemyFactory(List<LifetimeEntity> enemyList, List<LifetimeEntity> bulletSpawnerList, BulletSpawner spawner, SpriteN sprite, Movement movement)
        {
            bulletSpawner = spawner;
            this.enemyList = enemyList;
            spawnerList = bulletSpawnerList;
            this.sprite = sprite;
            mMovement = movement;
        }

        public void Spawn()
        {
            Enemy e2 = new Enemy(sprite, mMovement.Clone());
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
