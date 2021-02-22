﻿// <copyright file="Enemy.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.Enemies
{
    using System;
    using EverLite.Modules.Blaster;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Abstract enemy type.
    /// </summary>
    internal abstract class Enemy
    {
        private IBlaster blaster;

        public IBlaster Blaster
        {
            get
            {
                return this.blaster;
            }
            protected set
            {
                this.blaster = value;
            }
        }
        /// <summary>
        /// Gets or sets texture of an enemy.
        /// </summary>
        public Texture2D Texture { get; set; }

        /// <summary>
        /// Reference to the content manager.
        /// </summary>
        public ContentManager ContentManagerRef;

        /// <summary>
        /// position of an enemy.
        /// </summary>
        public Vector2 Position;

        /// <summary>
        /// velocity of an enemy.
        /// </summary>
        public Vector2 Velocity = new Vector2(0, 0);

        /// <summary>
        /// Target position for the enemy to reach.
        /// </summary>
        public Vector2 TargetPosition;

        /// <summary>
        /// Gets or sets sprite name of an enemy.
        /// </summary>
        public abstract string SpriteName { get; set; }

        /// <summary>
        /// Gets or sets visibility of an enemy.
        /// </summary>
        public abstract bool IsVisible { get; set; }

        /// <summary>
        /// Gets or sets visibility of an enemy.
        /// </summary>
        public bool IsTargetting { get; set; }

        public Random random = new Random();
        public int randX, randY;

        public Enemy(Vector2 newPosition, ContentManager contentManager, IBlaster blaster)
        {
            this.Position = newPosition;
            this.ContentManagerRef = contentManager;
            this.Texture = this.ContentManagerRef.Load<Texture2D>(this.SpriteName);
            this.blaster = blaster;
        }

        public Enemy(ContentManager contentManager, IBlaster blaster)
        {
            this.ContentManagerRef = contentManager;
            this.Texture = this.ContentManagerRef.Load<Texture2D>(this.SpriteName);
            this.blaster = blaster;
        }

        /// <summary>
        /// Update function to update the enemy.
        /// </summary>
        /// <param name="graphics"> graphics.</param>
        /// <param name="gameTime"> gametime.</param>
        public void Update(GraphicsDevice graphics, GameTime gameTime)
        {
            if (this.IsTargetting)
            {
                if (this.Velocity.X > 0)
                {
                    // calcualte velocity for X.
                    if (this.Position.X > this.TargetPosition.X)
                    {
                        float xDiff = this.Position.X - this.Velocity.X;
                        this.Position.X -= xDiff < this.TargetPosition.X ? this.TargetPosition.X : this.Velocity.X;
                    }
                    else if (this.Position.X < this.TargetPosition.X)
                    {
                        float xDiff = this.Position.X + this.Velocity.X;
                        this.Position.X += xDiff > this.TargetPosition.X ? this.TargetPosition.X : this.Velocity.X;
                    }
                }

                if (this.Velocity.Y > 0)
                {
                    // calcualte velocity for Y.
                    if (this.Position.Y > this.TargetPosition.Y && this.Velocity.Y > 0)
                    {
                        float yDiff = this.Position.Y - this.Velocity.Y;
                        this.Position.Y -= yDiff < this.TargetPosition.Y ? this.TargetPosition.Y : this.Velocity.Y;
                    }
                    else if (this.Position.Y < this.TargetPosition.Y)
                    {
                        float yDiff = this.Position.Y + this.Velocity.Y;
                        this.Position.Y += yDiff > this.TargetPosition.Y ? this.TargetPosition.Y : this.Velocity.Y;
                    }
                }
            }
            else
            {
                this.Position += this.Velocity;
            }

            if (this.Position.Y <= 0)
            {
                this.Velocity.Y = -this.Velocity.Y;
            }

            if (this.Position.X < 0 || this.Position.X > graphics.Viewport.Width)
            {
                this.Velocity.X = -this.Velocity.X;
            }

            if (this.Position.Y > graphics.Viewport.Height)
            {
                this.IsVisible = false;
            }
        }

        /// <summary>
        /// Function that sets new velocity.
        /// </summary>
        /// <param name="newVelocity"> new velocity to set.</param>
        public void ChangeVelocity(Vector2 newVelocity)
        {
            this.Velocity = newVelocity;
        }

        /// <summary>
        /// Function that sets new position.
        /// </summary>
        /// <param name="newPosition"> new position to set.</param>
        public void ChangePosition(Vector2 newPosition)
        {
            this.Position = newPosition;
        }

        /// <summary>
        /// Function that sets new texture.
        /// </summary>
        /// <param name="newTexture"> new velocity to set.</param>
        public void ChangeTexture(Texture2D newTexture)
        {
            this.Texture = newTexture;
        }

        /// <summary>
        /// Function that sets new target position.
        /// </summary>
        /// <param name="targetPosition"> new target position.</param>
        public void ChangeTarget(Vector2 targetPosition)
        {
            this.TargetPosition = targetPosition;
            this.IsTargetting = true;
        }

        /// <summary>
        /// Function that starts targetting.
        /// </summary>
        public void StartTargetting()
        {
            this.IsTargetting = true;
        }

        /// <summary>
        /// Function that stops targetting.
        /// </summary>
        public void StopTargetting()
        {
            this.IsTargetting = false;
        }

        /// <summary>
        /// Draws an enemy class.
        /// </summary>
        /// <param name="sprite"> spriteBatch.</param>
        public void Draw(SpriteBatch sprite)
        {
            sprite.Begin();
            sprite.Draw(this.Texture, this.Position, Color.White);
            sprite.End();
        }
    }

}
