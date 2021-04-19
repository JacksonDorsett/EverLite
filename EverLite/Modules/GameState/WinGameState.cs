// <copyright file="PlayGameState.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EverLite.Modules.GameState
{
    internal class WinGameState : GameState
    {
        SpriteFont mFont;
        Game1 game1;
        Vector2 vector;

        public WinGameState(Game1 game)
            : base(game)
        {
            mFont = Game.Content.Load<SpriteFont>("Default");
            this.game1 = game;
            vector = new Vector2(Game.Window.ClientBounds.Width / 2, Game.Window.ClientBounds.Height / 4);
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin();
            SpriteBatch.DrawString(mFont, "You Win!", new Vector2(Game.Window.ClientBounds.Width / 2, Game.Window.ClientBounds.Height / 4), Color.Green, 0, new Vector2(.5f, .5f), 1, SpriteEffects.None, 0);
            SpriteBatch.DrawString(mFont, "sCoRe ", new Vector2(Game.Window.ClientBounds.Width / 2, Game.Window.ClientBounds.Height / 4 + 120), Color.Green, 0, new Vector2(.5f, .5f), 1, SpriteEffects.None, 0);
            SpriteBatch.DrawString(mFont, this.game1.score.Score.ToString(), new Vector2(Game.Window.ClientBounds.Width / 2, Game.Window.ClientBounds.Height / 4 + 180), Color.Green, 0, new Vector2(.5f, .5f), 1, SpriteEffects.None, 0);
            SpriteBatch.End();
        }

        public override void OnEnter()
        {

        }

        public override void OnExit()
        {

        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}