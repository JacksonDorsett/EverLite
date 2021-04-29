namespace EverLite
{
    using Microsoft.Xna.Framework;

    class LifeTimeMovement : Movement
    {

        IMovement movement;
        Lifespan lifeSpan;
        double totalLifeSpan;
        public LifeTimeMovement(double lifeSpan, IMovement movementType)
        {
            this.movement = movementType;
            this.lifeSpan = new Lifespan(lifeSpan);
            this.totalLifeSpan = lifeSpan;
        }

        public override Vector2 Position
        {
            get
            {
                return this.movement.GetPosition(lifeSpan.Halflife);
            }
            protected set
            {
                return;
            }
        }

        public double LifeTime => totalLifeSpan;

        public float Distance => this.movement.Distance;

        public override float Angle => movement.Angle((double)lifeSpan.Halflife);
        
        protected IMovement Movement { get => this.movement; }

        public override bool PathCompleted => lifeSpan.Halflife >= 1;

        public override Movement Clone()
        {
            return new LifeTimeMovement(totalLifeSpan, movement);
        }

        public override void Update(GameTime gameTime)
        {
            this.lifeSpan.Update(gameTime);
        }
    }
}
