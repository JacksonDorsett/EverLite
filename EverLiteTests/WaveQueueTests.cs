using NUnit.Framework;
using EverLite.Utilities;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using EverLite.Modules.Wave;

namespace EverLiteTests
{
    class WaveQueueTests
    {
        [Test]
        public void TestThrowsException()
        {
            GameClock clock = new GameClock();
            WaveQueue q = new WaveQueue(clock);
            Assert.Throws<Exception>(()=>q.PopWave());
            q.Add(new Wave(null, null, 0, 0, 100));
            Assert.Throws<Exception>(() => q.PopWave());
            
        }

        [Test]
        public void TestPopWave()
        {
            GameClock clock = new GameClock();
            WaveQueue q = new WaveQueue(clock);
            Assert.AreEqual(false, q.IsReady);
            Wave w1 = new Wave(null, null, 0, 0, 0);
            Wave w2 = new Wave(null, null, 0, 0, 1);
            q.Add(w1);
            q.Add(w2);
            Assert.AreEqual(true, q.IsReady);
            Assert.AreSame(w1, q.PopWave());
            Assert.AreEqual(true, q.IsReady);
            Assert.AreSame(w2, q.PopWave());
            Assert.AreEqual(false, q.IsReady);


        }
    }
}
