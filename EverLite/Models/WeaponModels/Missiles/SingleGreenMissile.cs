// <copyright file="SingleGreenMissile.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Models.WeaponModels.Missiles
{
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Creates the SingleGreenMissile.
    /// </summary>
    internal class SingleGreenMissile : BasicMissile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SingleGreenMissile"/> class.
        /// Assigns the missile color and damage multiplier, and area of effect.
        /// </summary>
        public SingleGreenMissile()
            : base(Color.Green, 1.5, 2.0)
        {
        }
    }
}
