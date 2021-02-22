// <copyright file="EnumToStringFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.Enums
{
    /// <summary>
    /// Solution when dealing with assigning specific Texture2D objects to the sprite.
    /// </summary>
    public class EnumToStringFactory
    {
        /// <summary>
        /// Returns the string needed for assigning the picture.
        /// </summary>
        /// <param name="value">Specific enum.</param>
        /// <returns>String name of specific enum.</returns>
        public static string GetEnumToString(FactoryEnum value)
        {
            return value switch
            {
                FactoryEnum.Player => "Rocket",
                FactoryEnum.TinyBlue => "TinyBlue",
                FactoryEnum.TinyRed => "TinyRed",
                _ => null,
            };
        }

    }
}
