// <copyright file="SimpleEnemyAlternative.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.Enemies
{
    using EverLite.Modules.Blaster;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;

    /// <summary>
    /// Regular enemy type B class.
    /// </summary>
    internal class SimpleEnemyAlternative : Enemy
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleEnemyAlternative"/> class.
        /// </summary>
        /// <param name="contentManager"> content manager ref.</param>
        public SimpleEnemyAlternative(ContentManager contentManager, IBlaster blaster)
            : base(contentManager, blaster) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleEnemyAlternative"/> class.
        /// </summary>
        /// <param name="contentManager"> content manager ref.</param>
        /// <param name="newPosition"> new position.</param>
        public SimpleEnemyAlternative(Vector2 newPosition, ContentManager contentManager, IBlaster blaster)
            : base(newPosition, contentManager, blaster) { }

        /// <inheritdoc/>
        public override string SpriteName { get; set; } = "uw";

        /// <inheritdoc/>
        public override bool IsVisible { get; set; } = true;
    }
}
