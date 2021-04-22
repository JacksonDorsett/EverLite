namespace EverLite
{
    using Microsoft.Xna.Framework;

    public class Bullet : LifetimeEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Bullet"/> class.
        /// </summary>
        /// <param name="sprite">bullet sprite.</param>
        /// <param name="movementPattern">movement pattern of bullet.</param>
        public Bullet(SpriteN sprite, Movement movement)
            : base(sprite, movement)
        {
        }

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
            this.Die();
        }
    }
}
