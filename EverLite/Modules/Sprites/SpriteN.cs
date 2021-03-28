// <copyright file="SpriteN.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.Sprites
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Timers;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class SpriteN
    {
        private Texture2D mTexture;

        public Color Color = Color.White;

        public SpriteN(Texture2D texture)
        {
            this.mTexture = texture;
        }

        public Texture2D Texture { get { return this.mTexture; } }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 position, float scale = 1, float rotation = 0)
        {
            Vector2 origin = new Vector2(0, 0);
            origin.X = this.mTexture.Width / 2;
            origin.Y = this.mTexture.Height / 2;
            spriteBatch.Draw(this.mTexture, position, null, this.Color, rotation, origin, scale, SpriteEffects.None, 0);
        }

        /// <summary>
        /// Hit animation
        /// </summary>
        public void HitAnimation()
        {
            this.Color = Color.Red;
            Timer timer = new Timer(0.00025); // 0.25 seconds
            timer.Elapsed += (e, o) => { this.Color = Color.White; };
            timer.AutoReset = false;
            timer.Start();
        }
    }
}
