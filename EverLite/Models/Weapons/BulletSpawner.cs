namespace EverLite
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class BulletSpawner : LifetimeEntity
    {
        private SpawnPattern spawnPattern;
        private double lifetime;
        private IMovement movement;
        Movement move;
        public BulletSpawner(Movement movement, SpawnPattern spawnPattern)
            : base(new NoSprite(), movement)
        {
            this.spawnPattern = spawnPattern;
            this.lifetime = lifetime;
            this.move = movement;
            this.spawnPattern.IsEnabled = true;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            this.spawnPattern.Update(gameTime, this.Position);
        }

        public BulletSpawner Clone()
        {
            return new BulletSpawner(Movement.Clone(), spawnPattern.Clone());
        }
    }
}
