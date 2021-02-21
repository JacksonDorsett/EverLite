// <copyright file="Player.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Models.Sprites
{
    using EverLite.Models.Enums;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using System;

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
        //private KeyboardState currentKeyboardState;
        //private GamePadState currentGamePadState;
        private string currentBulletType = "TinyBlue";
        private Game mGame;
        private ToggleStatus slowSpeedStatus;

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// Sets isActive, angle, velocity, and spriteType fields.
        /// </summary>
        /// <param name="newBulletTexture">The picture of the bullet object.</param>
        public Player()
            : base(true, 0, NORMALSPEED, FactoryEnum.Player)
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
            this.Initialize(game.Content.Load<Texture2D>(EnumToStringFactory.GetEnumToString(this.GetSpriteType())), this.GetPlayerLocation());
            this.SetGameBoundary(this.mGame.GraphicsDevice.Viewport.Width, this.mGame.GraphicsDevice.Viewport.Height);
            this.slowSpeedStatus = new ToggleStatus(Keys.G);
        }

        private void SetGameBoundary(int width, int height)
        {
            this.screenWidth = width;
            this.screenHeight = height;
        }

        private Vector2 GetPlayerLocation()
        {
            return new Vector2(this.mGame.GraphicsDevice.Viewport.TitleSafeArea.X + (this.mGame.GraphicsDevice.Viewport.TitleSafeArea.Width / 2), this.mGame.GraphicsDevice.Viewport.TitleSafeArea.Y + (this.mGame.GraphicsDevice.Viewport.TitleSafeArea.Height * 4 / 5));
        }

        /// <summary>
        /// This combines the Texture2D and Rectangle objects into the player for control.
        /// </summary>
        /// <param name="texture">The picture of the player object.</param>
        /// <param name="position">Starting position for the player object.</param>
        public override void Initialize(Texture2D texture, Vector2 position)
        {
            this.Texture = texture;
            this.Position = position;
        }

        /// <summary>
        /// Creates the bullet instance for the Game1 class.
        /// </summary>
        /// <param name="texture">Picture of bullet.</param>
        /// <param name="position">Bullets spawn point.</param>
        /// <returns>Bullet instance.</returns>
        public Sprite Shoot(Texture2D texture, Vector2 position)
        {
            Vector2 playerPosition = new Vector2(position.X + 22, position.Y);
            Sprite newBullet = SpriteFactory.CreateSprite(BulletChoiceFactory.GetBulletType(this.GetCurrentBulletType()),this.mGame);
            newBullet.Initialize(texture, playerPosition);
            newBullet.SetIsVisible(true);
            return newBullet;
        }

        /// <summary>
        /// Creates the bullet instance for the Game1 class.
        /// </summary>
        /// <param name="position">Bullets spawn point.</param>
        /// <returns>Bullet instance.</returns>
        public Sprite Shoot(Vector2 position)
        {
            Vector2 playerPosition = new Vector2(position.X + 22, position.Y);
            Sprite newBullet = SpriteFactory.CreateSprite(BulletChoiceFactory.GetBulletType(this.GetCurrentBulletType()), this.mGame);
            newBullet.Initialize(this.Texture, playerPosition);
            newBullet.SetIsVisible(true);
            return newBullet;
        }

        /// <inheritdoc/>
        public override void Update(GameTime gameTime)
        {

            KeyboardState currentKeyboardState = Keyboard.GetState();

            GamePadState currentGamePadState = GamePad.GetState(PlayerIndex.One);

            #region Player controls
            this.slowSpeedStatus.Update();
            // get current speed
            if (!this.slowSpeedStatus.Status)
            {
                this.sVelocity = 15;
            }
            else
            {
                this.sVelocity = 5;
            }

            this.Position.X += currentGamePadState.ThumbSticks.Left.X * this.sVelocity;

            this.Position.Y -= currentGamePadState.ThumbSticks.Left.Y * this.sVelocity;

            if (currentGamePadState.Buttons.Y == ButtonState.Pressed || currentKeyboardState.IsKeyDown(Keys.T))
            {
                this.ChangeBulletType();
            }

            if (currentKeyboardState.IsKeyDown(Keys.Left) || currentKeyboardState.IsKeyDown(Keys.A))
            {
                this.Position.X -= this.sVelocity;
            }

            if (currentKeyboardState.IsKeyDown(Keys.Right) || currentKeyboardState.IsKeyDown(Keys.D))
            {
                this.Position.X += this.sVelocity;
            }

            if (currentKeyboardState.IsKeyDown(Keys.Up) || currentKeyboardState.IsKeyDown(Keys.W))
            {
                this.Position.Y -= this.sVelocity;
            }

            if (currentKeyboardState.IsKeyDown(Keys.Down) || currentKeyboardState.IsKeyDown(Keys.S))
            {
                this.Position.Y += this.sVelocity;
            }
            #endregion

            this.CheckPlayerBoundry();
        }

        private void CheckPlayerBoundry()
        {
            if (this.Position.X <= 15)
            {
                this.Position.X = 15;
            }

            if (this.Position.Y <= this.screenHeight / 2)
            {
                this.Position.Y = this.screenHeight / 2;
            }

            if (this.Position.X + this.Texture.Width >= this.screenWidth)
            {
                this.Position.X = this.screenWidth - this.Texture.Width;
            }

            if (this.Position.Y + this.Texture.Height >= this.screenHeight)
            {
                this.Position.Y = this.screenHeight - this.Texture.Height;
            }
        }

        /// <summary>
        /// Simple feature that switches between the available choices.
        /// </summary>
        public void ChangeBulletType()
        {
            if (this.currentBulletType == "TinyRed")
            {
                this.currentBulletType = "TinyBlue";
            }
            else
            {
                this.currentBulletType = "TinyRed";
            }
        }

        /// <summary>
        /// Returns selected bullet type.
        /// </summary>
        /// <returns>Name of selected bullet.</returns>
        public string GetCurrentBulletType()
        {
            return this.currentBulletType;
        }

        /// <inheritdoc/>
        public override void Draw(SpriteBatch spriteBatch)
        {
            Vector2 origin;
            origin.X = this.Texture.Width / 6;
            origin.Y = this.Texture.Height / 6;
            // Needed parameters when Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth);
            spriteBatch.Draw(this.Texture, this.Position, null, Color.White, this.angle, origin, this.scale, SpriteEffects.None, this.layerDepth);
        }
    }
}
