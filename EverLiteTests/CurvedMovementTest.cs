using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using EverLite.Modules.Behavior;
using Microsoft.Xna.Framework;

namespace EverLiteTests
{
    class CurvedMovementTest
    {
        [Test]
        public void TestInit()
        {
            Vector2 pi = new Vector2(0, 0);
            Vector2 pm = new Vector2(5, 5);
            Vector2 pf = new Vector2(10, 0);
            CurvedMovement cm = new CurvedMovement(pi, pf, pm);
            Assert.AreEqual(pi, cm.GetPosition(0));
            Assert.AreEqual(pf, cm.GetPosition(1));
            Assert.AreEqual(pm, cm.GetPosition(.5));
        }

        [Test]
        public void TestIsNotLeft()
        {
            Vector2 pi = new Vector2(1, 0);
            Vector2 pm = new Vector2(.5f, 0);
            Vector2 pf = new Vector2(0, 0);
            CurvedMovement cm = new CurvedMovement(pi, pf, pm);
            Assert.AreEqual(new Vector2(.7f, 0), cm.GetPosition(.3));
        }
    }
}
