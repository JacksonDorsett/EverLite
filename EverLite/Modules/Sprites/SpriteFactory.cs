// <copyright file="SpriteFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.Sprites
{
    using EverLite.Modules.Sprites;
    using EverLite.Modules.Enums;
    using Microsoft.Xna.Framework;

    /// <summary>
    /// In charge of making the different game sprites.
    /// </summary>
    public class SpriteFactory
    {
        /// <summary>
        /// Creates the needed sprite.
        /// </summary>
        /// <param name="spriteType">Type of instance to be created.</param>
        /// <param name="game">Game Reference.</param>
        /// <returns>Created instance.</returns>
        public static Sprite CreateSprite(FactoryEnum spriteType, Game game)
        {
            return spriteType switch
            {
                //FactoryEnum.Player => new Player(),
                FactoryEnum.TinyBlue => new TinyBlueBullets(),
                FactoryEnum.TinyRed => new TinyRedBullets(),
                _ => null,
            };
        }
    }
}
