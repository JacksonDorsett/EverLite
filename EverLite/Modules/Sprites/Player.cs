﻿// <copyright file="Player.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.Sprites
{
    using System;
    using System.Collections.Generic;
    using EverLite.Modules.Behavior;
    using EverLite.Modules.Blaster;
    using EverLite.Modules.Enums;
    using EverLite.Modules.Input;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;


    /// <summary>
    /// The Player class created will handle the special stuff the player can do.
    /// </summary>
    public class Player
    {
        // instance

        private static Player mInstance;
        // constants
        private Vector2 mPosition;
        private Game mGame;
        private SpriteN playerSprite;
        private PlayerShoot shooter;

        public Vector2 Position { get => mPosition; set => mPosition = value; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        /// <param name="game">game reference object.</param>
        public Player()
        {
            this.playerSprite = SpriteLoader.LoadSprite(EnumToStringFactory.GetEnumToString(FactoryEnum.Player));
            this.shooter = new PlayerShoot(SpriteLoader.LoadSprite("TinyBlue"));
        }

        /// <inheritdoc/>
        public void Update(GameTime gameTime)
        {

            KeyboardState currentKeyboardState = Keyboard.GetState();

            if (currentKeyboardState.IsKeyDown(Keys.J))
            {
                this.shooter.Shoot(this.Position);
            }
        }

        /// <summary>
        /// Draws the Player.
        /// </summary>
        /// <param name="spriteBatch">sprite batch being drawn to.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 origin;

            this.playerSprite.Draw(spriteBatch, this.mPosition, .5f);
        }

        /// <summary>
        /// Gets instance of player for game object.
        /// </summary>
        /// <param name="game">game object.</param>
        /// <returns>returns player associated with the game.</returns>
        public static Player Instance()
        {
            if (mInstance == null) mInstance = new Player();
            return mInstance;
        }
    }
}
