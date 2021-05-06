namespace EverLite.Models.Weapons.SpawnPatterns
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    public abstract class SpawnPattern
    {
        private readonly SpriteN bulletSprite;
        private int numSpawned;
        private readonly int totalBullets;
        private double spawnRate;
        protected List<Bullet> bulletList;
        private double timeElapsed;
        private double speed;
        private SoundManager sound;
        private VolumeManager volume;

        public SpawnPattern(List<Bullet> bullets, SpriteN bulletSprite, float speed, int totalBullets, double spawnRate)
        {
            this.bulletList = bullets;
            this.bulletSprite = bulletSprite;
            this.totalBullets = totalBullets;
            this.spawnRate = spawnRate;
            this.numSpawned = 0;
            this.IsEnabled = false;
            this.timeElapsed = 0;
            this.speed = speed;
            this.sound = SoundManager.Instance;
            this.volume = VolumeManager.Instance;
        }

        public virtual bool IsEnabled { get; set; }

        protected abstract void Spawn(Vector2 spawnPosition);

        protected SpriteN Sprite { get => this.bulletSprite; }
        
        protected double Speed { get => this.speed; }
        
        protected double SpawnRate { get => spawnRate; }

        protected int TotalBullets => totalBullets;

        public event EventHandler OnComplete;

        public virtual void Update(GameTime gameTime, Vector2 position)
        {
            if (this.IsEnabled)
            {
                this.timeElapsed += gameTime.ElapsedGameTime.TotalSeconds;

                if (this.timeElapsed > this.SpawnRate)
                {
                    this.timeElapsed -= this.SpawnRate;
                    this.Spawn(position);

                    this.sound.GunShot.Play(volume: volume.SoundLevel, pitch: 0.0f, pan: 0.0f);

                    this.numSpawned++;

                    if (this.numSpawned >= this.TotalBullets)
                    {
                        this.IsEnabled = false;
                        Invoke();
                    }
                }
            }
        }
        protected void Invoke()
        {
            this.OnComplete.Invoke(this, new EventArgs());
        }
        public abstract SpawnPattern Clone();
    }
}
