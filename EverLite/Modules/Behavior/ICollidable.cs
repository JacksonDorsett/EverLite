// <copyright file="ICollidable.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.Behavior
{
    using System;

    /// <summary>
    /// Interface for collidable objects.
    /// </summary>
    public interface ICollidable
    {
        event EventHandler OnCollide;

        /// <summary>
        /// Called when object collided with another object.
        /// </summary>
        /// <param name="collidable"> object we colided with</param>
        void CollidesWith(ICollidable collidable);


    }
}
