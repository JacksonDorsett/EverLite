namespace EverLite.Modules.Enemies
{
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
        internal static Enemy CreateEnemy(string enemyType, ContentManager contentManager, Vector2 newPosition)
        {
            switch (enemyType)
            {
                case "regular":
                    return new SimpleEnemy(newPosition, contentManager);
                case "regular-alt":
                    return new SimpleEnemyAlternative(newPosition, contentManager);
                case "mid-boss":
                    return new MidBoss(newPosition, contentManager);
                case "final-boss":
                    return new FinalBoss(newPosition, contentManager);
                default:
                    throw new NotImplementedException("this enemy type is not implemented!");
            }
        }
    }
}
