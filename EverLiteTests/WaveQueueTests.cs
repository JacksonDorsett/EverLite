using EverLite.Modules.Wave;
using EverLite.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NUnit.Framework;
using System;

namespace EverLiteTests
{
    class WaveQueueTests
    {
        [Test]
        public void TestThrowsException()
        {
            GameClock clock = new GameClock();
            WaveQueue q = new WaveQueue(clock);
            Assert.Throws<Exception>(() => q.PopWave());
            //q.Add(new Wave(null, null, null,null, 0, 0, 100));
            Assert.Throws<Exception>(() => q.PopWave());

        }

        [Test]
        public void TestPopWave()
        {/*
            GameClock clock = new GameClock();
            clock.Start();
            WaveQueue q = new WaveQueue(clock);
            Assert.AreEqual(false, q.IsReady);
            //Wave w1 = new Wave(null, null, null, null, 0, 0, 0);
            //Wave w2 = new Wave(null, null, null, null, 0, 0, 1);
            q.Add(w1);
            q.Add(w2);
            Assert.AreEqual(true, q.IsReady);
            Assert.AreSame(w1, q.PopWave());

            Assert.AreEqual(false, q.IsReady);
            clock.Update(new GameTime(new TimeSpan(0, 0, 10), new TimeSpan(0, 0, 10)));
            Assert.IsTrue(q.IsReady);
            Assert.AreSame(w2, q.PopWave());
            Assert.AreEqual(false, q.IsReady);

            */
        }

        [Test]
        public void TestPopAtSameTime()
        {/*
            GameClock clock = new GameClock();
            clock.Start();
            WaveQueue q = new WaveQueue(clock);
            Assert.AreEqual(false, q.IsReady);
            //Wave w1 = new Wave(null, null, null, null, 0, 0, 1);
            //Wave w2 = new Wave(null, null, null, null, 0, 0, 1);
            q.Add(w1);
            q.Add(w2);
            Assert.IsFalse(q.IsReady);
            clock.Update(new GameTime(new TimeSpan(0, 1, 1), new TimeSpan(0, 1, 1)));
            Assert.AreSame(w1, q.PopWave());
            Assert.AreSame(w2, q.PopWave());
            */
        }
    }
}
