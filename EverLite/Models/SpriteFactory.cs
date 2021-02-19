namespace EverLite.Models
{
    using System;

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
                FactoryEnum.Bullets => new Bullets(),
                _ => null,
            };
        }
    }
}
