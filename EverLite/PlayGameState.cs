// <copyright file="PlayGameState.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Gamestate representing when game is being played.
    /// </summary>
    public class PlayGameState : GameState
    {
        private ScrollingBG scrollingBG;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayGameState"/> class.
        /// </summary>
        /// <param name="game">Game object linked to the gamestate.</param>
        public PlayGameState(Game1 game)
            : base(game)
        {
            this.scrollingBG = new ScrollingBG(game);
        }

        /// <summary>
        /// Draws the current game state.
        /// </summary>
        /// <param name="gameTime">Time elapsed during game cycle.</param>
        public override void Draw(GameTime gameTime)
        {
            this.scrollingBG.Draw(gameTime);
        }

        /// <summary>
        /// Plays the Bgm when starting.
        /// </summary>
        public override void OnEnter()
        {
            BGM.Instance(this.Game).Load("Solar System");

            // BGM.Instance(this.Game).Play();
        }

        /// <summary>
        /// Updates the current gamestate.
        /// </summary>
        /// <param name="gameTime">Time elapsed during game cycle.</param>
        public override void Update(GameTime gameTime)
        {
            this.scrollingBG.Update(gameTime);
        }

        /// <summary>
        /// Stopps the BGM on destruction.
        /// </summary>
        protected override void OnExit()
        {
            BGM.Instance(this.Game).Stop();
        }
    }
}
