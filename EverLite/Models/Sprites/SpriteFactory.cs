// <copyright file="SpriteFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Models.Enums
{
    using EverLite.Models.Sprites;

    /// <summary>
    /// In charge of making the different game sprites.
    /// </summary>
    public class SpriteFactory
    {
        /// <summary>
        /// Creates the needed sprite.
        /// </summary>
        /// <param name="spriteType">Type of instance to be created.</param>
        /// <returns>Created instance.</returns>
        public static Sprite CreateSprite(FactoryEnum spriteType)
        {
            return spriteType switch
            {
                FactoryEnum.Player => new Player(),
                FactoryEnum.TinyBlue => new TinyBlueBullets(),
                FactoryEnum.TinyRed => new TinyRedBullets(),
                _ => null,
            };
        }
    }
}
