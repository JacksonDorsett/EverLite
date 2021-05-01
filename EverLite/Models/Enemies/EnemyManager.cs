namespace EverLite.Models.Enemies
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    class EnemyManager : IUpdateable
    {
        private List<LifetimeEntity> activeEnemies;
        private List<LifetimeEntity> activeSpawners;
        private Game mGame;
        private WaveManager waveManager;
        private LifetimeEntityManager spawnerLifeManager;
        private LifetimeEntityManager enemyLifeManager;


        public List<LifetimeEntity> ActiveEnemies { get => activeEnemies; }
        /// <summary>
        /// Initializes a new instance of the <see cref="EnemyManager"/> class.
        /// </summary>
        /// <param name="game">game reference object.</param>
        public EnemyManager(Game game)
        {
            mGame = game;
            spawnerLifeManager = new LifetimeEntityManager();
            enemyLifeManager = new LifetimeEntityManager();
            activeEnemies = enemyLifeManager.EntityList;
            activeSpawners = spawnerLifeManager.EntityList;
            waveManager = new WaveManager(game, activeEnemies, activeSpawners);

        }

        public event EventHandler<EventArgs> EnabledChanged;

        public event EventHandler<EventArgs> UpdateOrderChanged;

        public bool Enabled => true;

        public int UpdateOrder => 1;

        public bool IsActive
        {
            get
            {
                return !(waveManager.CountActive == 0 && waveManager.CountQueued == 0 && activeEnemies.Count == 0);
            }
        }

        public void Update(GameTime gameTime)
        {
            waveManager.Update(gameTime);
            spawnerLifeManager.Update(gameTime);
            enemyLifeManager.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            enemyLifeManager.Draw(spriteBatch);
            spawnerLifeManager.Draw(spriteBatch);
        }
    }
}
