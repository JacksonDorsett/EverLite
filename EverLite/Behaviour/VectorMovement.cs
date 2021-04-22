namespace EverLite
{
    using Microsoft.Xna.Framework;

    abstract class VectorMovement : Movement
    {
        protected Vector2 startPosition;
        private Vector2 curPosition;
        private Rectangle bounds;

        public VectorMovement(Vector2 StartPosition)
        {
            startPosition = StartPosition;
            curPosition = StartPosition;
            bounds = new Rectangle(-200, -200, 2000, 2300);
        }

        public override Vector2 Position { get => curPosition; protected set => curPosition = value; }

        public override bool PathCompleted => !this.bounds.Contains(Position);
    }
}
