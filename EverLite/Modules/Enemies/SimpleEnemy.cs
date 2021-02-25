// <copyright file="SimpleEnemy.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.Enemies
{
    using EverLite.Modules.Blaster;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;

    /// <summary>
    /// Regular enemy type A.
    /// </summary>
    internal class SimpleEnemy : Enemy
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleEnemy"/> class.
        /// </summary>
        /// <param name="game"> game ref.</param>
        public SimpleEnemy(Game game, IBlaster blaster)
            : base(game, blaster) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleEnemy"/> class.
        /// </summary>
        /// <param name="game"> game ref.</param>
        /// <param name="newPosition"> new position.</param>
        public SimpleEnemy(Vector2 newPosition, Game game, IBlaster blaster)
            : base(newPosition, game,  blaster) { }

        /// <inheritdoc/>
        public override string SpriteName { get; set; } = "enemy1";

        /// <inheritdoc/>
        public override bool IsVisible { get; set; } = true;
    }
}
