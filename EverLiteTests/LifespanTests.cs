using NUnit.Framework;
using EverLite.Utilities;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using EverLite.Modules.Enemies;

namespace EverLiteTests
{
    class LifespanTests
    {
        [Test]
        public void TestInitialization()
        {
            Lifespan lifespan = new Lifespan(2);
            Assert.AreEqual(0, lifespan.Halflife);
        }

        [Test]
        public void TestTimePassing()
        {
            Lifespan ls = new Lifespan(1);
            TimeSpan ts = new TimeSpan(0, 0, 0, 0, 500);
            GameTime gt = new GameTime(ts, ts);
            ls.Update(gt);
            Assert.AreEqual(.5, ls.Halflife);
            ls.Update(gt);
            Assert.AreEqual(1, ls.Halflife);
        }
    }
}
