namespace EverLite
{
    using System.Collections.Generic;

    public class EnemyFactory
    {
        private readonly SpriteN sprite;
        private readonly Movement mMovement;
        private List<LifetimeEntity> enemyList;
        private List<LifetimeEntity> spawnerList;
        private float delay;
        private SpawnPattern spawnPattern;


        public EnemyFactory(List<LifetimeEntity> enemyList, List<LifetimeEntity> bulletSpawnerList, SpawnPattern pattern, SpriteN sprite, Movement movement, float delay = 0)
        {
            this.spawnPattern = pattern;
            this.enemyList = enemyList;
            this.spawnerList = bulletSpawnerList;
            this.sprite = sprite;
            this.mMovement = movement;
            this.delay = delay;

        }


        public void Spawn()
        {
            Enemy e2 = new Enemy(this.sprite, mMovement.Clone());
            BulletSpawner b = new BulletSpawner(mMovement.Clone(), this.spawnPattern,delay);
            this.enemyList.Add(e2);
            this.spawnerList.Add(b);
            e2.OnDeath += (sender, e1) =>
            {
                this.spawnerList.Remove(b);
            };
        }
    }
}
