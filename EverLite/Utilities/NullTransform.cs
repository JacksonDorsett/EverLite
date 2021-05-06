using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EverLite.Utilities
{
    class NullTransform : TransformAction
    {
        public override Matrix matrix => Matrix.Identity;

        public override float Angle => 0;

        public override void Update(GameTime gameTime)
        {
        }
    }
}
