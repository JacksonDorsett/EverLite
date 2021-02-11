// <copyright file="GameState.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Represents game state.
    /// </summary>
    public abstract class GameState
    {
        private Game mGame;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameState"/> class.
        /// </summary>
        /// <param name="game">context for gamestate.</param>
        public GameState(Game game)
        {
            this.mGame = game;
        }

        /// <summary>
        /// Gets the game context object.
        /// </summary>
        public Game Game
        {
            get
            {
                return this.mGame;
            }
        }

        /// <summary>
        /// Updates the gamestate every game cycle.
        /// </summary>
        /// <param name="gameTime">time elapsed during the cycle.</param>
        public abstract void Update(GameTime gameTime);

        /// <summary>
        /// Draws the gamestate every game cycle.
        /// </summary>
        /// <param name="gameTime">time elapsed during the cycle.</param>
        public abstract void Draw(GameTime gameTime);
    }
}
