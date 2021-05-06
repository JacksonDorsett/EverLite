using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EverLite.Utilities
{
    class RotateTransform : TransformAction
    {
        float angle;
        public RotateTransform(float angle)
        {
            this.angle = angle;

        }
        public override Matrix TransformMatrix => Matrix.CreateTranslation(-mTransformOrigin.X, -mTransformOrigin.Y, 0f) *
                                                  Matrix.CreateRotationZ(angle)*
                                                  Matrix.CreateTranslation(mTransformOrigin.X, mTransformOrigin.Y, 0f);

        public override float Angle => angle;

        public override void Update(GameTime gameTime)
        {
        }
    }
}
