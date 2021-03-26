using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using EverLite.Modules.Sprites;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EverLiteTests
{
    class SpriteLoaderTests
    {
        [Test]
        public void TestBadInitialization()
        {
            SpriteLoader s;
            Assert.Throws<NullReferenceException>(()=>s = SpriteLoader.Instance);

        }

        [Test]
        public void TestGetInstance()
        {

        }
    }
}
