using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using global::EverLite.ScriptInterperiter;

namespace EverLite.Models.Enemies
{
    class WaveBuilder
    {
        MovementInterperiter moveInterpereter;
        List<LifetimeEntity> enemies;
        List<LifetimeEntity> bulletSpawners;
        public WaveBuilder(List<LifetimeEntity> enemyList, List<LifetimeEntity> spawners)
        {
            moveInterpereter = new MovementInterperiter();
            this.enemies = enemyList;
            this.bulletSpawners = spawners;
        }

        public Wave[] ParseWaves(string scriptName)
        {
            var json = JToken.Parse(File.ReadAllText(scriptName));
            //json = json["waves"];
            List<Wave> waves = new List<Wave>();
            foreach(var o in json["waves"])
            {
                waves.Add(Parse(o));
            }
            return waves.ToArray();
        }
        private Wave Parse(JToken obj)
        {
            
            string type = obj["type"].ToString();
            int health = obj["health"].ToObject<int>();
            int startTime = obj["startTime"].ToObject<int>();
            int spawnCount = obj["spawnCount"].ToObject<int>();
            double spawnInterval = obj["interval"].ToObject<double>();
            float delay = obj["shootingPattern"]["delay"].ToObject<float>();
            Movement movement = moveInterpereter.Interperit(obj["movement"]);
            BulletSpawnerInterpereter bsi = new BulletSpawnerInterpereter(movement);
            var pattern = bsi.Interperet(obj["shootingPattern"]);

            return new Wave(new EnemyFactory(enemies, this.bulletSpawners,pattern,EnemySpriteFactory.Create(type),movement, health,delay),spawnInterval,spawnCount, startTime);

        }
    }

    
}
