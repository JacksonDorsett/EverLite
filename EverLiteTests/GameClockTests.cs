using NUnit.Framework;
using EverLite.Utilities;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace EverLiteTests
{
    public class GameClockTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestUpdate()
        {
            GameClock gc = new GameClock();
            Assert.AreEqual(new TimeSpan(0), gc.ElapsedTime);
            //test Update
            GameTime gt = new GameTime(new TimeSpan(100), new TimeSpan(100));

            gc.Update(gt);
            Assert.AreEqual(new TimeSpan(0), gc.ElapsedTime);
            //test Update
            gc.Start();
            gc.Update(gt);
            Assert.AreEqual(new TimeSpan(100), gc.ElapsedTime);

        }
        [Test]
        public void TestResetWhileUnpaused()
        {
            GameClock gc = new GameClock();
            gc.Start();
            GameTime gt = new GameTime(new TimeSpan(100), new TimeSpan(100));
            gc.Update(gt);
            Assert.AreEqual(new TimeSpan(100), gc.ElapsedTime);
            gc.Reset();
            Assert.AreEqual(new TimeSpan(), gc.ElapsedTime);
            gc.Update(gt);
            Assert.AreEqual(new TimeSpan(100), gc.ElapsedTime);
        }
        [Test]
        public void TestResetWhilePaused()
        {
            GameClock gc = new GameClock();
            gc.Start();
            GameTime gt = new GameTime(new TimeSpan(100), new TimeSpan(100));
            gc.Update(gt);
            Assert.AreEqual(new TimeSpan(100), gc.ElapsedTime);
            gc.Pause();
            gc.Reset();
            Assert.AreEqual(new TimeSpan(), gc.ElapsedTime);
            gc.Update(gt);
            Assert.AreEqual(new TimeSpan(0), gc.ElapsedTime);
        }
    }
}