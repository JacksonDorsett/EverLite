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
        private KeyboardState currentKeyboardState;

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// Sets isActive, angle, and velocity fields.
        /// </summary>
        public Player()
            : base(true, 90, 8.0f, FactoryEnum.Player)
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
        public override void Update()
        {
            this.currentKeyboardState = Keyboard.GetState();

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
            origin.X = this.texture.Width / 2;
            origin.Y = this.texture.Height / 2;

            // Needed parameters when Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth);
            spriteBatch.Draw(this.texture, this.sPosition, null, Color.White, this.angle, origin, .5f, SpriteEffects.None, 0f);
        }
    }
}
