using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Timers;

namespace EverLite.Models.Items
{
    internal class SeismicCharge : Item
    {
        private bool isPrimed = false;
        private float waveSize;
        private float originalSize;
        private float scale = 1;

        private HitCircle hitCircle;

        public HashSet<Enemy> HitEnemies = new HashSet<Enemy>() { };

        public bool IsPrimed
        {
            get
            {
                return this.isPrimed;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SeismicCharge"/> class.
        /// </summary>
        /// <param name="sprite">sprite of the enemy.</param>
        /// <param name="movement">movement pattern.</param>
        public SeismicCharge(SpriteN sprite, Movement movement)
                : base(sprite, movement)
        {
            float r = (float)(this.Sprite.Texture.Width > this.Sprite.Texture.Height ? Sprite.Texture.Height : Sprite.Texture.Width);
            var p = Position;
            this.hitCircle = new HitCircle(p, r / 2);
        }

        public override HitCircle HitCircle
        {
            get
            {
                return this.hitCircle;
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (this.isPrimed)
            {
                float scaleFactor = (waveSize + 8) / originalSize;
                waveSize += 8;
                this.scale = scaleFactor;
                this.hitCircle.Radius += (originalSize * scaleFactor) / 4;

                if (this.originalSize * scaleFactor > 1080)
                {
                    this.Die();
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            this.Sprite.Draw(spriteBatch, this.Position, scale: this.scale, rotation: this.move.Angle);
            spriteBatch.End();
        }

        public void PrimeCharge(TimeSpan time)
        {
            Timer timer = new Timer(time.TotalMilliseconds);
            timer.AutoReset = false;
            timer.Elapsed += (a, e) => {
                this.isPrimed = true;
                this.Sprite = SpriteLoader.LoadSprite("shockwave");
                originalSize = waveSize = (float)(this.Sprite.Texture.Width > this.Sprite.Texture.Height ? Sprite.Texture.Height : Sprite.Texture.Width);
                float r = (float)(this.Sprite.Texture.Width > this.Sprite.Texture.Height ? Sprite.Texture.Height : Sprite.Texture.Width);
                var p = Position;
                this.hitCircle = new HitCircle(p, r / 2);
                SoundManager managerRef = SoundManager.Instance;
                VolumeManager volumeManager = VolumeManager.Instance;
                managerRef.Explosion1.Play(volume: volumeManager.SoundLevel, pitch: 0.0f, pan: 0.0f);
            };
            timer.Start();
        }
    }
}
