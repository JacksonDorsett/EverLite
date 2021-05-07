using EverLite.Models.Weapons.SpawnPatterns;
using EverLite.Utilities;
using Microsoft.Xna.Framework;

namespace EverLite.ScriptInterperiter
{
    internal class HorizontalRotationPattern : SpawnPattern
    {
        private float rotationSpeed;
        private float pauseDelay;

        public HorizontalRotationPattern(float speed, float pauseDelay) : base(null, null, 0, 1, 2)
        {
            this.rotationSpeed = speed;
            this.pauseDelay = pauseDelay;
        }

        public override SpawnPattern Clone()
        {
            return new HorizontalRotationPattern(rotationSpeed, pauseDelay);
        }

        protected override void Spawn(Vector2 spawnPosition)
        {
            TransformManager.Instance.QueueTransformAction(new HorizontalRotateTransform(rotationSpeed, pauseDelay));
        }
    }
}