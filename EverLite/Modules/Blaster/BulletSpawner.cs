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


    public class BulletSpawner : LifetimeEntity
    {
        private SpawnPattern spawnPattern;
        private double lifetime;
        private IMovement movement;
        public BulletSpawner(IMovement movementPattern, double lifetime, SpawnPattern spawnPattern)
            : base(new NoSprite(), movementPattern, lifetime)
        {
            this.spawnPattern = spawnPattern;
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
            return new BulletSpawner(this.movement, this.lifetime, new SpawnPattern())
        }
    }
}
