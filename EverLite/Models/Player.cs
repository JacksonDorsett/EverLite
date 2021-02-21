// <copyright file="Player.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Models
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    /// <summary>
    /// The Player class created will handle the special stuff the player can do.
    /// </summary>
    public class Player : Sprite
    {
        private static float speed = 15.0f; // This is static so I can use it in the constructor.
        private readonly float scale = 0.5f;
        private readonly float layerDepth = 0.0f;
        private KeyboardState currentKeyboardState;
        private GamePadState currentGamePadState;
        private string currentBulletType = "TinyRed";

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// Sets isActive, angle, velocity, and spriteType fields.
        /// </summary>
        /// <param name="newBulletTexture">The picture of the bullet object.</param>
        public Player()
            : base(true, 0, speed, FactoryEnum.Player)
        {
        }

        /// <inheritdoc/>
        public override string SpriteName { get; set; } = "Rocket";

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
        /// Reduces the player speed when the 'S' key is held down.
        /// </summary>
        public override void SlowSpeed()
        {
            this.sVelocity = 5.0f;
        }

        /// <summary>
        /// Returns the player speed to initial speed when the 'S' key released.
        /// </summary>
        public override void IncreaseSpeed()
        {
            if (this.sVelocity != 15.0f)
            {
                this.sVelocity = 15.0f;
            }
        }

        /// <summary>
        /// Creates the bullet instance for the Game1 class.
        /// </summary>
        /// <param name="texture">Picture of bullet.</param>
        /// <param name="position">Bullets spawn point.</param>
        /// <returns>Bullet instance.</returns>
        public override Sprite Shoot(Texture2D texture, Vector2 position)
        {
            Vector2 playerPosition = new Vector2(position.X + 12, position.Y);
            Sprite newBullet = SpriteFactory.CreateSprite(FactoryEnum.Bullets);
            newBullet.Initialize(texture, playerPosition);
            newBullet.SetIsVisible(true);
            return newBullet;
        }

        /// <summary>
        /// Creates the bullet instance for the Game1 class.
        /// </summary>
        /// <param name="position">Bullets spawn point.</param>
        /// <returns>Bullet instance.</returns>
        public override Sprite Shoot(Vector2 position)
        {
            Vector2 playerPosition = new Vector2(position.X + 12, position.Y);
            Sprite newBullet = SpriteFactory.CreateSprite(FactoryEnum.Bullets);
            newBullet.Initialize(this.Texture, playerPosition);
            newBullet.SetIsVisible(true);
            return newBullet;
        }

        /// <inheritdoc/>
        public override void Update(GameTime gameTime)
        {
            this.currentKeyboardState = Keyboard.GetState();

            this.currentGamePadState = GamePad.GetState(PlayerIndex.One);

            this.Position.X += this.currentGamePadState.ThumbSticks.Left.X * this.sVelocity;

            this.Position.Y -= this.currentGamePadState.ThumbSticks.Left.Y * this.sVelocity;

            if (this.currentKeyboardState.IsKeyDown(Keys.G))
            {
                this.SlowSpeed();
            }

            if (this.currentKeyboardState.IsKeyUp(Keys.G))
            {
                this.IncreaseSpeed();
            }

            if (this.currentGamePadState.Buttons.Y == ButtonState.Pressed || this.currentKeyboardState.IsKeyDown(Keys.T))
            {
                this.ChangeBulletType();
            }

            if (this.currentKeyboardState.IsKeyDown(Keys.Left) || this.currentKeyboardState.IsKeyDown(Keys.A))
            {
                this.Position.X -= this.sVelocity;
            }

            if (this.currentKeyboardState.IsKeyDown(Keys.Right) || this.currentKeyboardState.IsKeyDown(Keys.D))
            {
                this.Position.X += this.sVelocity;
            }

            if (this.currentKeyboardState.IsKeyDown(Keys.Up) || this.currentKeyboardState.IsKeyDown(Keys.W))
            {
                this.Position.Y -= this.sVelocity;
            }

            if (this.currentKeyboardState.IsKeyDown(Keys.Down) || this.currentKeyboardState.IsKeyDown(Keys.S))
            {
                this.Position.Y += this.sVelocity;
            }

            // Logic to keep the player on screen
            if (this.Position.X <= 2)
            {
                this.Position.X = 2;
            }

            if (this.Position.Y <= this.screenHeight / 2)
            {
                this.Position.Y = this.screenHeight / 2;
            }

            if (this.Position.X + (this.Texture.Width / 10) >= this.screenWidth)
            {
                this.Position.X = this.screenWidth - (this.Texture.Width / 10);
            }

            if (this.Position.Y + (this.Texture.Height / 10) >= this.screenHeight)
            {
                this.Position.Y = this.screenHeight - (this.Texture.Height / 10);
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
        public override string GetCurrentBulletType()
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
