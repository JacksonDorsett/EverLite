// <copyright file="Sprite.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Models
{
    using Microsoft.Xna.Framework;
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
        /// The bullet subclass uses this Velocity.
        /// </summary>
        public Vector2 Velocity;

        /// <summary>
        /// Reflects the onscreen status.
        /// </summary>
        public bool IsVisible;

        /// <summary>
        /// Holds the object's picture.
        /// </summary>
        protected Texture2D texture;

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
            this.IsVisible = active;
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
            return this.Position;
        }

        /// <summary>
        /// Get's the instance's current velocity.
        /// </summary>
        /// <returns>Sprite's velocity.</returns>
        public float GetVelocity()
        {
            return this.sVelocity;
        }

        /// <summary>
        /// Used by the player to determine it's movement parameters.
        /// </summary>
        /// <returns>The texture.</returns>
        public Texture2D GetTexture()
        {
            return this.texture;
        }

        /// <summary>
        /// Used by the player to reduce speed by 1/4.
        /// </summary>
        public virtual void SlowSpeed()
        {
        }

        /// <summary>
        /// Used by the player to return to initial speed.
        /// </summary>
        public virtual void IncreaseSpeed()
        {
        }

        /// <summary>
        /// Used to determine the next bullet created in Game1 class.
        /// </summary>
        /// <returns>Returns the name of the selected bullet type.</returns>
        public virtual string GetCurrentBulletType()
        {
            return null;
        }

        /// <summary>
        /// Used by the bullets to aid in shooting the correct direction.
        /// </summary>
        public virtual void SetVelocity()
        {
        }

        /// <summary>
        /// Used by the player to create the bullets being shot.
        /// </summary>
        /// <param name="texture">Picture of the bullets.</param>
        /// <param name="position">Position of where the bullets are shooting from.</param>
        /// <returns>Bullet Sprite or null.</returns>
        public virtual Sprite Shoot(Texture2D texture, Vector2 position)
        {
            return null;
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
