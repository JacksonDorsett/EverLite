using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace EverLite.Utilities
{
    public class TransformManager
    {
        Queue<TransformAction> transformQueue;
        private static TransformManager mInstance;
        private TransformAction defaultTransform;
        private TransformManager()
        {
            //defaultTransform = new NullTransform();
            defaultTransform = new HorizontalRotateTransform(3, 3);
            mInstance = this;
            transformQueue = new Queue<TransformAction>();
        }

        public void Update(GameTime gameTime)
        {
            if (transformQueue.Count == 0) return;

            transformQueue.Peek().Update(gameTime);
            if (transformQueue.Peek().IsComplete) transformQueue.Dequeue();

        }

        public bool QueueTransformAction(TransformAction action)
        {
            this.transformQueue.Enqueue(action);
            return true;
        }

        public static TransformManager Instance { get { if (mInstance == null) mInstance = new TransformManager(); return mInstance; } }

        public bool IsTransformActive { get => transformQueue.Count != 0; }

        public float Angle { get { if (transformQueue.Count == 0) return defaultTransform.Angle; return transformQueue.Peek().Angle; } }
        public Matrix Transform { get { if (transformQueue.Count == 0) return defaultTransform.TransformMatrix; return transformQueue.Peek().TransformMatrix; } }

        public SpriteEffects SpriteEffect { get { if (transformQueue.Count == 0) return defaultTransform.SpriteEffect;  return transformQueue.Peek().SpriteEffect; } }
    }
}
