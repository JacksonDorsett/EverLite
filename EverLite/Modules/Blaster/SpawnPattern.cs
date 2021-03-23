using EverLite.Modules.Sprites;
using EverLite.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

using System.Text;

namespace EverLite.Modules.Blaster
{
    abstract class SpawnPattern
    {
        readonly SpriteN bulletSprite;
        int numSpawned;
        int totalBullets;
        double spawnRate;
        protected List<Bullet> bulletList;
        double timeElapsed;
        public SpawnPattern(List<Bullet> bullets, SpriteN bulletSprite, int spawnRate, int totalBullets)
        {
            this.bulletList = bullets;
            this.bulletSprite = bulletSprite;
            this.totalBullets = totalBullets;
            this.spawnRate = spawnRate;
            this.numSpawned = 0;
            this.IsEnabled = false;
            this.timeElapsed = 0;
        }

        public bool IsEnabled { get; set; }
        public abstract void Spawn(Vector2 spawnPosition);

        public void Update(GameTime gameTime, Vector2 position)
        {
            if (this.IsEnabled)
            {
                this.timeElapsed += gameTime.ElapsedGameTime.TotalMilliseconds;

                if (this.timeElapsed > this.spawnRate)
                {
                    this.timeElapsed -= this.spawnRate;
                    this.Spawn(position);
                    this.numSpawned++;

                    if (this.numSpawned >= this.totalBullets)
                    {
                        this.IsEnabled = false;
                    }
                }
            }
        }
    }
}
