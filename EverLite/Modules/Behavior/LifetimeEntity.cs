// <copyright file="LifetimeEntity.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.Behavior
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EverLite.Modules.Enemies;
    using EverLite.Modules.Sprites;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Lifetime dependent Entity.
    /// </summary>
    public class LifetimeEntity : Entity, ICollidable
    {
        private SpriteN mSprite;
        protected IMovement movementPattern;
        private Lifespan lifespan;
        private bool isAliveFlag;

        public event EventHandler OnCollide;

        /// <summary>
        /// Initializes a new instance of the <see cref="LifetimeEntity"/> class.
        /// </summary>
        /// <param name="sprite"></param>
        public LifetimeEntity(SpriteN sprite, IMovement movement, double lifetime)
            : base(sprite)
        {
            this.movementPattern = movement;
            this.lifespan = new Lifespan(lifetime);
            this.isAliveFlag = true;
        }

        public override Vector2 Position { get => this.movementPattern.GetPosition(this.lifespan.Halflife); protected set => throw new NotImplementedException(); }
        public override SpriteN Sprite { get => this.mSprite; protected set => this.mSprite = value; }

        protected double Halflife { get => this.lifespan.Halflife;  }

        public bool IsAlive { get => this.lifespan.Halflife < 1 && this.isAliveFlag; }

        public override void Update(GameTime gameTime)
        {
            this.lifespan.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            this.Sprite.Draw(spriteBatch, this.Position, rotation: this.movementPattern.Angle(this.lifespan.Halflife));
            spriteBatch.End();
        }

        /// <summary>
        /// Function that flags the entity as dead.
        /// </summary>
        public void Die()
        {
            this.isAliveFlag = false;
        }

        /// <summary>
        /// Handles collision with an object.
        /// </summary>
        /// <param name="collidable"> object colided with.</param>
        void ICollidable.CollidesWith(ICollidable collidable)
        {
            this.CollidesWith(collidable);
        }

        /// <summary>
        /// Handles collision with an object.
        /// </summary>
        /// <param name="collidable"> object colided with.</param>
        protected virtual void CollidesWith(ICollidable collidable)
        {
        }
    }
}
