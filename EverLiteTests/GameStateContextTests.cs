using NUnit.Framework;
using EverLite.Utilities;
using EverLite;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace EverLiteTests
{
    class GameStateContextTests
    {
        private class TestState1 : GameState
        {
            public TestState1() : base(new Game1())
            {

            }

            public override void Draw(GameTime gameTime)
            {
            }

            public override void OnEnter()
            {
            }

            public override void Update(GameTime gameTime)
            {
            }

            protected override void OnExit()
            {
            }

            public void Transition()
            {

            }
        }
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestCurrentStateWithNoUpdate()
        {

        }
    }
}
