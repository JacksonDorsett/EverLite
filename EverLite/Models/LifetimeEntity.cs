namespace EverLite
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class LifetimeEntity : Entity, ICollidable
    {
        private SpriteN mSprite;
        private Lifespan lifespan;
        private bool isAliveFlag;
        protected Movement move;
        public event EventHandler OnCollide;


        public LifetimeEntity(SpriteN sprite, Movement movement)
            : base(sprite)
        {
            this.move = movement;
            this.isAliveFlag = true;
        }


        public event EventHandler OnDeath;

        public override Vector2 Position { get => move.Position; protected set => throw new NotImplementedException(); }
        public override SpriteN Sprite { get => this.mSprite; protected set => this.mSprite = value; }


        protected double Halflife { get => this.lifespan.Halflife; }

        public bool IsAlive { get => !this.move.PathCompleted && this.isAliveFlag; }

        virtual public HitCircle HitCircle
        {
            get
            {
                float r = (float)(this.Sprite.Texture.Width > this.Sprite.Texture.Height ? Sprite.Texture.Height : Sprite.Texture.Width);
                var p = Position;
                return new HitCircle(p, r / 4);

            }
        }

        protected Movement Movement { get => this.move; }

        public override void Update(GameTime gameTime)
        {
            move.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            this.Sprite.Draw(spriteBatch, this.Position, rotation: this.move.Angle);
            spriteBatch.End();
        }

        /// <summary>
        /// Function that flags the entity as dead.
        /// </summary>
        public void Die()
        {
            this.isAliveFlag = false;
            this.OnDeath?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Handles collision with an object.
        /// </summary>
        /// <param name="collidable"> object colided with.</param>
        void ICollidable.CollidesWith(ICollidable collidable)
        {
            this.CollidesWith(collidable);
        }

        /// <summary>
        /// Handles collision with an object.
        /// </summary>
        /// <param name="collidable"> object colided with.</param>
        public virtual void CollidesWith(ICollidable collidable)
        {
        }
    }
}
