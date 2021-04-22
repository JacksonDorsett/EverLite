// <copyright file="GameState.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.GameState
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EverLite;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    /// <summary>
    /// Represents game state.
    /// </summary>
    public abstract class GameState
    {
        private SpriteBatch spriteBatch;
        //private GameStateContext mContext;
        private Game1 mGame;
        /// <summary>
        /// Initializes a new instance of the <see cref="GameState"/> class.
        /// </summary>
        /// <param name="game">context for gamestate.</param>
        public GameState(Game1 game)
        {
            //mContext = game.StateContext;
            mGame = game;
            spriteBatch = new SpriteBatch(game.GraphicsDevice);
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="GameState"/> class.
        /// </summary>
        ~GameState()
        {
            OnExit();
        }

        /// <summary>
        /// Gets the game context object.
        /// </summary>
        protected Game1 Game
        {
            get
            {
                return mGame;
            }
        }

        /// <summary>
        /// Gets the state handler for changing states.
        /// </summary>
        protected GameStateContext StateContext
        {
            get
            {
                return mGame.StateContext;
            }
        }

        /// <summary>
        /// Gets Game's Sprite batch.
        /// </summary>
        protected SpriteBatch SpriteBatch
        {
            get
            {
                return spriteBatch;
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

        /// <summary>
        /// Called when Gamestate is entered.
        /// </summary>
        public abstract void OnEnter();

        /// <summary>
        /// Called by subclass to determine exit state behavior.
        /// </summary>
        public abstract void OnExit();
    }
}
