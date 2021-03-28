// <copyright file="Enemy.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.Enemies
{
    using EverLite.Modules.Behavior;
    using EverLite.Modules.Sprites;
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Abstract enemy type.
    /// </summary>
    class Enemy : LifetimeEntity
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Enemy"/> class.
        /// </summary>
        /// <param name="sprite">sprite of the enemy.</param>
        /// <param name="blaster">blaster pattern.</param>
        /// <param name="movement">movement pattern.</param>
        /// <param name="lifespan">lifespan pattern.</param>
        public Enemy(SpriteN sprite, IMovement movement, float lifespan)
            : base(sprite, movement, (double)lifespan)
        {
        }

        /// <summary>
        /// gets or sets blaster object.
        /// </summary>

        /// <summary>
        /// Update function to update the enemy.
        /// </summary>
        /// <param name="gameTime">gametime.</param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

        }
        /// <summary>
        /// Handles collision with an object.
        /// </summary>
        /// <param name="collidable"> object colided with.</param>
        protected override void CollidesWith(ICollidable collidable)
        {
            // TODO: implement health system action.
            base.CollidesWith(collidable);
        }
    }

}
