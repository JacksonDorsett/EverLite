namespace EverLite
{
    using System;
    using System.Timers;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class Item : LifetimeEntity, ICollidable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Item"/> class.
        /// </summary>
        /// <param name="sprite">sprite of the enemy.</param>
        /// <param name="movement">movement pattern.</param>
        public Item(SpriteN sprite, Movement movement)
                : base(sprite, movement)
        {
            
        }

        public override Vector2 Position { get => base.Position; protected set => base.Position = value; }
        public override SpriteN Sprite { get => base.Sprite; protected set => base.Sprite = value; }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void CollidesWith(ICollidable collidable)
        {
            this.Die();
        }
    }
}
