namespace EverLite.Models.WeaponModels
{
    using System;
    using System.Collections.Generic;
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
