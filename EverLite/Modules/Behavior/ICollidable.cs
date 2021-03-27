// <copyright file="ICollidable.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.Behavior
{
    /// <summary>
    /// Interface for collidable objects.
    /// </summary>
    internal interface ICollidable
    {
        /// <summary>
        /// Called when object collided with another object.
        /// </summary>
        /// <param name="collidable"> object we colided with</param>
        internal void CollidesWith(ICollidable collidable);
    }
}
