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
            var im = mi.Interperit(JToken.Parse("[{\"type\" : \"A\", \"time\" : 60, \"points\" : [ [0,0], [1000, 1000], [500,0], [0,0]] },{\"type\" : \"A\", \"time\" : 2, \"points\" : [ [0,0], [1000, 1000], [500,0], [0,0]] }]"));
            BulletSpawnerInterpereter bsi = new BulletSpawnerInterpereter(im);
            var spawner = bsi.Interperet(JToken.Parse("{ \"delay\": 2,\"isLooping\": true, \"patterns\": [ { \"type\": \"spiral\", \"amount\": 60, \"speed\": 10, \"interval\": 0.05, \"rotations\": 2, \"distance\": 250 },{ \"type\": \"linear\", \"amount\": 20, \"speed\": 10, \"interval\": 0.1 },{\"type\" : \"none\", \"time\" : 3},{ \"type\": \"surround\", \"amount\": 10, \"speed\": 10, \"interval\": 0.1, \"fireCount\" : 10 }]}"));
            // Adjusted spawn locations and the curve point so that they do not spawn/shoot under the sideGamePanel.
            WaveBuilder builder = new WaveBuilder(enemies, spawners);
            foreach (Wave w in builder.ParseWaves("waves.json"))
            {
                this.AddWave(w);
            }
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
