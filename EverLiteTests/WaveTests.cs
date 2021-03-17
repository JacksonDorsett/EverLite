using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using EverLite.Modules.Wave;
using EverLite.Modules.Blaster;
using EverLite.Modules.Enemies;
using Microsoft.Xna.Framework;

namespace EverLiteTests
{
    class WaveTests
    {
        [Test]
        public void SpawnTest()
        {
            var t1 = new TimeSpan(0, 0, 0, 0, 100);
            var t2 = new TimeSpan(0, 0, 0, 0, 200);
            List<Enemy> enemies = new List<Enemy>();
            Wave w = new Wave(enemies, new EnemyFactory(null, null, null, 1), 200d, 3, 0);
            w.Update(new GameTime(t1, t1));
            Assert.AreEqual(0, enemies.Count);
            w.Update(new GameTime(t1, t2));
            Assert.AreEqual(1, enemies.Count);
            w.Update(new GameTime(t1, t1));
            Assert.AreEqual(2, enemies.Count);
            w.Update(new GameTime(t2, t2));
            Assert.AreEqual(3, enemies.Count);
            Assert.IsFalse(w.IsWaveActive);
            w.Update(new GameTime(t2, t2));
            Assert.AreEqual(3, enemies.Count);
        }
    }
}
