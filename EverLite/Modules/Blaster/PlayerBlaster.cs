// <copyright file="PlayerBlaster.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.Blaster
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EverLite.Modules.Sprites;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Player Blaster.
    /// </summary>
    public class PlayerBlaster : IBlaster
    {
        private Texture2D bulletTexture;
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerBlaster"/> class.
        /// </summary>
        /// <param name="player">player reference.</param>
        public PlayerBlaster(Texture2D bulletTexture)
        {
            this.bulletTexture = bulletTexture;
        }

        public Sprite Shoot(Vector2 position)
        {
            position.X += 22;
            return new TinyBlueBullets(this.bulletTexture, position, new Vector2(0, -16));
        }
    }
}
