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
        public Bullet(SpriteN sprite, VectorMovement movement)
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
        public override void CollidesWith(ICollidable collidable)
        {
            this.Die();
        }

        public void SetVelocity(Vector2 velocity)
        {
            velocity.Normalize();

            this.Movement = new LinearVectorMovement(Movement.Position, Movement.Position + velocity, (Movement as VectorMovement).Speed);
        }
    }
}
