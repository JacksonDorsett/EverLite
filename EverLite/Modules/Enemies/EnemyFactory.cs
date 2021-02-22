namespace EverLite.Modules.Enemies
{
    using EverLite.Modules.Blaster;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using System;

    /// <summary>
    /// Factory for the <seealso cref="Enemy"/> class.
    /// </summary>
    internal static class EnemyFactory
    {
        /// <summary>
        /// Creates an enemy of a given type. Throws exception if type is not implemented.
        /// </summary>
        /// <param name="enemyType"> enemy type to create.</param>
        /// <param name="contentManager"> content manager ref.</param>
        /// <param name="newPosition"> positon.</param>
        /// <returns> created enemy object.</returns>
        internal static Enemy CreateEnemy(string enemyType, ContentManager contentManager, Vector2 newPosition, IBlaster blaster)
        {
            switch (enemyType)
            {
                case "regular":
                    return new SimpleEnemy(newPosition, contentManager, blaster);
                case "regular-alt":
                    return new SimpleEnemyAlternative(newPosition, contentManager, blaster);
                case "mid-boss":
                    return new MidBoss(newPosition, contentManager, blaster);
                case "final-boss":
                    return new FinalBoss(newPosition, contentManager, blaster);
                default:
                    throw new NotImplementedException("this enemy type is not implemented!");
            }
        }
    }
}
