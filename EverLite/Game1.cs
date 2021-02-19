// <copyright file="Game1.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Modules.Enemies;
    using Modules;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Main game class.
    /// </summary>
    public class Game1 : Game
    {
        private GraphicsDeviceManager mGraphics;
        private SpriteBatch mSpriteBatch;
        private EnemySystem enemySystem;

        //Game World
        List<Enemy> enemies = new List<Enemy>();
        Random random = new Random();

        public bool IsPaused = false;


        /// <summary>
        /// Initializes a new instance of the <see cref="Game1"/> class.
        /// </summary>
        public Game1()
        {
            this.mGraphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
        }

        /// <summary>
        /// Function called at instantiation. Initialized the game object.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        /// <summary>
        /// Loads game content into this.Content.
        /// </summary>
        protected override void LoadContent()
        {
            this.mSpriteBatch = new SpriteBatch(this.GraphicsDevice);

            // TODO: use this.Content to load your game content here
            this.enemySystem = new EnemySystem(this.Content);
        }

        float spawn = 0;

        /// <summary>
        /// Updates every game loop cycle. Used for updating game logic.
        /// </summary>
        /// <param name="gameTime">time passed every cycle.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                this.IsPaused = !this.IsPaused;
            }

            if (!this.IsPaused)
            {
                this.enemySystem.Update(this.mGraphics.GraphicsDevice, gameTime);
            }
            
            // TODO: Add your update logic here
            base.Update(gameTime);
        }

        /// <summary>
        /// Called every gameloop cycle. Draws entities to the screen.
        /// </summary>
        /// <param name="gameTime">time elapsed in cycle.</param>
        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.CornflowerBlue);

            mSpriteBatch.Begin();
            this.enemySystem.Draw(this.mSpriteBatch);
            mSpriteBatch.End();
            // TODO: Add your drawing code here
            base.Draw(gameTime);
        }
    }
}
