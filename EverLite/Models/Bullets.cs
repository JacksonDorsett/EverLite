// <copyright file="Bullets.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Models
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    /// <summary>
    /// The Bullet class created will handle the special stuff the bullets can do.
    /// </summary>
    public class Bullets : Sprite
    {
        private readonly float scale = 0.1f;
        private readonly float layerDepth = 0.0f;
        private Vector2 origin;

        private KeyboardState currentKeyboardState;
        GamePadState currentGamePadState;

        /// <summary>
        /// Initializes a new instance of the <see cref="Bullets"/> class.
        /// Sets isActive, angle, velocity, and spriteType fields.
        /// </summary>
        public Bullets()
            : base(false, 0, 16.0f, FactoryEnum.Bullets)
        { // TODO: Adjust bullet constructor.
        }

        /// <inheritdoc/>
        public override void Initialize(Texture2D texture, Vector2 position)
        {
            // TODO: Fix bullet logic here.
            this.texture = texture;
            this.sPosition = position;
            this.SetVelocity();
            this.SetPosition(position);
        }

        /// <inheritdoc/>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add bullet update stuff.
        }

        /// <inheritdoc/>
        public override void SetPosition(Vector2 playerPosition)
        {
            this.sPosition = playerPosition/* + this.Velocity*/;
        }

        /// <inheritdoc/>
        public override void SetVelocity()
        {
            this.Velocity = new Vector2((float)Math.Cos(this.angle), ((float)Math.Sin(this.angle) * 5f) + this.sVelocity);
        }

        /// <inheritdoc/>
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.sPosition, null, Color.White, this.angle, this.origin, this.scale, SpriteEffects.None, this.layerDepth);
        }
    }
}
