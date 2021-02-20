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
        private readonly float scale = 0.1f;
        private readonly float layerDepth = 0.0f;
        private KeyboardState currentKeyboardState;
        GamePadState currentGamePadState;
        private static float speed = 8.0f;

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// Sets isActive, angle, velocity, and spriteType fields.
        /// </summary>
        /// <param name="newBulletTexture">The picture of the bullet object.</param>
        public Player()
            : base(true, 0, speed, FactoryEnum.Player)
        {
        }

        /// <summary>
        /// This combines the Texture2D and Rectangle objects into the player for control.
        /// </summary>
        /// <param name="texture">The picture of the player object.</param>
        /// <param name="position">Starting position for the player object.</param>
        public override void Initialize(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.sPosition = position;
        }

        /// <summary>
        /// Reduces the player speed when the 'S' key is held down.
        /// </summary>
        public void SlowSpeed()
        {
            this.sVelocity = 2.0f;
        }

        /// <summary>
        /// Returns the player speed to initial speed when the 'S' key released.
        /// </summary>
        public void IncreaseSpeed()
        {
            if (this.sVelocity != 8.0f)
            {
                this.sVelocity = 8.0f;
            }
        }

        /// <inheritdoc/>
        public override void Update(GameTime gameTime)
        {
            this.currentKeyboardState = Keyboard.GetState();

            this.currentGamePadState = GamePad.GetState(PlayerIndex.One);

            this.sPosition.X += this.currentGamePadState.ThumbSticks.Left.X * speed;

            this.sPosition.Y -= this.currentGamePadState.ThumbSticks.Left.Y * speed;

            if (this.currentKeyboardState.IsKeyDown(Keys.S))
            {
                this.SlowSpeed();
            }

            if (this.currentKeyboardState.IsKeyUp(Keys.S))
            {
                this.IncreaseSpeed();
            }

            if (this.currentKeyboardState.IsKeyDown(Keys.Left))
            {
                this.sPosition.X -= this.sVelocity;
            }

            if (this.currentKeyboardState.IsKeyDown(Keys.Right))
            {
                this.sPosition.X += this.sVelocity;
            }

            if (this.currentKeyboardState.IsKeyDown(Keys.Up))
            {
                this.sPosition.Y -= this.sVelocity;
            }

            if (this.currentKeyboardState.IsKeyDown(Keys.Down))
            {
                this.sPosition.Y += this.sVelocity;
            }
        }

        /// <inheritdoc/>
        public override void Draw(SpriteBatch spriteBatch)
        {
            Vector2 origin;
            origin.X = this.texture.Width / 6;
            origin.Y = this.texture.Height / 6;

            // Needed parameters when Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth);
            spriteBatch.Draw(this.texture, this.sPosition, null, Color.White, this.angle, origin, this.scale, SpriteEffects.None, this.layerDepth);
        }
    }
}
