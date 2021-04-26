namespace EverLite
{
    using System.Collections.Generic;
    using global::EverLite.Models.Weapons;
    using Microsoft.Xna.Framework;

    public class WaveManager
    {
        private List<Wave> activeWaves;
        private GameClock clock;
        private WaveQueue queue;
        private Game mGame;
        private List<LifetimeEntity> enemies;
        private List<LifetimeEntity> spawners;

        /// <summary>
        /// Initializes a new instance of the <see cref="WaveManager"/> class.
        /// </summary>
        /// <param name="game">game ref.</param>
        /// <param name="enemies">list of active enemies.</param>
        /// <param name="spawners">list of spawners.</param>
        public WaveManager(Game game, List<LifetimeEntity> enemies, List<LifetimeEntity> spawners)
            : base()
        {
            this.clock = new GameClock();
            this.activeWaves = new List<Wave>();
            this.queue = new WaveQueue(this.clock);
            this.enemies = enemies;
            this.spawners = spawners;
            this.mGame = game;
            this.Initialize();
        }

        /// <summary>
        /// Gets number of active waves.
        /// </summary>
        public int CountActive { get => this.activeWaves.Count; }

        /// <summary>
        /// Gets number of queued waves.
        /// </summary>
        public int CountQueued { get => this.queue.Count; }

        /// <summary>
        /// Adds wave to wave manager.
        /// </summary>
        /// <param name="wave">wave to be added.</param>
        /// <returns>returns if the wave was successully added.</returns>
        public bool AddWave(Wave wave)
        {
            if (wave.StartTime < this.clock.ElapsedTime.TotalSeconds) return false;

            this.queue.Add(wave);
            return true;
        }

        public void Initialize()
        {
            // Adjusted spawn locations and the curve point so that they do not spawn/shoot under the sideGamePanel.
            var linear1 = new LinearMovement(new Vector2(2000, 480), new Vector2(480, 200));
            var curved1 = new CurvedMovement(new Vector2(480, 700), new Vector2(2000, 950), new Vector2(1000, 100));
            var curved = new LifeTimeMovement(5, curved1);
            var linear = new LifeTimeMovement(5, linear1);
            //this.AddWave(new Wave(new EnemyFactory(this.enemies, this.spawners, new BulletSpawner(curved, new LinearPattern(BulletManager.Instance.EnemyBullets, SpriteLoader.LoadSprite("redBullet"), 10f, 20, 1)), SpriteLoader.LoadSprite("enemy1"), curved1, 5), 1000, 10, 0));
            this.AddWave(new Wave(new EnemyFactory(this.enemies, this.spawners, new BulletSpawner(linear, new SurroundPattern(BulletManager.Instance.EnemyBullets, SpriteLoader.LoadSprite("redBullet"), 10f, 20, 1)), SpriteLoader.LoadSprite("enemy2"), linear1, 5), 1000, 10, 0));
        }

        public void Update(GameTime gameTime)
        {
            this.clock.Update(gameTime);

            if (this.queue.IsReady)
            {
                this.activeWaves.Add(this.queue.PopWave());
            }

            List<Wave> deadWaves = new List<Wave>();
            foreach (Wave w in this.activeWaves)
            {
                w.Update(gameTime);
                if (!w.IsWaveActive)
                {
                    deadWaves.Add(w);
                }
            }

            // Cleanup dead waves
            foreach (var w in deadWaves)
            {
                this.activeWaves.Remove(w);
            }
        }
    }
}
