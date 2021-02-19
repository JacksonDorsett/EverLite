// <copyright file="SimpleEnemy.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.Enemies
{
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
        /// <param name="contentManager"> content manager ref.</param>
        public SimpleEnemy(ContentManager contentManager)
            : base(contentManager) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleEnemy"/> class.
        /// </summary>
        /// <param name="contentManager"> content manager ref.</param>
        /// <param name="newPosition"> new position.</param>
        public SimpleEnemy(Vector2 newPosition, ContentManager contentManager)
            : base(newPosition, contentManager) { }

        /// <inheritdoc/>
        public override string SpriteName { get; set; } = "wsu";

        /// <inheritdoc/>
        public override bool IsVisible { get; set; } = true;
    }
}
