// <copyright file="Sprite.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Models.Sprites
{
    using EverLite.Models.Enums;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Base class for all objects used in game.
    /// </summary>
    public class Sprite
    {
        /// <summary>
        /// Holds the object's position.
        /// </summary>
        public Vector2 Position;

        /// <summary>
        /// Reflects the direction the object's picture is pointing.
        /// </summary>
        protected float angle;

        /// <summary>
        /// Holds the object's velocity.
        /// </summary>
        protected float sVelocity;

        /// <summary>
        /// Holds the object's specific FactoryEnum type.
        /// </summary>
        protected FactoryEnum spriteType;

        

        /// <summary>
        /// Reflects the onscreen status.
        /// </summary>
        protected bool isVisible;

        /// <summary>
        /// Reference to the content manager.
        /// </summary>
        private ContentManager contentManagerRef;

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
            this.spriteType = type;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Sprite"/> class.
        /// </summary>
        /// <param name="angle">initial angle.</param>
        /// <param name="velocity">intial velocity.</param>
        /// <param name="texture">texture of sprite.</param>
        /// <param name="position">sprites initial position.</param>
        /// <param name="active">is sprite visible.</param>
        public Sprite(float angle, float velocity, Texture2D texture, Vector2 position, bool active = true)
        {
            this.isVisible = active;
            this.sVelocity = velocity;
            this.Texture = texture;
            this.Position = position;
            this.angle = angle;

        }

        /// <summary>
        /// Gets or sets the bullet subclass uses this Velocity.
        /// </summary>
        public Vector2 Velocity { get; set; }

        /// <summary>
        /// Gets or sets texture of an enemy.
        /// </summary>
        public Texture2D Texture { get; protected set; }

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
            return this.spriteType;
        }

        /// <summary>
        /// Get's the instance's current position.
        /// </summary>
        /// <returns>Sprite's position.</returns>
        public Vector2 GetPosition()
        {
            return this.Position;
        }

        /// <summary>
        /// Get's the instance's current sVelocity.
        /// </summary>
        /// <returns>Sprite's velocity.</returns>
        public float GetsVelocity()
        {
            return this.sVelocity;
        }

        /// <summary>
        /// Used by the bullets to aid in shooting the correct direction.
        /// </summary>
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
        /// Sets isVisible.
        /// </summary>
        /// <param name="value">True or False.</param>
        public void SetIsVisible(bool value)
        {
            this.isVisible = value;
        }

        /// <summary>
        /// Gets isVisible.
        /// </summary>
        /// <returns>True or False.</returns>
        public bool GetIsVisible()
        {
            return this.isVisible;
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
