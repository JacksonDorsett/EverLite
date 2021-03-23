

namespace EverLite.Modules.Blaster
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EverLite.Modules.Sprites;
    using EverLite.Utilities;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Standard Enemy Blaster.
    /// </summary>
    public class EnemyBlaster : IShootingPattern, IBlaster
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

        public void Shoot(Vector2 position)
        {
            throw new NotImplementedException();
        }

        public void Update(GameTime gameTime)
        {
        }

        private Vector2 CalculateVelocity(Vector2 Position)
        {
            var diff = this.player.GetPosition() - Position;
            //get Magnitude
            diff.Normalize();
            return diff * 10;
        }

        Sprite IBlaster.Shoot(Vector2 position)
        {
            throw new NotImplementedException();
        }
    }
}
