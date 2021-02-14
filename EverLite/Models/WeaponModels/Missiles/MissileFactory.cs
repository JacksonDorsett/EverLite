// <copyright file="MissileFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Models.WeaponModels.Missiles
{
    /// <summary>
    /// Creates the missile factory.
    /// </summary>
    public class MissileFactory
    {
        /// <summary>
        /// Creates the client chosen missile type;
        /// </summary>
        /// <param name="missile">missile type.</param>
        /// <returns>Instance of missile.</returns>
        public static BasicMissile CreateMissile(string missile)
        {
            return missile switch
            {
                "SingleGreenMissile" => new SingleGreenMissile(),
                "SingleAquaMissile" => new SingleAquaMissile(),
                _ => null,
            };
        }
    }
}
