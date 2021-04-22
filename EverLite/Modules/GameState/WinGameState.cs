// <copyright file="WinGameState.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.GameState
{
    using EverLite.Audio;
    using EverLite.Modules.Menu.Commands;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

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
            this.SpriteBatch.DrawString(this.Game.fontOriginTech, "Play again (Y/N)?", new Vector2(1000, 500), Color.Green);
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
            BGM.Instance(this.Game).Stop();
        }

        /// <inheritdoc/>
        public override void Update(GameTime gameTime)
        {
            if (this.Game.NewKey(Keys.Y))
            {
                //this.Game.StateContext.GoToMenuState;
                //new ChangeStateCommand(this.Game, new MenuState(this.Game.StateContext.GoToMenuState)).Execute();
                //this.Game.StateContext = new GameStateContext(this.Game);
                this.Game.GoToMain();
            }
        }
    }
}