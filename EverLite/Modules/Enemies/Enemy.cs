// <copyright file="Enemy.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.Enemies
{
    using System;
    using EverLite.Modules.Behavior;
    using EverLite.Modules.Blaster;
    using EverLite.Modules.Sprites;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Abstract enemy type.
    /// </summary>
    public class Enemy
    {
        protected SpriteN enemySprite;
        private IBlaster blaster;
        private Lifespan lifespan;

        /// <summary>
        /// Initializes a new instance of the <see cref="Enemy"/> class.
        /// </summary>
        /// <param name="sprite">sprite of the enemy.</param>
        /// <param name="blaster">blaster pattern.</param>
        /// <param name="movement">movement pattern.</param>
        /// <param name="lifespan">lifespan pattern.</param>
        public Enemy(SpriteN sprite, IBlaster blaster, IMovement movement, float lifespan)
        {
            this.Blaster = blaster;
            this.enemySprite = sprite;
            this.Movement = movement;
            this.lifespan = new Lifespan(lifespan);
        }

        /// <summary>
        /// gets or sets blaster object.
        /// </summary>
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
        /// gets the movement associated with the enemy.
        /// </summary>
        public IMovement Movement
        {
            get;
            private set;
        }

        /// <summary>
        /// gets the position of an enemy.
        /// </summary>
        public Vector2 Position { get => this.Movement.GetPosition(this.lifespan.Halflife); }

        /// <summary>
        /// Gets a value indicating whether or not the enemy is alive.
        /// </summary>
        public bool IsAlive
        {
            get => this.lifespan.Halflife < 1;
        }

        /// <summary>
        /// Shoot blasters.
        /// </summary>
        /// <returns> blaster shot.</returns>
        public Sprite Shoot()
        {
            return this.blaster.Shoot(this.Position);
        }

        /// <summary>
        /// Update function to update the enemy.
        /// </summary>
        /// <param name="gameTime">gametime.</param>
        public virtual void Update(GameTime gameTime)
        {
            this.lifespan.Update(gameTime);

            this.blaster.Update(gameTime);
        }

        /// <summary>
        /// Draws an enemy class.
        /// </summary>
        /// <param name="sprite"> spriteBatch.</param>
        public void Draw(SpriteBatch sprite)
        {
            sprite.Begin();
            this.enemySprite.Draw(sprite, this.Position, rotation: Movement.Angle(this.lifespan.Halflife));
            sprite.End();
        }
    }

}
