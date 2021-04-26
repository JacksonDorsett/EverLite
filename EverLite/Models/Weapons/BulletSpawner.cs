namespace EverLite
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System.Timers;

    public class BulletSpawner : LifetimeEntity
    {
        private SpawnPattern spawnPattern;
        //private double lifetime;
        Movement move;
        Timer delayTimer;
        public BulletSpawner(Movement movement, SpawnPattern spawnPattern, double shootDelay = 0)
            : base(new NoSprite(), movement)
        {
            this.spawnPattern = spawnPattern;

            this.move = movement;
            this.spawnPattern.IsEnabled = true;
            if (shootDelay > 0)
            {
                spawnPattern.IsEnabled = false;
                delayTimer = new Timer(shootDelay);
                delayTimer.Elapsed += delegate { spawnPattern.IsEnabled = true; };
                delayTimer.AutoReset = false;
                delayTimer.Start();
            }
            

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
