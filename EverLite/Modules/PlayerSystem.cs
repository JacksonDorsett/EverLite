// <copyright file="PlayerSystem.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules
{
    using System.Collections.Generic;
    using EverLite.Modules.Behavior;
    using EverLite.Modules.Sprites;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    /// <summary>
    /// PlayerSystem manages the player actions, including the bullets created by shooting.
    /// </summary>
    internal class PlayerSystem
    {
        private Player player;
        private List<Sprite> bullets = new List<Sprite>();
        private Game mGame;
        private Controller controller;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerSystem"/> class.
        /// </summary>
        /// <param name="game">game Reference object.</param>
        public PlayerSystem(Game game)
        {
            this.mGame = game;
            this.player = new Player(game);
            this.controller = new Controller(game, this.player);
        }

        /// <summary>
        /// Gets the player object.
        /// Note: This Method needs refactoring.
        /// </summary>
        public Player Player
        {
            get
            {
                return this.player;
            }
        }

        /// <summary>
        /// Calls on the player and bullet updates.
        /// </summary>
        /// <param name="gameTime">GameTime.</param>
        public void Update(GameTime gameTime)
        {
            this.controller.Update(gameTime);

            var bullet = this.controller.ShootLocation();

            if (this.controller.CanShoot() && bullet != null)
            {
                this.bullets.Add(bullet);
            }

            this.UpdateBullets();
        }

        /// <summary>
        /// Draws shapes in the game.
        /// </summary>
        /// <param name="sprite">SpriteBatch.</param>
        public void Draw(SpriteBatch sprite)
        {
            sprite.Begin();
            this.player.Draw(sprite);
            foreach (Sprite bullet in this.bullets)
            {
                bullet.Draw(sprite);
            }

            sprite.End();
        }

        /// <summary>
        /// Maintains the bullets visibility.
        /// </summary>
        private void UpdateBullets()
        {
            foreach (Sprite bullet in this.bullets)
            {
                bullet.Position += bullet.Velocity;
                if (Vector2.Distance(bullet.GetPosition(), this.player.GetPosition()) > 2000)
                {
                    bullet.SetIsVisible(false);
                }
            }

            for (int index = 0; index < this.bullets.Count; index++)
            {
                if (!this.bullets[index].GetIsVisible())
                {
                    this.bullets.RemoveAt(index);
                    index--;
                }
            }
        }
    }
}
