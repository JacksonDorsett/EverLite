namespace EverLite.Modules.Enemies
{
    using System;
    using EverLite.Modules.Blaster;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;

    /// <summary>
    /// Factory for the <seealso cref="Enemy"/> class.
    /// </summary>
    internal static class EnemyFactory
    {
        /// <summary>
        /// Creates an enemy of a given type. Throws exception if type is not implemented.
        /// </summary>
        /// <param name="enemyType"> enemy type to create.</param>
        /// <param name="game"> game ref.</param>
        /// <param name="newPosition"> positon.</param>
        /// <returns> created enemy object.</returns>
        internal static Enemy CreateEnemy(string enemyType, Game game, Vector2 newPosition, IBlaster blaster)
        {
            switch (enemyType)
            {
                case "regular":
                    return new SimpleEnemy(newPosition, game, blaster);
                case "regular-alt":
                    return new SimpleEnemyAlternative(newPosition, game, blaster);
                case "mid-boss":
                    return new MidBoss(newPosition, game, blaster);
                case "final-boss":
                    return new FinalBoss(newPosition, game, blaster);
                default:
                    throw new NotImplementedException("this enemy type is not implemented!");
            }
        }
    }
}
