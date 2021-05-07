﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace EverLite.Utilities
{

    class MirrorTransform : TransformAction
    {
        float curAngle = 0;
        bool isRotating;
        float pauseDelay;
        float angularVelocity;
        bool hasPaused;
        Timer timer;
        public MirrorTransform(float angularVelocity, float pauseDelay)
        {
            this.pauseDelay = pauseDelay;
            this.angularVelocity = angularVelocity;
            isRotating = true;
            hasPaused = false;
            timer = new Timer(pauseDelay * 1000);
            timer.Elapsed += delegate
            {
                this.isRotating = true;
            };
            timer.AutoReset = false;
        }
        public override bool IsComplete => curAngle >= (float)Math.PI * 2;

        public override Matrix TransformMatrix => Matrix.CreateTranslation(-mTransformOrigin.X, -mTransformOrigin.Y, 0f) *
                                                  Matrix.CreateRotationY(curAngle) *
                                                  Matrix.CreateTranslation(mTransformOrigin.X, mTransformOrigin.Y, 0f);

        public override float Angle
        {
            get
            {
                
                return 0;
            }
        }

        public override SpriteEffects SpriteEffect
        {
            get
            {
                if (curAngle >= (float)Math.PI / 2 && curAngle <= (float)Math.PI * 3 / 2)
                {
                    return SpriteEffects.FlipHorizontally;
                }
                return SpriteEffects.None;
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (this.IsComplete) return;
            if (!hasPaused && curAngle >= Math.PI)
            {
                hasPaused = true;
                isRotating = false;
                timer.Start();
            }
            if (isRotating) curAngle += angularVelocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
