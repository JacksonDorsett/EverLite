using EverLite;
using EverLite.Modules.GameState;
using EverLite.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NUnit.Framework;
using System;

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


            public void Transition()
            {

            }

            public override void OnExit()
            {
                throw new NotImplementedException();
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
