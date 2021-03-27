// <copyright file="IHitbox.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.Behavior
{
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Hitbox interface.
    /// </summary>
    internal interface IHitbox
    {
        /// <summary>
        /// Function that returns a hitbox.
        /// </summary>
        /// <returns> hitbox.</returns>
        internal Rectangle GetHitBox();
    }
}
