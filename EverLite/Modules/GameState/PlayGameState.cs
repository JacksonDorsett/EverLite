// <copyright file="PlayGameState.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.GameState
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EverLite;
    using EverLite.Audio;
    using EverLite.Modules;
    using EverLite.Modules.Enemies;
    using EverLite.Modules.Graphics;
    using EverLite.Modules.Input;
    using EverLite.Modules.Sprites;
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
        // private EnemySystem enemySystem;
        private ToggleStatus pauseStatus;
        private EnemyManager enemyManager;
        private BulletManager bulletManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayGameState"/> class.
        /// </summary>
        /// <param name="game">Game object linked to the gamestate.</param>
        public PlayGameState(Game1 game)
            : base(game)
        {
            SpriteLoader.Initialize(game.Content);
            this.playerSystem = new PlayerSystem(this.Game);
            this.scrollingBG = new ScrollingBG(game);
            this.pauseStatus = new ToggleStatus(Keys.Space);
            this.enemyManager = new EnemyManager(this.Game);
            this.bulletManager = BulletManager.Instance;
        }

        /// <summary>
        /// Draws the current game state.
        /// </summary>
        /// <param name="gameTime">Time elapsed during game cycle.</param>
        public override void Draw(GameTime gameTime)
        {
            this.scrollingBG.Draw(gameTime);
            this.bulletManager.Draw(SpriteBatch);
            this.playerSystem.Draw(SpriteBatch);
            //this.enemySystem.Draw(SpriteBatch);
            this.enemyManager.Draw(this.SpriteBatch);
        }

        /// <summary>
        /// Plays the Bgm when starting.
        /// </summary>
        public override void OnEnter()
        {
            BGM.Instance(this.Game).Load("DeepSpace");
        }

        /// <summary>
        /// Updates the current gamestate.
        /// </summary>
        /// <param name="gameTime">Time elapsed during game cycle.</param>
        public override void Update(GameTime gameTime)
        {
            // check if game is paused.
            this.pauseStatus.Update();

            if (!this.pauseStatus.Status)
            {
                this.playerSystem.Update(gameTime);
                //this.enemySystem.Update(gameTime);
                this.scrollingBG.Update(gameTime);
                this.enemyManager.Update(gameTime);
                this.bulletManager.Update(gameTime);
            }
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
