// <copyright file="FinalBoss.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.Enemies
{
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
        public FinalBoss(ContentManager contentManager)
            : base(contentManager) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="FinalBoss"/> class.
        /// </summary>
        /// <param name="contentManager"> content manager ref.</param>
        /// <param name="newPosition"> new position.</param>
        public FinalBoss(Vector2 newPosition, ContentManager contentManager)
            : base(newPosition, contentManager) { }

        /// <inheritdoc/>
        public override string SpriteName { get; set; } = "final-boss";

        /// <inheritdoc/>
        public override bool IsVisible { get; set; } = true;
    }
}
