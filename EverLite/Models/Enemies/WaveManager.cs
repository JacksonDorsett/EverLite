namespace EverLite.Models.Enemies
{
    using System.Collections.Generic;
    using System.Linq;
    using global::EverLite.Behaviour;
    using global::EverLite.Models.Weapons;
    using global::EverLite.Models.Weapons.SpawnPatterns;
    using global::EverLite.ScriptInterperiter;
    using Microsoft.Xna.Framework;
    using Newtonsoft.Json.Linq;

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
            clock = new GameClock();
            activeWaves = new List<Wave>();
            queue = new WaveQueue(clock);
            this.enemies = enemies;
            this.spawners = spawners;
            mGame = game;
            Initialize();
        }

        /// <summary>
        /// Gets number of active waves.
        /// </summary>
        public int CountActive { get => activeWaves.Count; }

        /// <summary>
        /// Gets number of queued waves.
        /// </summary>
        public int CountQueued { get => queue.Count; }

        /// <summary>
        /// Adds wave to wave manager.
        /// </summary>
        /// <param name="wave">wave to be added.</param>
        /// <returns>returns if the wave was successully added.</returns>
        public bool AddWave(Wave wave)
        {
            if (wave.StartTime < clock.ElapsedTime.TotalSeconds) return false;

            queue.Add(wave);
            return true;
        }

        public void Initialize()
        {
            Vector2[] pts = { new Vector2(0, 0), new Vector2(400, 400), new Vector2(1500, 1000), new Vector2(500, 500), new Vector2(0, 100) };
            var path = MovementFactory.Create("B", 8, pts.ToList());
            MovementInterperiter mi = new MovementInterperiter();
            var im = mi.Interperit(JToken.Parse("[{\"type\" : \"A\", \"time\" : 6, \"points\" : [ [0,0], [1000, 1000], [500,0], [0,0]] },{\"type\" : \"A\", \"time\" : 2, \"points\" : [ [0,0], [1000, 1000], [500,0], [0,0]] }]"));
            var l1 = new LinearMovement(new Vector2(2000, 400), new Vector2(1000, 1000));
            var l2 = new LinearMovement(new Vector2(1000, 1000), new Vector2(0, 0));
            var l3 = new CurvedMovement(new Vector2(0, 0), new Vector2(2000, 1000), new Vector2(500, 200));
            var l4 = new LinearMovement(new Vector2(2000, 1000), new Vector2(2000, 400));
            LifeTimeMovement[] mv = { new LifeTimeMovement(5, l1), new LifeTimeMovement(5, l2), new LifeTimeMovement(4, l3), new LifeTimeMovement(2, l4) };
            AggregateMovement a2 = new AggregateMovement(mv);
            Movement[] mv2 = { a2, a2.Clone() };
            AggregateMovement a = new AggregateMovement(mv2);
            // Adjusted spawn locations and the curve point so that they do not spawn/shoot under the sideGamePanel.
            var linear1 = new LinearMovement(new Vector2(2000, 480), new Vector2(480, 200));
            var curved1 = new CurvedMovement(new Vector2(0, 700), new Vector2(2000, 950), new Vector2(1000, 100));
            var curved = new LifeTimeMovement(5, curved1);
            var linear = new LifeTimeMovement(10, linear1);
            //this.AddWave(new Wave(new EnemyFactory(this.enemies, this.spawners, new BulletSpawner(curved, new LinearPattern(BulletManager.Instance.EnemyBullets, SpriteLoader.LoadSprite("redBullet"), 10f, 20, 1)), SpriteLoader.LoadSprite("enemy1"), curved), 1000, 10, 0));
            //this.AddWave(new Wave(new EnemyFactory(this.enemies, this.spawners, new BulletSpawner(im, new SpiralPattern(BulletManager.Instance.EnemyBullets, SpriteLoader.LoadSprite("redBullet"), 10f, 60, .05f, 4, 300), shootDelay: 5000), SpriteLoader.LoadSprite("mid-boss"), im), 1000, 1, 0));
            AddWave(new Wave(new EnemyFactory(enemies, spawners, new SpiralPattern(BulletManager.Instance.EnemyBullets, SpriteLoader.LoadSprite("redBullet"), 10f, 60, .05f, 4, 300), SpriteLoader.LoadSprite("mid-boss"), im, 2), 1, 1, 3));
        }

        public void Update(GameTime gameTime)
        {
            clock.Update(gameTime);

            if (queue.IsReady)
            {
                activeWaves.Add(queue.PopWave());
            }

            List<Wave> deadWaves = new List<Wave>();
            foreach (Wave w in activeWaves)
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
                activeWaves.Remove(w);
            }
        }
    }
}
