// <copyright file="Bullet.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.Blaster
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EverLite.Modules.Behavior;
    using EverLite.Modules.Enemies;
    using EverLite.Modules.Sprites;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    class Bullet
    {
        private SpriteN sprite;
        private IMovement movement;
        private Lifespan lifespan;
        /// <summary>
        /// Initializes a new instance of the <see cref="Bullet"/> class.
        /// </summary>
        /// <param name="sprite">bullet sprite.</param>
        /// <param name="movementPattern">movement pattern of bullet.</param>
        public Bullet(SpriteN sprite, IMovement movementPattern, double lifespan)
        {
            this.sprite = sprite;
            this.movement = movementPattern;
            this.lifespan = new Lifespan(lifespan);
        }

        /// <summary>
        /// Gets the crrent position of the bullet.
        /// </summary>
        public Vector2 Position { get => this.movement.GetPosition(this.lifespan.Halflife); }

        public void Update(GameTime gameTime)
        {
            this.lifespan.Update(gameTime);

            
        }

        /// <summary>
        /// Draws the bullet sprite.
        /// </summary>
        /// <param name="spriteBatch">spritebatch to draw too.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            this.sprite.Draw(spriteBatch, this.Position);
            spriteBatch.End();
        }
    }
}
