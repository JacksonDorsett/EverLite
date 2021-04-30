namespace EverLite
{
    using System.Collections.Generic;
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
        }

        public void Update(GameTime gameTime)
        {
            this.CheckEnemyBulletsPlayerCollision();

            this.CheckPlayerBulletsEnemyCollision();

            this.CheckPlayerEnemyCollision();

            this.CheckItemPlayerCollision();
        }


        private void CheckEnemyBulletsPlayerCollision()
        {
            // Check if enemy bullets collide with the player.
            foreach (Bullet bullet in this.enemyBullets)
            {
                ICollidable collidableObjectBullet = bullet;
                ICollidable collidableObjectPlayer = this.player;

                if (this.player.HitCircle.Contains(bullet.HitCircle))
                {
                    collidableObjectPlayer.CollidesWith(collidableObjectBullet);
                    collidableObjectBullet.CollidesWith(collidableObjectPlayer);
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
                    ICollidable collidableObjectBullet = bullet;
                    ICollidable collidableObjectEnemy = enemy;


                    Rectangle bulletBox = new Rectangle((int)bullet.Position.X, (int)bullet.Position.Y, bullet.Sprite.Texture.Width, bullet.Sprite.Texture.Height);
                    Rectangle playerBox = new Rectangle(
                        (int)enemy.Position.X,
                        (int)enemy.Position.Y,
                        enemy.Sprite.Texture.Width,
                        enemy.Sprite.Texture.Height);

                    if (bulletBox.Intersects(playerBox))
                    {
                        collidableObjectEnemy.CollidesWith(collidableObjectBullet);
                        collidableObjectBullet.CollidesWith(collidableObjectEnemy);

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

                ICollidable collidableObjectPlayer = this.player;
                ICollidable collidableObjectEnemy = enemy;
                Rectangle enemyBox = new Rectangle(
                    (int)this.player.Position.X,
                    (int)this.player.Position.Y,
                    this.player.PlayerSprite.Texture.Width,
                    this.player.PlayerSprite.Texture.Height);

                Rectangle playerBox = new Rectangle(
                    (int)enemy.Position.X,
                    (int)enemy.Position.Y,
                    enemy.Sprite.Texture.Width,
                    enemy.Sprite.Texture.Height);

                if (enemyBox.Intersects(playerBox))
                {
                    collidableObjectEnemy.CollidesWith(collidableObjectPlayer);
                    collidableObjectPlayer.CollidesWith(collidableObjectEnemy);
                    enemy.Die();

                }
            }
        }

        private void CheckItemPlayerCollision()
        {
            // Check if player collide with the enemy.
            foreach (Item item in this.items)
            {
                Rectangle enemyBox = new Rectangle(
                    (int)this.player.Position.X,
                    (int)this.player.Position.Y,
                    this.player.PlayerSprite.Texture.Width,
                    this.player.PlayerSprite.Texture.Height);

                Rectangle playerBox = new Rectangle(
                    (int)item.Position.X,
                    (int)item.Position.Y,
                    item.Sprite.Texture.Width,
                    item.Sprite.Texture.Height);

                if (enemyBox.Intersects(playerBox))
                {
                    item.CollidesWith(this.player);
                    
                }
            }
        }
    }
}
