// <copyright file="PlayGameState.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EverLite.Audio;
    using EverLite.Models;
    using EverLite.Models.Sprites;
    using EverLite.Modules;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    /// <summary>
    /// Gamestate representing when game is being played.
    /// </summary>
    public class PlayGameState : GameState
    {
        private ScrollingBG scrollingBG;
        private PlayerSystem playerSystem;
        private EnemySystem enemySystem;
        public bool IsPaused = false; // Encapsulate or further refactor.
        private Sprite player;
        private List<Sprite> bullets = new List<Sprite>();

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayGameState"/> class.
        /// </summary>
        /// <param name="game">Game object linked to the gamestate.</param>
        public PlayGameState(Game1 game)
            : base(game)
        {
            this.scrollingBG = new ScrollingBG(game);
            this.enemySystem = new EnemySystem(this.Game.Content, this.Game.GraphicsDevice);
            this.playerSystem = new PlayerSystem(this.Game);
        }

        /// <summary>
        /// Draws the current game state.
        /// </summary>
        /// <param name="gameTime">Time elapsed during game cycle.</param>
        public override void Draw(GameTime gameTime)
        {
            this.scrollingBG.Draw(gameTime);
            this.playerSystem.Draw(this.SpriteBatch);
            this.enemySystem.Draw(this.SpriteBatch);
        }

        /// <summary>
        /// Plays the Bgm when starting.
        /// </summary>
        public override void OnEnter()
        {
            BGM.Instance(this.Game).Load("Solar System");
        }

        /// <summary>
        /// Updates the current gamestate.
        /// </summary>
        /// <param name="gameTime">Time elapsed during game cycle.</param>
        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                this.IsPaused = !this.IsPaused;
            }

            if (!this.IsPaused)
            {
                this.playerSystem.Update(this.Game.GraphicsDevice, gameTime);
                this.enemySystem.Update(this.Game.GraphicsDevice, gameTime);
            }

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
