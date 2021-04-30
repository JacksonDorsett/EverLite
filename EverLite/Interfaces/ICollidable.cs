namespace EverLite
{
    using System;

    /// <summary>
    /// Interface for collidable objects.
    /// </summary>
    public interface ICollidable
    {
        event EventHandler OnCollide;

        /// <summary>
        /// Called when object collided with another object.
        /// </summary>
        /// <param name="collidable"> object we colided with</param>
        public void CollidesWith(ICollidable collidable);

        HitCircle HitCircle { get; }
    }
}
