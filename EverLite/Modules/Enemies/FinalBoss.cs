// <copyright file="FinalBoss.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.Enemies
{
    using EverLite.Modules.Blaster;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;

    /// <summary>
    /// Final boss class.
    /// </summary>
    internal class FinalBoss : MidBoss
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FinalBoss"/> class.
        /// </summary>
        /// <param name="contentManager"> content manager ref.</param>
        /// <param name="blaster"> blaster for boss.</param>
        public FinalBoss(Game game, IBlaster blaster)
            : base(game, blaster) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="FinalBoss"/> class.
        /// </summary>
        /// <param name="contentManager"> content manager ref.</param>
        /// <param name="newPosition"> new position.</param>
        /// <param name="blaster"> blaster for the boss.</param>
        public FinalBoss(Vector2 newPosition, Game game, IBlaster blaster)
            : base(newPosition, game, blaster) { }

        /// <inheritdoc/>
        public override string SpriteName { get; set; } = "final-boss";

        /// <inheritdoc/>
        public override bool IsVisible { get; set; } = true;
    }
}
