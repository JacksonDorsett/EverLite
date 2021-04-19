// <copyright file="WinGameState.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.GameState
{
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Displays the Winner window with the player score and high score.
    /// </summary>
    internal class WinGameState : GameState
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WinGameState"/> class.
        /// </summary>
        /// <param name="game">Access to the fonts and game window bounds.</param>
        public WinGameState(Game1 game)
            : base(game)
        {
        }

        /// <summary>
        /// Draws the text in the Winner window.
        /// </summary>
        /// <param name="gameTime">Access to the fonts and game window bounds.</param>
        public override void Draw(GameTime gameTime)
        {
            this.Game.score.AddTopScore(this.Game.score.Score);
            this.SpriteBatch.Begin();
            this.SpriteBatch.DrawString(this.Game.fontOriginTech, "You Win!", new Vector2(this.Game.Window.ClientBounds.Width / 2, this.Game.Window.ClientBounds.Height / 4), Color.Green);
            this.SpriteBatch.DrawString(this.Game.fontOriginTech, "SCORE ", new Vector2(this.Game.Window.ClientBounds.Width / 2, (this.Game.Window.ClientBounds.Height / 4) + 120), Color.Blue);
            this.SpriteBatch.DrawString(this.Game.fontOriginTechSmall, this.Game.score.Score.ToString(), new Vector2(this.Game.Window.ClientBounds.Width / 2, (this.Game.Window.ClientBounds.Height / 4) + 180), Color.Yellow);
            this.SpriteBatch.DrawString(this.Game.fontOriginTech, "Top Scores", new Vector2(this.Game.Window.ClientBounds.Width / 2, (this.Game.Window.ClientBounds.Height / 4) + 260), Color.Blue);
            this.SpriteBatch.DrawString(this.Game.fontOriginTechSmall, this.Game.score.TopScore.ToString(), new Vector2(this.Game.Window.ClientBounds.Width / 2, (this.Game.Window.ClientBounds.Height / 4) + 300), Color.Yellow);
            this.SpriteBatch.End();
        }

        /// <inheritdoc/>
        public override void OnEnter()
        {
        }

        /// <inheritdoc/>
        public override void OnExit()
        {
        }

        /// <inheritdoc/>
        public override void Update(GameTime gameTime)
        {
        }
    }
}