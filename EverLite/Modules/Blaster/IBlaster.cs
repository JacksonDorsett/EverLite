// <copyright file="IBlaster.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.Blaster
{
    using EverLite.Modules.Behavior;
    using EverLite.Modules.Sprites;
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Blaster Interface.
    /// </summary>
    public interface IBlaster : ICollidable
    {
        /// <summary>
        /// Shoot interface.
        /// </summary>
        /// <param name="position">position being fired from.</param>
        /// <returns>returns the bullet sprite.</returns>
        public Sprite Shoot(Vector2 position);

        /// <summary>
        /// Updates the blaster interface.
        /// </summary>
        /// <param name="gameTime">gametime passed during the cycle.</param>
        public void Update(GameTime gameTime);

        /// <summary>
        /// Handles collision with an object.
        /// </summary>
        /// <param name="collidable"> object colided with.</param>
        void ICollidable.CollidesWith(ICollidable collidable)
        {
            // TODO: make bullet destroy itself.
            return;
        }
    }
}
