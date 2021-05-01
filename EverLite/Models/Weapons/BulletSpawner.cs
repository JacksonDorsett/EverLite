namespace EverLite
{
    using global::EverLite.Models.Weapons.SpawnPatterns;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;
    using System.Timers;

    public class BulletSpawner : LifetimeEntity
    {
        bool completedflag = false; //indicates if the on complete has been fired.
        private SpawnPattern spawnPattern;
        //private double lifetime;
        Movement move;
        Timer delayTimer;
        double delay;
        bool DelayTimerStarted;
        public BulletSpawner(Movement movement, SpawnPattern spawnPattern, double shootDelay = 0)
            : base(new NoSprite(), movement)
        {
            this.spawnPattern = spawnPattern;
            this.move = movement;
            delay = shootDelay;
            delayTimer = new Timer();

            if (shootDelay > 0)
            {
                spawnPattern.IsEnabled = false;
                delayTimer.Interval = delay * 1000;
                delayTimer.Elapsed += delegate
                {
                    spawnPattern.IsEnabled = true;
                    delayTimer.AutoReset = false;
                };
                
            }
            else spawnPattern.IsEnabled = true;

        }

        public bool IsComplete => !delayTimer.Enabled && !this.spawnPattern.IsEnabled;

        public event EventHandler OnComplete;
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (!DelayTimerStarted)
            {
                DelayTimerStarted = true;

                if (delay > 0)
                {
                    this.delayTimer.Start();
                }

            }
            if (spawnPattern.IsEnabled)
            {
                this.spawnPattern.Update(gameTime, this.Position);
            }
            if(IsComplete && !this.completedflag)
            {
                this.OnComplete?.Invoke(this, new EventArgs());
            }
        }

        public BulletSpawner Clone()
        {
            return new BulletSpawner(Movement.Clone(), spawnPattern.Clone(), delay);
        }
    }
}
