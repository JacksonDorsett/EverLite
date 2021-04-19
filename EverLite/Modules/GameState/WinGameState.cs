// <copyright file="WinGameState.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.GameState
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class WinGameState : GameState
    {
        public WinGameState(Game1 game)
            : base(game)
        {
        }

        public override void Draw(GameTime gameTime)
        {
            this.SpriteBatch.Begin();
            this.SpriteBatch.DrawString(this.Game.fontOriginTech, "You Win!", new Vector2(this.Game.Window.ClientBounds.Width / 2, this.Game.Window.ClientBounds.Height / 4), Color.Green, 0, new Vector2(.5f, .5f), 1, SpriteEffects.None, 0);
            this.SpriteBatch.DrawString(this.Game.fontOriginTech, "SCORE ", new Vector2(this.Game.Window.ClientBounds.Width / 2, (this.Game.Window.ClientBounds.Height / 4) + 120), Color.Yellow, 0, new Vector2(.5f, .5f), 1, SpriteEffects.None, 0);
            this.SpriteBatch.DrawString(this.Game.fontOriginTechSmall, this.Game.score.Score.ToString(), new Vector2(this.Game.Window.ClientBounds.Width / 2, (this.Game.Window.ClientBounds.Height / 4) + 180), Color.Yellow, 0, new Vector2(.5f, .5f), 1, SpriteEffects.None, 0);
            this.SpriteBatch.DrawString(this.Game.fontOriginTech, "Top Scores", new Vector2(this.Game.Window.ClientBounds.Width / 2, (this.Game.Window.ClientBounds.Height / 4) + 240), Color.Blue, 0, new Vector2(.5f, .5f), 1, SpriteEffects.None, 0);
            this.SpriteBatch.DrawString(this.Game.fontOriginTechSmall, this.Game.score.TopScore.ToString(), new Vector2(this.Game.Window.ClientBounds.Width / 2, (this.Game.Window.ClientBounds.Height / 4) + 280), Color.Blue, 0, new Vector2(.5f, .5f), 1, SpriteEffects.None, 0);
            this.SpriteBatch.End();
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