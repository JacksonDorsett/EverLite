// <copyright file="Bullets.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Models
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// The Bullet class created will handle the special stuff the bullets can do.
    /// </summary>
    public class Bullets : Sprite
    {
        private readonly float scale = 0.5f;
        private readonly float layerDepth = 0.0f;

        /// <summary>
        /// Initializes a new instance of the <see cref="Bullets"/> class.
        /// Sets isActive, angle, velocity, and spriteType fields.
        /// </summary>
        public Bullets()
            : base(false, 0, 16.0f, FactoryEnum.Bullets)
        {
        }

        /// <inheritdoc/>
        public override void Initialize(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;
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
            this.position = playerPosition + this.velocity;
        }

        /// <inheritdoc/>
        public override void SetVelocity()
        {
            this.velocity = new Vector2(0, -this.sVelocity);
        }

        /// <inheritdoc/>
        public override void Draw(SpriteBatch spriteBatch)
        {
            Vector2 origin;
            origin.X = this.texture.Width / 6;
            origin.Y = this.texture.Height / 6;

            spriteBatch.Draw(this.texture, this.position, null, Color.White, this.angle, origin, this.scale, SpriteEffects.None, this.layerDepth);
        }
    }
}
