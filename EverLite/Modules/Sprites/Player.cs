// <copyright file="Player.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.Sprites
{
    using System;
    using System.Collections.Generic;
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
        private static Dictionary<Game, Player> sPlayerRef;

        // constants
        private static readonly float NORMALSPEED = 15.0f;
        private static readonly float SLOWSPEED = 5.0f;
        private readonly float scale = 0.5f;
        private readonly float layerDepth = 0.0f;
        private int screenWidth;
        private int screenHeight;
        private Vector2 mPosition;
        private Game mGame;
        private ToggleStatus slowSpeedStatus;
        private IBlaster blaster;
        private SpriteN playerSprite;
        private PlayerShoot shooter;
        static Player()
        {
            sPlayerRef = new Dictionary<Game, Player>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// Sets isActive, angle, velocity, and spriteType fields.
        /// </summary>
        /// <param name="newBulletTexture">The picture of the bullet object.</param>
        public Player()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        /// <param name="game">game reference object.</param>
        public Player(Game game)
            //: base(0, NORMALSPEED, game.Content.Load<Texture2D>(EnumToStringFactory.GetEnumToString(FactoryEnum.Player)), Vector2.Zero)
        {
            this.mGame = game;
            this.SetGameBoundary();
            this.mPosition = new Vector2(screenWidth / 2, 3 * screenHeight / 4);
            this.playerSprite = new SpriteN(game.Content.Load<Texture2D>(EnumToStringFactory.GetEnumToString(FactoryEnum.Player)));
            // initialize components
            // this.blaster = new PlayerBlaster(game.Content.Load<Texture2D>("TinyBlue"));
            this.slowSpeedStatus = new ToggleStatus(Keys.G);
            this.shooter = new PlayerShoot(SpriteLoader.LoadSprite("TinyBlue"));
        }

        /// <summary>
        /// Shoots a bullet from blaster and returns the bullet object.
        /// </summary>
        /// <returns>returns the bullet that was shot.</returns>
        public Sprite Shoot()
        {
            return null;
            return this.blaster.Shoot(this.mPosition);
        }

        /// <inheritdoc/>
        public void Update(GameTime gameTime)
        {
            //this.blaster.Update(gameTime);
            if (Keyboard.GetState().IsKeyDown(Keys.F))
            {
                this.shooter.Shoot(this.mPosition);
            }
            GamePadState currentGamePadState = GamePad.GetState(PlayerIndex.One);

            KeyboardState currentKeyboardState = Keyboard.GetState();

            this.UpdatePlayerPositionGamePad(currentGamePadState);
            this.UpdatePlayerPosition(currentKeyboardState);
        }

        public Vector2 GetPosition()
        {
            return this.mPosition;
        }

        /// <summary>
        /// Draws the Player.
        /// </summary>
        /// <param name="spriteBatch">sprite batch being drawn to.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 origin;

            this.playerSprite.Draw(spriteBatch, this.mPosition,.5f);
        }

        /// <summary>
        /// Gets instance of player for game object.
        /// </summary>
        /// <param name="game">game object.</param>
        /// <returns>returns player associated with the game.</returns>
        public static Player Instance(Game game)
        {
            if (!sPlayerRef.ContainsKey(game))
            {
                sPlayerRef[game] = new Player(game);
            }

            return sPlayerRef[game];
        }

        private void UpdatePlayerPositionGamePad(GamePadState currentGamePadState)
        {
            float speed = NORMALSPEED;
            if (currentGamePadState.Buttons.Y == ButtonState.Pressed)
            {
                speed = SLOWSPEED;
            }

            this.mPosition.X += currentGamePadState.ThumbSticks.Left.X * speed;

            this.mPosition.Y -= currentGamePadState.ThumbSticks.Left.Y * speed;
        }

        private void UpdatePlayerPosition(KeyboardState currentKeyboardState)
        {
            // sets the player speed based on the toggle state.
            float sVelocity = this.GetPlayerSpeed();

            if (currentKeyboardState.IsKeyDown(Keys.Left) || currentKeyboardState.IsKeyDown(Keys.A))
            {
                this.mPosition.X -= sVelocity;
            }

            if (currentKeyboardState.IsKeyDown(Keys.Right) || currentKeyboardState.IsKeyDown(Keys.D))
            {
                this.mPosition.X += sVelocity;
            }

            if (currentKeyboardState.IsKeyDown(Keys.Up) || currentKeyboardState.IsKeyDown(Keys.W))
            {
                this.mPosition.Y -= sVelocity;
            }

            if (currentKeyboardState.IsKeyDown(Keys.Down) || currentKeyboardState.IsKeyDown(Keys.S))
            {
                this.mPosition.Y += sVelocity;
            }

            this.CheckPlayerBoundry();
        }

        private void SetGameBoundary()
        {
            var rect = this.mGame.Window.ClientBounds;
            this.screenWidth = rect.Width;
            this.screenHeight = rect.Height;
        }

        private float GetPlayerSpeed()
        {
            this.slowSpeedStatus.Update();
            if (!this.slowSpeedStatus.Status)
            {
                return NORMALSPEED;
            }
            else
            {
                return SLOWSPEED;
            }
        }

        private void CheckPlayerBoundry()
        {
            if (this.mPosition.X <= 15)
            {
                this.mPosition.X = 15;
            }

            if (this.mPosition.Y <= 0)
            {
                this.mPosition.Y = 0;
            }

            if (this.mPosition.X >= this.screenWidth)
            {
                this.mPosition.X = this.screenWidth;
            }

            if (this.mPosition.Y >= this.screenHeight)
            {
                this.mPosition.Y = this.screenHeight;
            }
        }
    }
}
