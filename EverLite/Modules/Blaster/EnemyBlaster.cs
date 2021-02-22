﻿using EverLite.Modules.Sprites;
using EverLite.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace EverLite.Modules.Blaster
{
    /// <summary>
    /// Standard Enemy Blaster.
    /// </summary>
    class EnemyBlaster : IBlaster
    {
        private Player player;
        private Texture2D texture;
        private double rateOfFire;
        private double TimeElapsed;
        /// <summary>
        /// Initializes a new instance of the <see cref="EnemyBlaster"/> class.
        /// </summary>
        /// <param name="player">player reference.</param>
        /// <param name="texture">texture of bullet.</param>
        public EnemyBlaster(Player player, Texture2D texture, float rof = 2)
        {
            this.texture = texture;
            this.player = player;
            this.rateOfFire = rof;
            this.TimeElapsed = 0;
        }

        public Sprite Shoot(Vector2 position)
        {
            if (this.TimeElapsed >= this.rateOfFire)
            {
                this.TimeElapsed = 0;
                return new TinyRedBullets(this.texture, position, this.CalculateVelocity(position));
            }
            return null;
        }

        public void Update(GameTime gameTime)
        {
            this.TimeElapsed += gameTime.ElapsedGameTime.TotalSeconds;


        }

        private Vector2 CalculateVelocity(Vector2 Position)
        {
            var diff = this.player.GetPosition() - Position;
            //get Magnitude
            diff.Normalize();
            return diff * 10;
        }
    }
}
