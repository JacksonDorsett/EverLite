// <copyright file="Game1.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite
{
    using System.Collections.Generic;
    using EverLite.Models;
    using EverLite.Models.Sprites;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    /// <summary>
    /// Main game class.
    /// </summary>
    public class Game1 : Game
    {
        private GraphicsDeviceManager mGraphics;
        private SpriteBatch mSpriteBatch;
        private Sprite player;
        private List<Sprite> bullets = new List<Sprite>();

        private PlayerSystem playerSystem;
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
            base.Initialize();
        }

        /// <summary>
        /// Loads game content into this.Content.
        /// </summary>
        protected override void LoadContent()
        {
            this.mSpriteBatch = new SpriteBatch(this.GraphicsDevice);

            this.mGraphics.GraphicsProfile = GraphicsProfile.Reach;
            this.mGraphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            this.mGraphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            this.mGraphics.HardwareModeSwitch = false;
            this.mGraphics.ApplyChanges();

            this.playerSystem = new PlayerSystem(this.Content, this.GraphicsDevice);
        }

        /// <summary>
        /// Updates every game loop cycle. Used for updating game logic.
        /// </summary>
        /// <param name="gameTime">time passed every cycle.</param>
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                this.IsPaused = !this.IsPaused;
            }

            if (!this.IsPaused)
            {
                this.playerSystem.Update(this.mGraphics.GraphicsDevice, gameTime);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// Called every gameloop cycle. Draws entities to the screen.
        /// </summary>
        /// <param name="gameTime">time elapsed in cycle.</param>
        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.Black);

            this.mSpriteBatch.Begin();
            this.playerSystem.Draw(this.mSpriteBatch);

            this.mSpriteBatch.End();

            // TODO: Add your drawing code here
            base.Draw(gameTime);
        }
    }
}
