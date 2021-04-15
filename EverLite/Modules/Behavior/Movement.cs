using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EverLite.Modules.Behavior
{
    public abstract class Movement
    {
        public abstract Vector2 Position { get; protected set; }

        public abstract void Update(GameTime gameTime);

        public abstract float Angle { get; }

        public abstract bool PathCompleted { get; }

        public abstract Movement Clone();
    }
}
