// <copyright file="Enemy.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.Enemies
{
    using System;
    using EverLite.Modules.Behavior;
    using EverLite.Modules.Blaster;
    using EverLite.Modules.Sprites;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Abstract enemy type.
    /// </summary>
    public class Enemy
    {
        protected SpriteN enemySprite;
        private IBlaster blaster;
        private Lifespan lifespan;

        public IBlaster Blaster
        {
            get
            {
                return this.blaster;
            }
            protected set
            {
                this.blaster = value;
            }
        }

        /// <summary>
        /// Movement associated with the enemy.
        /// </summary>
        public IMovement Movement
        {
            get;
            private set;
        }

        /// <summary>
        /// Reference to the content manager.
        /// </summary>
        public Game mGame { get; private set; }

        /// <summary>
        /// position of an enemy.
        /// </summary>
        public Vector2 Position;

        /// <summary>
        /// Gets or sets sprite name of an enemy.
        /// </summary>
        public string SpriteName { get; set; }

        public Enemy(Vector2 newPosition, Game game, IBlaster blaster, double lifetime = 10)
        {
            this.Position = newPosition;
            this.mGame = game;
            this.enemySprite = new SpriteN(this.mGame.Content.Load<Texture2D>("enemy1"));
            this.blaster = blaster;
            this.lifespan = new Lifespan(lifetime);
        }

        public Enemy(Game game, IBlaster blaster, double lifetime = 10)
        {
            this.mGame = game;
            this.enemySprite = new SpriteN(this.mGame.Content.Load<Texture2D>(this.SpriteName));
            this.blaster = blaster;
            this.lifespan = new Lifespan(lifetime);
        }

        public Enemy(SpriteN sprite, IBlaster blaster, IMovement movement, float lifespan)
        {
            this.Blaster = blaster;
            this.enemySprite = sprite;
            this.Movement = movement;
            this.lifespan = new Lifespan(lifespan);
        }

        public bool IsAlive
        {
            get => this.lifespan.Halflife < 1;
        }

        /// <summary>
        /// Shoot blasters.
        /// </summary>
        /// <returns> blaster shot.</returns>
        public Sprite Shoot()
        {
            return this.blaster.Shoot(this.Position);
        }
        /// <summary>
        /// Update function to update the enemy.
        /// </summary>
        /// <param name="graphics"> graphics.</param>
        /// <param name="gameTime"> gametime.</param>
        public virtual void Update(GraphicsDevice graphics, GameTime gameTime)
        {
            this.lifespan.Update(gameTime);
            this.Position = this.Movement.GetPosition(this.lifespan.Halflife);

            this.blaster.Update(gameTime);
        }

        /// <summary>
        /// Function that sets new position.
        /// </summary>
        /// <param name="newPosition"> new position to set.</param>
        public void ChangePosition(Vector2 newPosition)
        {
            this.Position = newPosition;
        }



        /// <summary>
        /// Function that sets new target position.
        /// </summary>
        /// <param name="targetPosition"> new target position.</param>
        public void ChangeTarget(Vector2 targetPosition)
        {
        }

        

        /// <summary>
        /// Draws an enemy class.
        /// </summary>
        /// <param name="sprite"> spriteBatch.</param>
        public void Draw(SpriteBatch sprite)
        {
            sprite.Begin();
            this.enemySprite.Draw(sprite, this.Position);
            sprite.End();
        }

        /// <summary>
        /// Leave the map.
        /// </summary>
        public void LeaveMap()
        {
            return;
        }
    }

}
