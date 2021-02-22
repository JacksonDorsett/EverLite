// <copyright file="PlayerSystem.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules
{
    using System.Collections.Generic;
    using EverLite.Modules.Enums;
    using EverLite.Modules.Sprites;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
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

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerSystem"/> class.
        /// </summary>
        /// <param name="game">game Reference object.</param>
        public PlayerSystem(Game game)
        {
            this.mGame = game;
            this.player = new Player(game);
        }

        /// <summary>
        /// Calls on the player and bullet updates.
        /// </summary>
        /// <param name="gameTime">GameTime.</param>
        public void Update(GameTime gameTime)
        {
            this.player.Update(gameTime);

            if (GamePad.GetState(PlayerIndex.One).Triggers.Right != 0.0f || Keyboard.GetState().IsKeyDown(Keys.J))
            {
                PlayerShoot();
            }

            UpdateBullets();
        }

        /// <summary>
        /// As the label implies. Player adds a bullet to the list for shooting.
        /// </summary>
        public void PlayerShoot()
        {
            if (bullets.Count < 100)
            {
                bullets.Add(player.Shoot(mGame.Content.Load<Texture2D>(player.GetCurrentBulletType()), new Vector2(player.GetPosition().X, player.GetPosition().Y)));
            }
        }

        /// <summary>
        /// Maintains the bullets visibility.
        /// </summary>
        public void UpdateBullets()
        {
            foreach (Sprite bullet in bullets)
            {
                bullet.Position += bullet.Velocity;
                if (Vector2.Distance(bullet.GetPosition(), player.GetPosition()) > 2000)
                {
                    bullet.SetIsVisible(false);
                }
            }

            for (int index = 0; index < bullets.Count; index++)
            {
                if (!bullets[index].GetIsVisible())
                {
                    bullets.RemoveAt(index);
                    index--;
                }
            }
        }

        /// <summary>
        /// Draws shapes in the game.
        /// </summary>
        /// <param name="sprite">SpriteBatch.</param>
        public void Draw(SpriteBatch sprite)
        {
            sprite.Begin();
            player.Draw(sprite);
            foreach (Sprite bullet in bullets)
            {
                bullet.Draw(sprite);
            }
            sprite.End();

        }
    }
}
