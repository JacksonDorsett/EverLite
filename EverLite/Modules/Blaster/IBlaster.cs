// <copyright file="IBlaster.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.Blaster
{
    using EverLite.Modules.Sprites;
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Blaster Interface.
    /// </summary>
    public interface IBlaster
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
    }
}
