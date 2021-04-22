// <copyright file="GameOverGameState.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.GameState
{
    using EverLite.Audio;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    /// <summary>
    /// Game Over window. Displays player score and high score.
    /// </summary>
    public class GameOverGameState : GameState
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GameOverGameState"/> class.
        /// </summary>
        /// <param name="game">Access to the fonts and game window bounds.</param>
        public GameOverGameState(Game1 game)
            : base(game)
        {
        }

        /// <summary>
        /// Draws the text in the Game Over window.
        /// </summary>
        /// <param name="gameTime">Access to the fonts and game window bounds.</param>
        public override void Draw(GameTime gameTime)
        {
            this.Game.score.AddTopScore(this.Game.score.Score);
            this.SpriteBatch.Begin();
            this.SpriteBatch.DrawString(this.Game.fontOriginTech, "Play again (Y/N)?", new Vector2(1000, 500), Color.Green);
            this.SpriteBatch.DrawString(this.Game.fontOriginTech, "GAME OVER", new Vector2(500, 150), Color.Red);
            this.SpriteBatch.DrawString(this.Game.fontOriginTech, "SCORE ", new Vector2(500, 210), Color.Blue);
            this.SpriteBatch.DrawString(this.Game.fontOriginTechSmall, this.Game.score.Score.ToString(), new Vector2(500, 250), Color.Yellow);
            this.SpriteBatch.DrawString(this.Game.fontOriginTech, "Top Scores", new Vector2(500, 300), Color.Blue);
            this.SpriteBatch.DrawString(this.Game.fontOriginTechSmall, this.Game.score.TopScore.ToString(), new Vector2(500, 350), Color.Yellow);
            this.SpriteBatch.End();
        }

        /// <inheritdoc/>
        public override void OnEnter()
        {
        }

        /// <inheritdoc/>
        public override void OnExit()
        {
            BGM.Instance(this.Game).Stop();
        }

        /// <inheritdoc/>
        public override void Update(GameTime gameTime)
        {
            if (this.Game.NewKey(Keys.Y))
            {
                //this.Game.StateContext = new GameStateContext(this.Game);
                this.Game.GoToMain();
            }
        }
    }
}
