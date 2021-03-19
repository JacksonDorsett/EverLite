
namespace EverLite.Modules.Behavior
{
    using EverLite.Modules.Enemies;
    using EverLite.Modules.Sprites;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Lifetime dependent Entity.
    /// </summary>
    public class LifetimeEntity : Entity
    {
        private SpriteN mSprite;
        protected IMovement movementPattern;
        private Lifespan lifespan;

        /// <summary>
        /// Initializes a new instance of the <see cref="LifetimeEntity"/> class.
        /// </summary>
        /// <param name="sprite"></param>
        public LifetimeEntity(SpriteN sprite, IMovement movement, double lifetime)
            : base(sprite)
        {
            this.movementPattern = movement;
            this.lifespan = new Lifespan(lifetime);
        }

        public override Vector2 Position { get => this.movementPattern.GetPosition(this.lifespan.Halflife); protected set => throw new NotImplementedException(); }
        public override SpriteN Sprite { get => this.mSprite; protected set => this.mSprite = value; }

        public bool IsAlive { get => this.lifespan.Halflife < 1; }
        public override void Update(GameTime gameTime)
        {
            this.lifespan.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            this.Sprite.Draw(spriteBatch, this.Position, rotation: this.movementPattern.Angle(this.lifespan.Halflife));
            spriteBatch.End();
        }
    }
}
