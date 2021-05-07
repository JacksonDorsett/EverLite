namespace EverLite
{
    using System.Collections.Generic;
    using global::EverLite.Models.Items;
    using global::EverLite.Models.PlayerModel;
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Class that will monitor and check if object have collided.
    /// </summary>
    internal class CollisionDetector
    {
        /// <summary>
        /// List of all active enemies that were passed.
        /// </summary>
        private List<LifetimeEntity> activeEnemies;

        /// <summary>
        /// List of all enemy bullets.
        /// </summary>
        private List<Bullet> enemyBullets;

        /// <summary>
        /// List of all player bullets.
        /// </summary>
        private List<Bullet> playerBullets;

        /// <summary>
        /// List of all items.
        /// </summary>
        private List<Item> items;

        private Player player;

        /// <summary>
        /// Access to the GameScore Instance.
        /// </summary>
        private EverLite scoreKeeper;

        private SoundManager sound;

        private List<SeismicCharge> deployedBombs;

        /// <summary>
        /// Initializes a new instance of the <see cref="CollisionDetector"/> class.
        /// </summary>
        /// <param name="activeEnemies"> reference to list of all active enemies.</param>
        /// <param name="enemyBullets">reference to enemy bullets.</param>
        /// <param name="playerBullets">reference to player bullet.</param>
        /// <param name="player">reference to a current player.</param>
        /// <param name="score">reference to GameScore instance.</param>
        public CollisionDetector(List<LifetimeEntity> activeEnemies, List<Bullet> enemyBullets, List<Bullet> playerBullets, List<Item> items, Player player, EverLite score)
        {
            this.activeEnemies = activeEnemies;
            this.playerBullets = playerBullets;
            this.enemyBullets = enemyBullets;
            this.items = items;
            this.player = player;
            this.scoreKeeper = score;
            this.sound = SoundManager.Instance;
        }

        public void SetSeismicList(List<SeismicCharge> charges)
        {
            this.deployedBombs = charges;
        }

        public void Update(GameTime gameTime)
        {
            this.CheckEnemyBulletsPlayerCollision();

            this.CheckPlayerBulletsEnemyCollision();

            this.CheckPlayerEnemyCollision();

            this.CheckItemPlayerCollision();

            this.CheckEnemyBombCollision();
        }


        private void CheckEnemyBulletsPlayerCollision()
        {
            // Check if enemy bullets collide with the player.
            foreach (Bullet bullet in this.enemyBullets)
            {

                if (this.player.HitCircle.Contains(bullet.HitCircle))
                {
                    this.player.CollidesWith(bullet);
                    bullet.CollidesWith(this.player);
                    break;
                }
            }
        }

        /// <summary>
        /// Checks if player bullets collide with any enemies.
        /// </summary>
        private void CheckPlayerBulletsEnemyCollision()
        {
            // Check if player bullets collide with the player.
            foreach (Bullet bullet in this.playerBullets)
            {
                foreach (LifetimeEntity enemy in this.activeEnemies)
                {
                    if (bullet.HitCircle.Contains(enemy.HitCircle))
                    {
                        enemy.CollidesWith(bullet);
                        bullet.CollidesWith(enemy);

                        // Currently setup to add 10 points per hit. Simplist solution that still awards more points for tougher enemies.
                        this.scoreKeeper.score.Add(10);
                    }
                }
            }
        }

        private void CheckPlayerEnemyCollision()
        {
            // Check if player collide with the enemy.
            foreach (LifetimeEntity enemy in this.activeEnemies)
            {
                if (enemy.HitCircle.Contains(this.player.HitCircle))
                {
                    enemy.CollidesWith(this.player);
                    this.player.CollidesWith(enemy);
                    enemy.Die();

                }
            }
        }

        private void CheckItemPlayerCollision()
        {
            // Check if player collide with the enemy.
            foreach (Item item in this.items)
            {
                if (item is SeismicCharge)
                {
                    SeismicCharge charge = (SeismicCharge)item;
                    if (charge.IsPrimed)
                    {
                        return;
                    }
                }

                if (this.player.HitCircle.Contains(item.HitCircle))
                {
                    player.PickUpItem(item);
                    item.CollidesWith(this.player);
                }
            }
        }

        private void CheckEnemyBombCollision()
        {
            foreach (LifetimeEntity entity in this.activeEnemies)
            {
                foreach (SeismicCharge charge in this.deployedBombs)
                {
                    Enemy enemy = (Enemy)entity;
                    if (entity.HitCircle.Contains(charge.HitCircle) && !charge.HitEnemies.Contains(enemy))
                    {
                        enemy.TakeDamage(100);
                        charge.HitEnemies.Add(enemy);
                    }
                }
                
            }
        }

        private void CheckEnemyBulletBombCollision()
        {

        }
    }
}
