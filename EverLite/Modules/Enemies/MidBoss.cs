// <copyright file="MidBoss.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.Enemies
{
    using System;
    using System.Timers;
    using EverLite.Modules.Blaster;
    using EverLite.Modules.Enums;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Mid boss class.
    /// </summary>
    internal class MidBoss : Enemy
    {
        private BossStateEnum currentState = BossStateEnum.Entering;
        private Vector2 Velocity;
        public float lowerBoundryY = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="MidBoss"/> class.
        /// </summary>
        /// <param name="contentManager"> content manager ref.</param>
        /// <param name="blaster"> blaster for enemy.</param>
        public MidBoss(Game game, IBlaster blaster)
            : base(game, blaster) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MidBoss"/> class.
        /// </summary>
        /// <param name="contentManager"> content manager ref.</param>
        /// <param name="newPosition"> new position.</param>
        /// <param name="blaster"> blast for enemy.</param>
        public MidBoss(Vector2 newPosition, Game game, IBlaster blaster)
            : base(newPosition, game, blaster) { }

        /// <inheritdoc/>
        public override string SpriteName { get; set; } = "mid-boss";

        /// <inheritdoc/>
        public override bool IsVisible { get; set; } = true;

        public void ChangeVelocity(Vector2 newVelocity) {
            this.Velocity = newVelocity;
        }

        /// <summary>
        /// Update function to update the enemy.
        /// </summary>
        /// <param name="graphics"> graphics.</param>
        /// <param name="gameTime"> gametime.</param>
        public override void Update(GraphicsDevice graphics, GameTime gameTime)
        {
            switch (this.currentState)
            {
                case BossStateEnum.Idle:
                    break;
                case BossStateEnum.Entering:
                    this.ChangeVelocity(new Vector2(0, 8));
                    this.MoveToTarget();
                    if (this.Position.Y == this.TargetPosition.Y)
                    {
                        this.currentState = BossStateEnum.Idle;
                        Timer timer = new Timer(3000);
                        timer.Elapsed += this.StartMovementPattern1;
                        timer.AutoReset = false;
                        timer.Start();
                        this.ChangeVelocity(new Vector2(0, 0));
                    }

                    break;
                case BossStateEnum.Moving:
                    this.Position += this.Velocity;
                    this.CheckBoundries(graphics);
                    break;
                case BossStateEnum.MovementPattern1:
                    this.MovementPattern1(graphics);
                    break;
                case BossStateEnum.Targetting:
                    this.MoveToTarget();
                    break;
                case BossStateEnum.Leaving:
                    this.Position += this.Velocity;
                    break;
                default:
                    break;
            }

            this.Blaster.Update(gameTime);
        }

        /// <summary>
        /// Starts movement pattern 1.
        /// </summary>
        /// <param name="source">source object.</param>
        /// <param name="e">arguement.</param>
        public virtual void StartMovementPattern1(Object source, System.Timers.ElapsedEventArgs e)
        {
            this.ChangeVelocity(new Vector2(7, 0));
            this.currentState = BossStateEnum.MovementPattern1;
        }

        /// <summary>
        /// Moving pattern 1. Moves side to side.
        /// </summary>
        /// <param name="graphics">graphics device.</param>
        public virtual void MovementPattern1(GraphicsDevice graphics)
        {
            if (this.Position.X < (float) (graphics.Viewport.Width * 0.1))
            {
                this.Velocity.X = Math.Abs(this.Velocity.X);
            }
            else if (this.Position.X + this.enemySprite.Texture.Width > (float)(graphics.Viewport.Width * 0.9))
            {
                this.Velocity.X = -Math.Abs(this.Velocity.X);
            }

            this.Position += this.Velocity;
        }

        /// <summary>
        /// Leaves the map.
        /// </summary>
        public override void LeaveMap()
        {
            this.ChangeVelocity(new Vector2(0, -15));
            this.currentState = BossStateEnum.Leaving;
        }
    }
}
