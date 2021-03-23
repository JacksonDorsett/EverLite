// <copyright file="BulletSpawner.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.Blaster
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EverLite.Modules.Behavior;
    using EverLite.Modules.Enemies;
    using EverLite.Modules.Sprites;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;


    internal class BulletSpawner : LifetimeEntity
    {
        readonly List<Bullet> bulletList;
        private int numBullets;
        private float speed;
        private SpriteN bulletSprite;
        public BulletSpawner(SpriteN bulletSprite, IMovement movementPattern, List<Bullet> bulletList, int numBullets, float speed, double lifetime)
            : base(new NoSprite(), movementPattern, lifetime)
        {
            this.bulletList = bulletList;
            this.speed = speed;
            this.numBullets = numBullets;
            this.bulletSprite = bulletSprite;
        }

        protected List<Bullet> BulletList { get => this.bulletList; }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            
        }
    }
}
