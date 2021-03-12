// <copyright file="Enemy.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.Enemies
{
    using System;
    using EverLite.Modules.Blaster;
    using EverLite.Modules.Sprites;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Abstract enemy type.
    /// </summary>
    public abstract class Enemy
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
        /// Reference to the content manager.
        /// </summary>
        public Game mGame { get; private set; }

        /// <summary>
        /// position of an enemy.
        /// </summary>
        public Vector2 Position;

        /// <summary>
        /// velocity of an enemy.
        /// </summary>
        //public Vector2 Velocity = new Vector2(0, 0);

        /// <summary>
        /// Target position for the enemy to reach.
        /// </summary>
        public Vector2 TargetPosition;

        /// <summary>
        /// Gets or sets sprite name of an enemy.
        /// </summary>
        public abstract string SpriteName { get; set; }

        /// <summary>
        /// Gets or sets visibility of an enemy.
        /// </summary>
        public abstract bool IsVisible { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether enemy is targeting.
        /// </summary>
        public bool IsTargetting { get; set; }


        public Enemy(Vector2 newPosition, Game game, IBlaster blaster, double lifetime = 10)
        {
            this.Position = newPosition;
            this.mGame = game;
            this.enemySprite = new SpriteN(this.mGame.Content.Load<Texture2D>(this.SpriteName));
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
            this.blaster.Update(gameTime);
            if (this.IsTargetting)
            {

            }
            else
            {
                //this.Position += this.Velocity;
            }

            //this.CheckBoundries(graphics);
        }

        /// <summary>
        /// Checks if we crossed the boundries.
        /// </summary>
        /// <param name="graphics"> graphics device.</param>
        

        /// <summary>
        /// Function that sets new velocity.
        /// </summary>
        /// <param name="newVelocity"> new velocity to set.</param>
        public void ChangeVelocity(Vector2 newVelocity)
        {
            //this.Velocity = newVelocity;
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
            this.TargetPosition = targetPosition;
            this.IsTargetting = true;
        }

        /// <summary>
        /// Function that starts targetting.
        /// </summary>
        public void StartTargetting()
        {
            this.IsTargetting = true;
        }

        /// <summary>
        /// Function that stops targetting.
        /// </summary>
        public void StopTargetting()
        {
            this.IsTargetting = false;
        }

        /// <summary>
        /// Draws an enemy class.
        /// </summary>
        /// <param name="sprite"> spriteBatch.</param>
        public void Draw(SpriteBatch sprite)
        {
            sprite.Begin();
            this.enemySprite.Draw(sprite, Position);
            
            sprite.End();
        }

        /// <summary>
        /// Leave the map.
        /// </summary>
        public virtual void LeaveMap()
        {
            return;
        }
    }

}
