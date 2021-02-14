// <copyright file="BlueRayGun.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Models.WeaponModels
{
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Creates the BlueRayGun.
    /// </summary>
    public class BlueRayGun : BasicRayGun
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlueRayGun"/> class.
        /// Assigns the raygun color and damage multiplier, and area of effect.
        /// </summary>
        public BlueRayGun()
            : base(Color.Blue, 1.1, 1.0)
        {
        }
    }
}
