using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace EverLite.Utilities
{
    public class TransformManager
    {
        private static TransformManager mInstance;
        private TransformAction current;
        private TransformManager()
        {
            current = new MirrorTransform(3, 20);
            mInstance = this;
        }

        public void Update(GameTime gameTime)
        {
            if (current.IsComplete) return;

            current.Update(gameTime);
        }

        public bool SetTransformAction(TransformAction action)
        {
            if (!this.current.IsComplete) return false;

            this.current = action;
            return true;
        }

        public static TransformManager Instance { get { if (mInstance == null) mInstance = new TransformManager(); return mInstance; } }

        public bool IsTransformActive { get => !current.IsComplete; }

        public float Angle { get => this.current.Angle; }
        public Matrix Transform { get => this.current.TransformMatrix; }

        public SpriteEffects SpriteEffect { get => current.SpriteEffect; }
    }
}
