using EverLite.Models.Weapons.SpawnPatterns;
using EverLite.Utilities;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace EverLite.ScriptInterperiter
{
    internal class RotateScreenPattern : SpawnPattern
    {
        TransformManager transformManager;
        float angularVelocity;
        float pauseDelay;
        public RotateScreenPattern(float angularVelocity, float pauseDelay) : base(null, null, 0, 1, 2)
        {
            transformManager = TransformManager.Instance;
            this.angularVelocity = angularVelocity;
            this.pauseDelay = angularVelocity;
        }

        public override SpawnPattern Clone()
        {
            return new RotateScreenPattern(angularVelocity, pauseDelay);
        }

        protected override void Spawn(Vector2 spawnPosition)
        {
            transformManager.QueueTransformAction(new FullRotationTransform(angularVelocity, pauseDelay));
        }
    }
}