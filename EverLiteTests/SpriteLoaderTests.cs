using EverLite.Modules.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EverLiteTests
{
    class SpriteLoaderTests
    {
        [Test]
        public void TestBadInitialization()
        {
            SpriteLoader s;
            Assert.Throws<NullReferenceException>(() => s = SpriteLoader.Instance);

        }

        [Test]
        public void TestGetInstance()
        {

        }
    }
}
