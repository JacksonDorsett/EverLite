using Microsoft.Xna.Framework;

namespace EverLite.Utilities
{
    public abstract class TransformAction
    {
        protected Vector2 mTransformOrigin = new Vector2(750, 500);
        public virtual bool IsComplete { get; private set; }
        public virtual Matrix TransformMatrix { get; private set; }

        public virtual float Angle { get; private set; }

        public abstract void Update(GameTime gameTime);
    }
}