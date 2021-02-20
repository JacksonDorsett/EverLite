// <copyright file="Sprite.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Models
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    /// <summary>
    /// Base class for all objects used in game.
    /// </summary>
    public class Sprite
    {
        /// <summary>
        /// Holds the object's picture.
        /// </summary>
        protected Texture2D texture;

        /// <summary>
        /// Holds the object's position.
        /// </summary>
        public Vector2 sPosition;

        /// <summary>
        /// Reflects the onscreen status.
        /// </summary>
        public bool isVisible;

        /// <summary>
        /// Reflects the direction the object's picture is pointing.
        /// </summary>
        protected float angle;

        public Vector2 Velocity;

        /// <summary>
        /// Holds the object's velocity.
        /// </summary>
        protected float sVelocity;

        /// <summary>
        /// Holds the object's specific FactoryEnum type.
        /// </summary>
        protected FactoryEnum SpriteType;

        /// <summary>
        /// Initializes a new instance of the <see cref="Sprite"/> class.
        /// </summary>
        /// <param name="active">Sets the isActive field.</param>
        /// <param name="angle">Sets the angle field.</param>
        /// <param name="velocity">Sets the velocity field.</param>
        /// <param name="type">Sets the spriteType.</param>
        public Sprite(bool active, float angle, float velocity, FactoryEnum type)
        {
            this.isVisible = active;
            this.angle = angle;
            this.sVelocity = velocity;
            this.SpriteType = type;
        }

        /// <summary>
        /// Sets up the object Texture2D and space-time placement.
        /// </summary>
        /// <param name="texture">Sets the object's picture.</param>
        /// <param name="position">Sets the object's starting position.</param>
        public virtual void Initialize(Texture2D texture, Vector2 position)
        {
        }

        /// <summary>
        /// This class was built for testing purposes.
        /// </summary>
        /// <returns>The enum of the spriteType.</returns>
        public FactoryEnum GetSpriteType()
        {
            return this.SpriteType;
        }

        /// <summary>
        /// Get's the instance's current position.
        /// </summary>
        /// <returns>Sprite's position.</returns>
        public Vector2 GetPosition()
        {
            return this.sPosition;
        }

        /// <summary>
        /// Get's the instance's current velocity.
        /// </summary>
        /// <returns>Sprite's velocity.</returns>
        public float GetVelocity()
        {
            return this.sVelocity;
        }

        public virtual void SetVelocity()
        {
        }

        /// <summary>
        /// Sets the initial position of the bullet.
        /// </summary>
        /// <param name="position">Player's position.</param>
        public virtual void SetPosition(Vector2 position)
        {
        }

        /// <summary>
        /// The object's special controls are called here.
        /// </summary>
        /// <param name="gameTime">SpriteBatch source.</param>
        public virtual void Update(GameTime gameTime)
        {
        }

        /// <summary>
        /// Controls how the object is drawn for the canvas.
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch source.</param>
        public virtual void Draw(SpriteBatch spriteBatch)
        {
        }
    }
}
