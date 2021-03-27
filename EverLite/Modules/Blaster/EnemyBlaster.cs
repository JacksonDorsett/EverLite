// <copyright file="EnemyBlaster.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.Blaster
{
    using EverLite.Modules.Behavior;
    using EverLite.Modules.Sprites;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Standard Enemy Blaster.
    /// </summary>
    public class EnemyBlaster : IBlaster, IHitbox
    {
        private Player player;
        private Game game;
        private Texture2D texture;
        private double rateOfFire;
        private double timeElapsed;

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
            this.timeElapsed = 0;
        }

        public Sprite Shoot(Vector2 position)
        {
            if (this.timeElapsed >= this.rateOfFire)
            {
                this.timeElapsed = 0;
                return new TinyRedBullets(this.texture, position, this.CalculateVelocity(position));
            }
            return null;
        }

        public void Update(GameTime gameTime)
        {
            this.timeElapsed += gameTime.ElapsedGameTime.TotalSeconds;


        }

        private Vector2 CalculateVelocity(Vector2 Position)
        {
            var diff = this.player.GetPosition() - Position;
            //get Magnitude
            diff.Normalize();
            return diff * 10;
        }

        /// <summary>
        /// Function that returns a hitbox.
        /// </summary>
        /// <returns> hitbox.</returns>
        Rectangle IHitbox.GetHitBox()
        {
            return new Rectangle(texture.Width, texture.Height);
        }
    }
}
