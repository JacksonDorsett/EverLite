using Microsoft.Xna.Framework;

namespace EverLite.Utilities
{
    public abstract class TransformAction
    {
        public bool IsComplete { get; private set; }
        public virtual Matrix matrix { get; private set; }

        public virtual float Angle { get; private set; }

        public abstract void Update(GameTime gameTime);
    }
}