// <copyright file="GameStateContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Manages the games context.
    /// </summary>
    public class GameStateContext
    {
        private GameState currentState;
        private GameState nextState;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameStateContext"/> class.
        /// </summary>
        /// <param name="game">context game object.</param>
        public GameStateContext(Game1 game)
        {
            this.currentState = new MenuState(game);
        }

        /// <summary>
        /// Gets or sets the current state that the game is in.
        /// Note: This could be a code smell (Bad encalsulation).
        /// </summary>
        internal GameState CurrentState
        {
            get
            {
                return this.currentState;
            }

            set
            {
                this.currentState = value;
            }
        }

        /// <summary>
        /// Switches the gameStates.
        /// </summary>
        /// <param name="newState"></param>
        public void SetState(GameState newState)
        {
            this.nextState = newState;
        }

        /// <summary>
        /// Updates the current game state.
        /// </summary>
        /// <param name="gameTime">game time in last game cycle.</param>
        public void Update(GameTime gameTime)
        {
            this.UpdateState();
            this.currentState.Update(gameTime);
        }

        /// <summary>
        /// Draws the current game state.
        /// </summary>
        /// <param name="gameTime">game time in last game cycle.</param>
        public void Draw(GameTime gameTime)
        {
            this.currentState.Draw(gameTime);
        }

        private void UpdateState()
        {
            if (this.nextState != null)
            {
                this.currentState = this.nextState;
                this.nextState = null;
                this.currentState.OnEnter();
            }
        }
    }
}
