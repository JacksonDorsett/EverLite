// <copyright file="Game1.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite
{
    using System;
    using System.Collections.Generic;
    using EverLite.Models;
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
            this.player = SpriteFactory.CreateSprite(FactoryEnum.Player);
            base.Initialize();
        }

        /// <summary>
        /// Loads game content into this.Content.
        /// </summary>
        protected override void LoadContent()
        {
            this.mSpriteBatch = new SpriteBatch(this.GraphicsDevice);

            this.LoadPlayer();
        }

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

            this.player.Update();
            base.Update(gameTime);
        }

        /// <summary>
        /// Called every gameloop cycle. Draws entities to the screen.
        /// </summary>
        /// <param name="gameTime">time elapsed in cycle.</param>
        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.Aquamarine);

            this.mSpriteBatch.Begin();
            this.player.Draw(this.mSpriteBatch);
            this.mSpriteBatch.End();

            // TODO: Add your drawing code here
            base.Draw(gameTime);
        }

        /// <summary>
        /// Initializes the player icon.
        /// </summary>
        private void LoadPlayer()
        {
            Vector2 playerPosition = new Vector2(this.GraphicsDevice.Viewport.TitleSafeArea.X + (this.GraphicsDevice.Viewport.TitleSafeArea.Width / 5), this.GraphicsDevice.Viewport.TitleSafeArea.Y + (this.GraphicsDevice.Viewport.TitleSafeArea.Height / 2));
            this.player.Initialize(this.Content.Load<Texture2D>("Player"), playerPosition);
        }
    }
}
