// <copyright file="RedRayGun.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Models.WeaponModels
{
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Creates the RedRayGun.
    /// </summary>
    internal class RedRayGun : BasicRayGun
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RedRayGun"/> class.
        /// Assigns the raygun color, damage multiplier, and area of effect.
        /// </summary>
        public RedRayGun()
            : base(Color.Red, 1.0, 1.0)
        {
        }
    }
}
