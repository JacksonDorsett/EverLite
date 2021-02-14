// <copyright file="RayGunFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Models.WeaponModels
{
    /// <summary>
    /// Creates the ray gun factory.
    /// </summary>
    public class RayGunFactory
    {
        /// <summary>
        /// Creates the client chosen ray gun type.
        /// </summary>
        /// <param name="rayGun">ray gun type.</param>
        /// <returns>Instance of ray gun.</returns>
        public static BasicRayGun CreateRayGun(string rayGun)
        {
            return rayGun switch
            {
                "RedRayGun" => new RedRayGun(),
                "BlueRayGun" => new BlueRayGun(),
                _ => null,
            };
        }
    }
}
