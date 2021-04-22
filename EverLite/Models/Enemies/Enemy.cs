namespace EverLite
{
    using System;
    using System.Timers;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Enemy : LifetimeEntity, ICollidable
    {
        private bool isHit;
        private Health health;
        /// <summary>
        /// Initializes a new instance of the <see cref="Enemy"/> class.
        /// </summary>
        /// <param name="sprite">sprite of the enemy.</param>
        /// <param name="blaster">blaster pattern.</param>
        /// <param name="movement">movement pattern.</param>
        /// <param name="lifespan">lifespan pattern.</param>


        public Enemy(SpriteN sprite, Movement movement, int health = 100)
                : base(sprite, movement)
        {
            this.isHit = false;
            this.health = new Health(health);
            this.health.OnDeath += delegate { this.Die(); };
        }

        public event EventHandler OnCollide;


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
            health.TakeDamage(10);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            var c = Color.White;
            if (this.isHit) c = Color.Red;
            base.Draw(spriteBatch);
            spriteBatch.Begin();
            this.Sprite.Draw(spriteBatch, this.Position, c, rotation: this.Movement.Angle);
            spriteBatch.End();
        }

        private void HitAnimation()
        {
            this.isHit = true;
            Timer timer = new Timer(250); // 0.25 seconds
            timer.Elapsed += (e, o) => { this.isHit = false; };
            timer.AutoReset = false;
            timer.Start();
        }
    }
}
