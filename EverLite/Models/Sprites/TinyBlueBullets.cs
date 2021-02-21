// <copyright file="TinyBlueBullets.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Models.Sprites
{
    using EverLite.Models.Enums;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// The Bullet class created will handle the special stuff the bullets can do.
    /// </summary>
    public class TinyBlueBullets : Sprite
    {
        private readonly float scale = 0.5f;
        private readonly float layerDepth = 0.0f;

        /// <summary>
        /// Initializes a new instance of the <see cref="TinyBlueBullets"/> class.
        /// Sets isActive, angle, and velocity fields.
        /// </summary>
        public TinyBlueBullets()
            : base(false, 0f, 16.0f)
        {
        }

        /// <inheritdoc/>
        public override void Initialize(Texture2D texture, Vector2 position)
        {
            this.Texture = texture;
            this.Position = position;
            this.SetVelocity();
            this.SetPosition(position);
        }

        /// <inheritdoc/>
        public override void Update(GameTime gameTime)
        {
        }

        /// <inheritdoc/>
        public override void SetPosition(Vector2 playerPosition)
        {
            this.Position = playerPosition + this.Velocity;
        }

        /// <inheritdoc/>
        public override void SetVelocity()
        {
            this.Velocity = new Vector2(0, -this.sVelocity);
        }

        /// <inheritdoc/>
        public override void Draw(SpriteBatch spriteBatch)
        {
            Vector2 origin;
            origin.X = this.Texture.Width / 6;
            origin.Y = this.Texture.Height / 6;

            spriteBatch.Draw(this.Texture, this.Position, null, Color.White, this.angle, origin, this.scale, SpriteEffects.None, this.layerDepth);
        }
    }
}
