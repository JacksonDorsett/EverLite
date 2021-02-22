﻿// <copyright file="Player.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.Sprites
{
    using System;
    using EverLite.Modules.Blaster;
    using EverLite.Modules.Enums;
    using EverLite.Modules.Input;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;


    /// <summary>
    /// The Player class created will handle the special stuff the player can do.
    /// </summary>
    public class Player : Sprite
    {
        private static readonly float NORMALSPEED = 15.0f;
        private static readonly float SLOWSPEED = 5.0f;
        private readonly float scale = 0.5f;
        private readonly float layerDepth = 0.0f;
        private int screenWidth;
        private int screenHeight;
        private string currentBulletType = "TinyBlue";
        private Game mGame;
        private ToggleStatus slowSpeedStatus;
        private IBlaster blaster;
        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// Sets isActive, angle, velocity, and spriteType fields.
        /// </summary>
        /// <param name="newBulletTexture">The picture of the bullet object.</param>
        public Player()
            : base(true, 0, NORMALSPEED)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        /// <param name="game">game reference object.</param>
        public Player(Game game)
            : base(0, NORMALSPEED, game.Content.Load<Texture2D>(EnumToStringFactory.GetEnumToString(FactoryEnum.Player)), Vector2.Zero)
        {
            this.mGame = game;
            this.Initialize(game.Content.Load<Texture2D>(EnumToStringFactory.GetEnumToString(FactoryEnum.Player)), this.GetPlayerLocation());
            this.SetGameBoundary(this.mGame.GraphicsDevice.Viewport.Width, this.mGame.GraphicsDevice.Viewport.Height);
            this.blaster = new PlayerBlaster(game.Content.Load<Texture2D>("TinyBlue"));

            this.slowSpeedStatus = new ToggleStatus(Keys.G);
        }

        private void SetGameBoundary(int width, int height)
        {
            this.screenWidth = width;
            this.screenHeight = height;
        }

        private Vector2 GetPlayerLocation()
        {
            return new Vector2(mGame.GraphicsDevice.Viewport.TitleSafeArea.X + mGame.GraphicsDevice.Viewport.TitleSafeArea.Width / 2, mGame.GraphicsDevice.Viewport.TitleSafeArea.Y + mGame.GraphicsDevice.Viewport.TitleSafeArea.Height * 4 / 5);
        }

        /// <summary>
        /// This combines the Texture2D and Rectangle objects into the player for control.
        /// </summary>
        /// <param name="texture">The picture of the player object.</param>
        /// <param name="position">Starting position for the player object.</param>
        public override void Initialize(Texture2D texture, Vector2 position)
        {
            Texture = texture;
            Position = position;
        }

        public Sprite Shoot()
        {
            return this.blaster.Shoot(this.Position);
        }

        /// <inheritdoc/>
        public override void Update(GameTime gameTime)
        {
            blaster.Update(gameTime);
            KeyboardState currentKeyboardState = Keyboard.GetState();

            GamePadState currentGamePadState = GamePad.GetState(PlayerIndex.One);

            #region Player controls
            this.slowSpeedStatus.Update();
            // get current speed
            if (!this.slowSpeedStatus.Status)
            {
                this.sVelocity = NORMALSPEED;
            }
            else
            {
                this.sVelocity = SLOWSPEED;
            }

            this.Position.X += currentGamePadState.ThumbSticks.Left.X * sVelocity;

            Position.Y -= currentGamePadState.ThumbSticks.Left.Y * sVelocity;

            if (currentGamePadState.Buttons.Y == ButtonState.Pressed || currentKeyboardState.IsKeyDown(Keys.T))
            {
                ChangeBulletType();
            }

            if (currentKeyboardState.IsKeyDown(Keys.Left) || currentKeyboardState.IsKeyDown(Keys.A))
            {
                Position.X -= sVelocity;
            }

            if (currentKeyboardState.IsKeyDown(Keys.Right) || currentKeyboardState.IsKeyDown(Keys.D))
            {
                Position.X += sVelocity;
            }

            if (currentKeyboardState.IsKeyDown(Keys.Up) || currentKeyboardState.IsKeyDown(Keys.W))
            {
                Position.Y -= sVelocity;
            }

            if (currentKeyboardState.IsKeyDown(Keys.Down) || currentKeyboardState.IsKeyDown(Keys.S))
            {
                Position.Y += sVelocity;
            }
            #endregion

            CheckPlayerBoundry();
        }

        private void CheckPlayerBoundry()
        {
            if (Position.X <= 15)
            {
                Position.X = 15;
            }

            if (Position.Y <= screenHeight / 2)
            {
                Position.Y = screenHeight / 2;
            }

            if (Position.X + Texture.Width >= screenWidth)
            {
                Position.X = screenWidth - Texture.Width;
            }

            if (Position.Y + Texture.Height >= screenHeight)
            {
                Position.Y = screenHeight - Texture.Height;
            }
        }

        /// <summary>
        /// Simple feature that switches between the available choices.
        /// </summary>
        public void ChangeBulletType()
        {
            if (currentBulletType == "TinyRed")
            {
                currentBulletType = "TinyBlue";
            }
            else
            {
                currentBulletType = "TinyRed";
            }
        }

        /// <summary>
        /// Returns selected bullet type.
        /// </summary>
        /// <returns>Name of selected bullet.</returns>
        public string GetCurrentBulletType()
        {
            return currentBulletType;
        }

        /// <inheritdoc/>
        public override void Draw(SpriteBatch spriteBatch)
        {
            Vector2 origin;
            origin.X = Texture.Width / 6;
            origin.Y = Texture.Height / 6;
            // Needed parameters when Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth);
            spriteBatch.Draw(Texture, Position, null, Color.White, angle, origin, scale, SpriteEffects.None, layerDepth);
        }
    }
}
