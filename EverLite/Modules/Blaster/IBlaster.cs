// <copyright file="IBlaster.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.Blaster
{
    using EverLite.Modules.Sprites;
    using Microsoft.Xna.Framework;
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Blaster Interface.
    /// </summary>
    public interface IBlaster
    {
        /// <summary>
        /// Shoot blaster.
        /// </summary>
        public Sprite Shoot(Vector2 position);

        public void Update(GameTime gameTime);
    }
}
