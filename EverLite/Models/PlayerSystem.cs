// <copyright file="PlayerSystem.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Models
{
    using System.Collections.Generic;
    using EverLite.Models.Enums;
    using EverLite.Models.Sprites;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    /// <summary>
    /// PlayerSystem manages the player actions, including the bullets created by shooting.
    /// </summary>
    internal class PlayerSystem
    {
        /// <summary>
        /// Content manager ref.
        /// </summary>
        private ContentManager contentManagerRef;

        /// <summary>
        /// Reference to the graphics device.
        /// </summary>
        private GraphicsDevice graphicsDeviceRef;

        private Player player;
        private List<Sprite> bullets = new List<Sprite>();
        private Game1 mGame;

        /*
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerSystem"/> class.
        /// </summary>
        /// <param name="contentManager">ContentManager.</param>
        /// <param name="graphicsDevice">GraphicsDevice.</param>
        public PlayerSystem(ContentManager contentManager, GraphicsDevice graphicsDevice)
        {
            this.contentManagerRef = contentManager;
            this.graphicsDeviceRef = graphicsDevice;
            this.player = SpriteFactory.CreateSprite(FactoryEnum.Player);
            Vector2 playerPosition = new Vector2(this.graphicsDeviceRef.Viewport.TitleSafeArea.X + (this.graphicsDeviceRef.Viewport.TitleSafeArea.Width / 2), this.graphicsDeviceRef.Viewport.TitleSafeArea.Y + (this.graphicsDeviceRef.Viewport.TitleSafeArea.Height * 4 / 5));
            this.player.Initialize(this.contentManagerRef.Load<Texture2D>(EnumToStringFactory.GetEnumToString(this.player.GetSpriteType())), playerPosition);
            this.player.SetGameBoundary(this.graphicsDeviceRef.Viewport.Width, this.graphicsDeviceRef.Viewport.Height);
        }
        */
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerSystem"/> class.
        /// </summary>
        /// <param name="game">game Reference object.</param>
        public PlayerSystem(Game1 game)
        {
            this.mGame = game;
            this.player = new Player(game);
        }

        /// <summary>
        /// Calls on the player and bullet updates.
        /// </summary>
        /// <param name="graphics">GraphicsDevice.</param>
        /// <param name="gameTime">GameTime.</param>
        public void Update(GraphicsDevice graphics, GameTime gameTime)
        {
            this.player.Update(gameTime);

            if (GamePad.GetState(PlayerIndex.One).Triggers.Right != 0.0f || Keyboard.GetState().IsKeyDown(Keys.J))
            {
                this.PlayerShoot();
            }

            this.UpdateBullets();
        }

        /// <summary>
        /// As the label implies. Player adds a bullet to the list for shooting.
        /// </summary>
        public void PlayerShoot()
        {
            if (this.bullets.Count < 100)
            {
                this.bullets.Add(this.player.Shoot(this.contentManagerRef.Load<Texture2D>(this.player.GetCurrentBulletType()), new Vector2(this.player.GetPosition().X, this.player.GetPosition().Y)));
            }
        }

        /// <summary>
        /// Maintains the bullets visibility.
        /// </summary>
        public void UpdateBullets()
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
    }
}
