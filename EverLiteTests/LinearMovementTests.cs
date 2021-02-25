using System;
using System.Collections.Generic;
using System.Text;

namespace EverLiteTests
{
    using NUnit.Framework;
    using EverLite.Modules.Behavior;
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    class LinearMovementTests
    {
        [Test]
        public void TestVerticalLine()
        {
            LinearMovement t = new LinearMovement(Vector2.Zero, new Vector2(0, 10));
            Assert.AreEqual(new Vector2(0, 0), t.GetPosition(0));
            Assert.AreEqual(new Vector2(0, 10), t.GetPosition(1));
            Assert.AreEqual(new Vector2(0, 5), t.GetPosition(.5f));
        }
        public void TestHorizontalLine()
        {
            LinearMovement t = new LinearMovement(Vector2.Zero, new Vector2(10,0));
            Assert.AreEqual(new Vector2(0, 0), t.GetPosition(0));
            Assert.AreEqual(new Vector2(10,0), t.GetPosition(1));
            Assert.AreEqual(new Vector2(5,0), t.GetPosition(.5f));
        }
    }
}
