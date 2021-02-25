// <copyright file="Player.cs" company="PlaceholderCompany">
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
        // constants
        private static readonly float NORMALSPEED = 15.0f;
        private static readonly float SLOWSPEED = 5.0f;
        private readonly float scale = 0.5f;
        private readonly float layerDepth = 0.0f;
        private int screenWidth;
        private int screenHeight;
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

            // initialize components
            this.blaster = new PlayerBlaster(game.Content.Load<Texture2D>("TinyBlue"));
            this.slowSpeedStatus = new ToggleStatus(Keys.G);
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
            this.SetGameBoundary();
        }

        /// <summary>
        /// Shoots a bullet from blaster and returns the bullet object.
        /// </summary>
        /// <returns>returns the bullet that was shot.</returns>
        public Sprite Shoot()
        {
            return this.blaster.Shoot(this.Position);
        }

        /// <inheritdoc/>
        public override void Update(GameTime gameTime)
        {
            this.blaster.Update(gameTime);

            GamePadState currentGamePadState = GamePad.GetState(PlayerIndex.One);

            KeyboardState currentKeyboardState = Keyboard.GetState();

            this.UpdatePlayerPositionGamePad(currentGamePadState);
            this.UpdatePlayerPosition(currentKeyboardState);
        }

        /// <summary>
        /// Draws the Player.
        /// </summary>
        /// <param name="spriteBatch">sprite batch being drawn to.</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            Vector2 origin;
            origin.X = this.Texture.Width / 6;
            origin.Y = this.Texture.Height / 6;
            spriteBatch.Draw(this.Texture, this.Position, null, Color.White, this.angle, origin, this.scale, SpriteEffects.None, this.layerDepth);
        }

        private void UpdatePlayerPositionGamePad(GamePadState currentGamePadState)
        {
            if (currentGamePadState.Buttons.Y == ButtonState.Pressed)
            {
                this.sVelocity = SLOWSPEED;
            }

            if (currentGamePadState.Buttons.Y == ButtonState.Released)
            {
                this.sVelocity = NORMALSPEED;
            }

            this.Position.X += currentGamePadState.ThumbSticks.Left.X * this.sVelocity;

            this.Position.Y -= currentGamePadState.ThumbSticks.Left.Y * this.sVelocity;
        }

        private void UpdatePlayerPosition(KeyboardState currentKeyboardState)
        {
            float speed = this.GetPlayerSpeed();

            if (currentKeyboardState.IsKeyDown(Keys.G))
            {
                this.sVelocity = SLOWSPEED;
            }

            if (currentKeyboardState.IsKeyUp(Keys.G))
            {
                this.sVelocity = NORMALSPEED;
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

            this.CheckPlayerBoundry();
        }

        private void SetGameBoundary()
        {
            var rect = this.mGame.Window.ClientBounds;
            this.screenWidth = rect.Width;
            this.screenHeight = rect.Height;
        }

        private Vector2 GetPlayerLocation()
        {
            return new Vector2(this.mGame.GraphicsDevice.Viewport.TitleSafeArea.X + (this.mGame.GraphicsDevice.Viewport.TitleSafeArea.Width / 2), this.mGame.GraphicsDevice.Viewport.TitleSafeArea.Y + (this.mGame.GraphicsDevice.Viewport.TitleSafeArea.Height * 4 / 5));
        }

        private float GetPlayerSpeed()
        {
            this.slowSpeedStatus.Update();
            if (!this.slowSpeedStatus.Status)
            {
                return NORMALSPEED;
            }
            else
            {
                return SLOWSPEED;
            }
        }

        private void CheckPlayerBoundry()
        {
            if (this.Position.X <= 15)
            {
                this.Position.X = 15;
            }

            if (this.Position.Y <= 0)
            {
                this.Position.Y = 0;
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
    }
}
