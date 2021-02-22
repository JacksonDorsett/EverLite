// <copyright file="TinyRedBullets.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.Sprites
{
    using EverLite.Modules.Enums;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// The Bullet class created will handle the special stuff the bullets can do.
    /// </summary>
    public class TinyRedBullets : Sprite
    {
        private readonly float scale = 0.5f;
        private readonly float layerDepth = 0.0f;

        /// <summary>
        /// Initializes a new instance of the <see cref="TinyRedBullets"/> class.
        /// Sets isActive, angle, velocity, and spriteType fields.
        /// </summary>
        public TinyRedBullets()
            : base(false, 0f, 16.0f, FactoryEnum.TinyRed)
        {
        }

        /// <inheritdoc/>
        public override void Initialize(Texture2D texture, Vector2 position)
        {
            Texture = texture;
            Position = position;
            SetVelocity();
            SetPosition(position);
        }

        /// <inheritdoc/>
        public override void Update(GameTime gameTime)
        {
        }

        /// <inheritdoc/>
        public override void SetPosition(Vector2 playerPosition)
        {
            Position = playerPosition + Velocity;
        }

        /// <inheritdoc/>
        public override void SetVelocity()
        {
            Velocity = new Vector2(0, -sVelocity);
        }

        /// <inheritdoc/>
        public override void Draw(SpriteBatch spriteBatch)
        {
            Vector2 origin;
            origin.X = Texture.Width / 6;
            origin.Y = Texture.Height / 6;

            spriteBatch.Draw(Texture, Position, null, Color.White, angle, origin, scale, SpriteEffects.None, layerDepth);
        }
    }
}
