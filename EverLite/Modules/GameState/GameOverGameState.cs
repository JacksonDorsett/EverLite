using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace EverLite.Modules.GameState
{
    class GameOverGameState : GameState
    {
        SpriteFont mFont;
        public GameOverGameState(Game1 game)
            : base(game)
        {
            mFont = Game.Content.Load<SpriteFont>("Default");
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin();
            SpriteBatch.DrawString(mFont, "GAME OVER", new Vector2(Game.Window.ClientBounds.X / 2, Game.Window.ClientBounds.Y / 2), Color.Red, 0, new Vector2(.5f,.5f),1, SpriteEffects.None, 0);
            SpriteBatch.End();
        }

        public override void OnEnter()
        {

        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void OnExit()
        {

        }
    }
}
