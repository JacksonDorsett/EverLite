// <copyright file="Enemy.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.Enemies
{
    using EverLite.Modules.Behavior;
    using EverLite.Modules.Sprites;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System.Timers;

    /// <summary>
    /// Abstract enemy type.
    /// </summary>
    public class Enemy : LifetimeEntity
    {
        private bool isHit;

        /// <summary>
        /// Initializes a new instance of the <see cref="Enemy"/> class.
        /// </summary>
        /// <param name="sprite">sprite of the enemy.</param>
        /// <param name="blaster">blaster pattern.</param>
        /// <param name="movement">movement pattern.</param>
        /// <param name="lifespan">lifespan pattern.</param>
        public Enemy(SpriteN sprite, IMovement movement, float lifespan)
            : base(sprite, movement, (double)lifespan)
        {
            this.isHit = false;
        }

        /// <summary>
        /// gets or sets blaster object.
        /// </summary>

        /// <summary>
        /// Update function to update the enemy.
        /// </summary>
        /// <param name="gameTime">gametime.</param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

        }
        /// <summary>
        /// Handles collision with an object.
        /// </summary>
        /// <param name="collidable"> object colided with.</param>
        protected override void CollidesWith(ICollidable collidable)
        {
            // TODO: implement health system action.
            base.CollidesWith(collidable);
            this.HitAnimation();
        }

        public void HitAnimation()
        {
            this.isHit = true;
            Timer timer = new Timer(0.025); // 0.25 seconds
            timer.Elapsed += (e, o) => { this.isHit = false; };
            timer.AutoReset = false;
            timer.Start();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            var c = Color.White;
            if (this.isHit) c = Color.Red;
            base.Draw(spriteBatch);
            spriteBatch.Begin();
            this.Sprite.Draw(spriteBatch, this.Position, c, rotation: this.movementPattern.Angle(this.Halflife));
            spriteBatch.End();
        }
    }

}
