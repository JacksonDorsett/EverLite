// <copyright file="BulletChoiceFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Models.Enums
{
    /// <summary>
    /// Used by the player to switch between bullet types.
    /// </summary>
    public class BulletChoiceFactory
    {
        /// <summary>
        /// Provides the needed bullet type enum for the player when switching weapons.
        /// </summary>
        /// <param name="value">Type of bullet wanted.</param>
        /// <returns>Enum of bullet type.</returns>
        public static FactoryEnum GetBulletType(string value)
        {
            return value switch
            {
                "TinyRed" => FactoryEnum.TinyRed,
                "TinyBlue" => FactoryEnum.TinyBlue,
                _ => throw new System.NotImplementedException(),
            };
        }
    }
}
