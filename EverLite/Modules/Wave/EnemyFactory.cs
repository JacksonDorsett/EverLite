

namespace EverLite.Modules.Wave
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EverLite.Modules.Behavior;
    using EverLite.Modules.Blaster;
    using EverLite.Modules.Enemies;
    using EverLite.Modules.Sprites;
    public class EnemyFactory
    {
        private readonly SpriteN sprite;
        private readonly IMovement movement;
        private readonly float lifespan;
        private IBlaster blaster;

        /// <summary>
        /// Initializes a new instance of the <see cref="EnemyFactory"/> class.
        /// </summary>
        /// <param name=""></param>
        public EnemyFactory(SpriteN sprite, IBlaster blaster, IMovement movement, float lifespan)
        {
            this.sprite = sprite;
            this.movement = movement;
            this.lifespan = lifespan;
            this.blaster = blaster;
        }

        public Enemy Spawn()
        {
            return new Enemy(this.sprite, this.blaster, this.movement, this.lifespan);
        }
    }
}
