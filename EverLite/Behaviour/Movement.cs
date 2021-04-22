namespace EverLite
{
    using Microsoft.Xna.Framework;

    public abstract class Movement
    {
        public abstract Vector2 Position { get; protected set; }

        public abstract void Update(GameTime gameTime);

        public abstract float Angle { get; }

        public abstract bool PathCompleted { get; }

        public abstract Movement Clone();
    }
}
