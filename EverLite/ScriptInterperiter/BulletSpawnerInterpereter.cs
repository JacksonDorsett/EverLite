using System;
using System.Collections.Generic;
using System.Text;
using global::EverLite.Models.Weapons.SpawnPatterns;
using Newtonsoft.Json.Linq;
namespace EverLite.ScriptInterperiter
{
    class BulletSpawnerInterpereter
    {
        Movement movement;
        public BulletSpawnerInterpereter(Movement movement)
        {
            this.movement = movement;
        }

        public BulletSpawner Interperet(JToken obj)
        {
            List<SpawnPattern> l = new List<SpawnPattern>();
            foreach(JToken t in obj["patterns"])
            {
                l.Add(InterperetPattern(t));
            }
            return new BulletSpawner(movement, new SpawnPatternCycle(BulletManager.Instance.EnemyBullets, l.ToArray(), obj["isLooping"].ToObject<bool>()), obj["delay"].ToObject<double>());
        }
        private SpawnPattern InterperetPattern(JToken obj)
        {
            switch (obj["type"].ToString())
            {
                case "spiral":
                    return new SpiralPattern(BulletManager.Instance.EnemyBullets, SpriteLoader.LoadSprite("redBullet"), obj["speed"].ToObject<float>(), obj["amount"].ToObject<int>(), obj["interval"].ToObject<double>(), obj["rotations"].ToObject<int>(), obj["distance"].ToObject<int>());
                case "linear":
                    return new LinearPattern(BulletManager.Instance.EnemyBullets, SpriteLoader.LoadSprite("redBullet"), obj["speed"].ToObject<float>(), obj["amount"].ToObject<int>(), obj["interval"].ToObject<double>());
                case "surround":
                    return new SurroundPattern(BulletManager.Instance.EnemyBullets, SpriteLoader.LoadSprite("redBullet"), obj["speed"].ToObject<float>(), obj["amount"].ToObject<int>(), obj["interval"].ToObject<float>(), obj["fireCount"].ToObject<int>());
                case "none":
                    return new NoShootPattern(BulletManager.Instance.EnemyBullets, obj["time"].ToObject<double>());
            }
            return null;
        }
    }
}
