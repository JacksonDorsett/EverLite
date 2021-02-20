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
        private KeyboardState pastKey;

        //Bullets
        List<Sprite> bullets = new List<Sprite>();
        Sprite theBullet;

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
            this.theBullet = SpriteFactory.CreateSprite(FactoryEnum.Bullets);
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

            this.player.Update(gameTime);

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || (Keyboard.GetState().IsKeyDown(Keys.D) && this.pastKey.IsKeyUp(Keys.Space)))
            {
                this.Shoot();
            }

            this.pastKey = Keyboard.GetState();
            this.UpdateBullets();
            base.Update(gameTime);
        }

        public void UpdateBullets()
        {
            foreach (Bullets bullet in this.bullets)
            {
                bullet.sPosition += bullet.Velocity;
                if (Vector2.Distance(bullet.sPosition, this.player.sPosition) > 1000)
                {
                    bullet.isVisible = false;
                }
            }

            for (int index = 0; index < this.bullets.Count; index++)
            {
                if (!this.bullets[index].isVisible)
                {
                    this.bullets.RemoveAt(index);
                    index--;
                }
            }
        }

        public void Shoot()
        {
            Vector2 playerPosition = new Vector2(this.player.GetPosition().X, this.player.GetPosition().Y);
            Sprite newBullet = SpriteFactory.CreateSprite(FactoryEnum.Bullets);
            newBullet.Initialize(this.Content.Load<Texture2D>("TinyBlue"), playerPosition);
            newBullet.isVisible = true;

            if (this.bullets.Count < 20)
            {
                this.bullets.Add(newBullet);
            }
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
            foreach (Bullets bullet in this.bullets)
            {
                bullet.Draw(this.mSpriteBatch);
            }

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
            this.player.Initialize(this.Content.Load<Texture2D>("Biplane"), playerPosition);
        }
    }
}
