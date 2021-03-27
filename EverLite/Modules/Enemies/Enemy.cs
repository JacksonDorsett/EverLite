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
    public class Enemy : LifetimeEntity, ICollidable
    {
        private IBlaster blaster;

        /// <summary>
        /// Initializes a new instance of the <see cref="Enemy"/> class.
        /// </summary>
        /// <param name="sprite">sprite of the enemy.</param>
        /// <param name="blaster">blaster pattern.</param>
        /// <param name="movement">movement pattern.</param>
        /// <param name="lifespan">lifespan pattern.</param>
        public Enemy(SpriteN sprite, IBlaster blaster, IMovement movement, float lifespan)
            : base(sprite, movement, (double)lifespan)
        {
            this.Blaster = blaster;
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
        /// Update function to update the enemy.
        /// </summary>
        /// <param name="gameTime">gametime.</param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            this.blaster.Update(gameTime);
        }

        /// <summary>
        /// Handles collision with an object.
        /// </summary>
        /// <param name="collidable"> object colided with.</param>
        void ICollidable.CollidesWith(ICollidable collidable)
        {
            if (collidable is PlayerBlaster)
            {
                // TODO: implement hit and health stuff.
            }
        }
    }

}
