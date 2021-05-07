using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace EverLite.Utilities
{
    class NullTransform : TransformAction
    {
        public override Matrix TransformMatrix => Matrix.Identity;

        public override float Angle => 0;

        public override SpriteEffects SpriteEffect => SpriteEffects.None;

        public override void Update(GameTime gameTime)
        {
        }
    }
}
