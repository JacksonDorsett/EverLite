// <copyright file="Sprite.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.Sprites
{
    using EverLite.Modules.Behavior;
    using EverLite.Modules.Enums;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Base class for all objects used in game.
    /// </summary>
    public class Sprite : ButtonControls
    {
        /// <summary>
        /// Holds the object's position.
        /// </summary>
        public Vector2 Position;

        /// <summary>
        /// Reflects the direction the object's picture is pointing.
        /// </summary>
        public float angle;

        /// <summary>
        /// Holds the object's velocity.
        /// </summary>
        protected float sVelocity;

        /// <summary>
        /// Reflects the onscreen status.
        /// </summary>
        private bool isVisible;

        /// <summary>
        /// Initializes a new instance of the <see cref="Sprite"/> class.
        /// </summary>
        /// <param name="active">Sets the isActive field.</param>
        /// <param name="angle">Sets the angle field.</param>
        /// <param name="velocity">Sets the velocity field.</param>
        /// <param name="type">Sets the spriteType.</param>
        public Sprite(bool active, float angle, float velocity)
        {
            this.IsVisible = active;
            this.angle = angle;
            this.sVelocity = velocity;
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
            this.IsVisible = active;
            this.sVelocity = velocity;
            this.Texture = texture;
            this.Position = position;
            this.angle = angle;

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Sprite"/> class.
        /// </summary>
        /// <param name="texture">Texture.</param>
        /// <param name="position">position of sprite.</param>
        /// <param name="velocity">velocity.</param>
        /// <param name="active">is visible.</param>
        public Sprite(Texture2D texture, Vector2 position, Vector2 velocity, bool active = true)
        {
            this.Texture = texture;
            this.Position = position;
            this.Velocity = velocity;
            this.IsVisible = true;
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
        /// Gets or sets a value indicating whether is visible.
        /// </summary>
        protected bool IsVisible { get => isVisible; set => isVisible = value; }

        /// <summary>
        /// Sets up the object Texture2D and space-time placement.
        /// </summary>
        /// <param name="texture">Sets the object's picture.</param>
        /// <param name="position">Sets the object's starting position.</param>
        public virtual void Initialize(Texture2D texture, Vector2 position)
        {
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

        public void SetsVelocity(float speed)
        {
            this.sVelocity = speed;
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
            this.IsVisible = value;
        }

        /// <summary>
        /// Gets isVisible.
        /// </summary>
        /// <returns>True or False.</returns>
        public bool GetIsVisible()
        {
            return this.IsVisible;
        }

        /// <summary>
        /// The object's special controls are called here.
        /// </summary>
        /// <param name="gameTime">SpriteBatch source.</param>
        public virtual void Update(GameTime gameTime)
        {
            this.Position += this.Velocity;
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
