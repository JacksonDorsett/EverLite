// <copyright file="PlayerSystem.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules
{
    using System.Collections.Generic;
    using EverLite.Modules.Behavior;
    using EverLite.Modules.Enums;
    using EverLite.Modules.GameState;
    using EverLite.Modules.Managers;
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
        private Game mGame;
        private PlayerMovementManager movementManager;
        Rectangle border;
        Rectangle board;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerSystem"/> class.
        /// </summary>
        /// <param name="game">game Reference object.</param>
        public PlayerSystem(Game game)
        {
            this.mGame = game;
            this.player = Player.Instance();
            this.movementManager = new PlayerMovementManager(this.player, game.Window.ClientBounds);
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
            this.player.Update(gameTime);
            this.movementManager.Update(gameTime);
        }

        /// <summary>
        /// Maintains the bullets visibility.
        /// </summary>

        /// <summary>
        /// Draws shapes in the game.
        /// </summary>
        /// <param name="sprite">SpriteBatch.</param>
        public void Draw(SpriteBatch sprite)
        {
            sprite.Begin();
            this.player.Draw(sprite);
            sprite.End();

        }
    }
}
