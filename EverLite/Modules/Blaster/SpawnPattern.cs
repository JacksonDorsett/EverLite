// <copyright file="SpawnPattern.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.Blaster
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EverLite.Modules.Sprites;
    using EverLite.Utilities;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class SpawnPattern
    {
        private readonly SpriteN bulletSprite;
        private int numSpawned;
        private readonly int totalBullets;
        private double spawnRate;
        protected List<Bullet> bulletList;
        private double timeElapsed;
        private double speed;
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
        }

        public bool IsEnabled { get; set; }

        public abstract void Spawn(Vector2 spawnPosition);

        protected SpriteN Sprite { get => this.bulletSprite; }
        protected double Speed { get => this.speed; }
        protected double SpawnRate { get => spawnRate;}

        protected int TotalBullets => totalBullets;

        public virtual void Update(GameTime gameTime, Vector2 position)
        {
            if (this.IsEnabled)
            {
                this.timeElapsed += gameTime.ElapsedGameTime.TotalSeconds;

                if (this.timeElapsed > this.SpawnRate)
                {
                    this.timeElapsed -= this.SpawnRate;
                    this.Spawn(position);
                    this.numSpawned++;

                    if (this.numSpawned >= this.TotalBullets)
                    {
                        this.IsEnabled = false;
                    }
                }
            }
        }

        public abstract SpawnPattern Clone();
    }
}
