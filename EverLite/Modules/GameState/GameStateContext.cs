﻿// <copyright file="GameStateContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.GameState
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EverLite;
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
            currentState = new MenuState(game);
        }

        /// <summary>
        /// Gets or sets the current state that the game is in.
        /// Note: This could be a code smell (Bad encalsulation).
        /// </summary>
        internal GameState CurrentState
        {
            get
            {
                return currentState;
            }

            set
            {
                currentState = value;
            }
        }

        /// <summary>
        /// Switches the gameStates.
        /// </summary>
        /// <param name="newState">Next state.</param>
        public void SetState(GameState newState)
        {
            nextState = newState;
        }

        /// <summary>
        /// Updates the current game state.
        /// </summary>
        /// <param name="gameTime">game time in last game cycle.</param>
        public void Update(GameTime gameTime)
        {
            UpdateState();
            currentState.Update(gameTime);
        }

        /// <summary>
        /// Draws the current game state.
        /// </summary>
        /// <param name="gameTime">game time in last game cycle.</param>
        public void Draw(GameTime gameTime)
        {
            currentState.Draw(gameTime);
        }

        private void UpdateState()
        {
            if (nextState != null)
            {
                currentState = nextState;
                nextState = null;
                currentState.OnEnter();
            }
        }
    }
}
