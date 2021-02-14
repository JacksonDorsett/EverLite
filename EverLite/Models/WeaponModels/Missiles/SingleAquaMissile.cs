// <copyright file="SingleAquaMissile.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Models.WeaponModels.Missiles
{
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Creates the SingleGreenMissile.
    /// </summary>
    internal class SingleAquaMissile : BasicMissile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SingleAquaMissile"/> class.
        /// Assigns the missile color and damage multiplier, and area of effect.
        /// </summary>
        public SingleAquaMissile()
            : base(Color.Aqua, 2.5, 1.5)
        {
        }
    }
}
