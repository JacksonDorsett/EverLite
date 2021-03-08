// <copyright file="Controller.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.Behavior
{
    using EverLite.Modules.Blaster;
    using EverLite.Modules.Sprites;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    /// <summary>
    /// The Controller class manages the user controls for gameplay.
    /// </summary>
    public class Controller
    {
        private static readonly float NORMALSPEED = 15.0f;
        private static readonly float SLOWSPEED = 5.0f;
        private IBlaster blaster;
        private int screenWidth;
        private int screenHeight;
        private Game game;
        private Player player;

        /// <summary>
        /// Initializes a new instance of the <see cref="Controller"/> class.
        /// </summary>
        /// <param name="g">game reference.</param>
        /// <param name="p">player object.</param>
        public Controller(Game g, Player p)
        {
            this.player = p;
            this.game = g;
            this.blaster = new PlayerBlaster(g.Content.Load<Texture2D>("TinyBlue"));
            this.SetGameBoundary();
        }

        /// <summary>
        /// Updates dynamic control inputs.
        /// </summary>
        /// <param name="gameTime">SpriteBatch source.</param>
        public void Update(GameTime gameTime)
        {
            GamePadState currentGamePadState = GamePad.GetState(PlayerIndex.One);

            KeyboardState currentKeyboardState = Keyboard.GetState();

            this.UpdatePlayerPositionGamePad(currentGamePadState);
            this.UpdatePlayerPosition(currentKeyboardState);
            this.blaster.Update(gameTime);
        }

        /// <summary>
        /// Makes the player shoot.
        /// </summary>
        /// <returns>Returns the blaster location for shooting bullets PEW PEW.</returns>
        public Sprite ShootLocation()
        {
            return this.blaster.Shoot(this.player.Position);
        }

        /// <summary>
        /// Can the player shoot.
        /// </summary>
        /// <returns>T/F if player is shooting.</returns>
        public bool CanShoot()
        {
            return GamePad.GetState(PlayerIndex.One).Triggers.Right != 0.0f || Keyboard.GetState().IsKeyDown(Keys.J) || Keyboard.GetState().IsKeyDown(Keys.LeftControl);
        }

        /// <summary>
        /// Keyboard controls.
        /// </summary>
        /// <param name="currentKeyboardState">keyboard state.</param>
        private void UpdatePlayerPosition(KeyboardState currentKeyboardState)
        {
            // sets the player speed based on the toggle state.
            this.player.SetsVelocity(this.player.GetPlayerSpeed());

            if (currentKeyboardState.IsKeyDown(Keys.Left) || currentKeyboardState.IsKeyDown(Keys.A))
            {
                this.player.Position.X -= this.player.GetsVelocity();
            }

            if (currentKeyboardState.IsKeyDown(Keys.Right) || currentKeyboardState.IsKeyDown(Keys.D))
            {
                this.player.Position.X += this.player.GetsVelocity();
            }

            if (currentKeyboardState.IsKeyDown(Keys.Up) || currentKeyboardState.IsKeyDown(Keys.W))
            {
                this.player.Position.Y -= this.player.GetsVelocity();
            }

            if (currentKeyboardState.IsKeyDown(Keys.Down) || currentKeyboardState.IsKeyDown(Keys.S))
            {
                this.player.Position.Y += this.player.GetsVelocity();
            }

            this.CheckPlayerBoundry();
        }

        /// <summary>
        /// Gamepad control.
        /// </summary>
        /// <param name="currentGamePadState">gamepad state.</param>
        private void UpdatePlayerPositionGamePad(GamePadState currentGamePadState)
        {
            if (currentGamePadState.Buttons.Y == ButtonState.Pressed)
            {
                this.player.SetsVelocity(SLOWSPEED);
            }

            if (currentGamePadState.Buttons.Y == ButtonState.Released)
            {
                this.player.SetsVelocity(NORMALSPEED);
            }

            this.player.Position.X += currentGamePadState.ThumbSticks.Left.X * this.player.GetsVelocity();

            this.player.Position.Y -= currentGamePadState.ThumbSticks.Left.Y * this.player.GetsVelocity();
        }

        /// <summary>
        /// Sets the boundary of where the player can move.
        /// </summary>
        private void SetGameBoundary()
        {
            var rect = this.game.Window.ClientBounds;
            this.screenWidth = rect.Width;
            this.screenHeight = rect.Height;
        }

        /// <summary>
        /// Keeps the player forever trapped withen the display.
        /// </summary>
        private void CheckPlayerBoundry()
        {
            if (this.player.Position.X <= 15)
            {
                this.player.Position.X = 15;
            }

            if (this.player.Position.Y <= 45)
            {
                this.player.Position.Y = 45;
            }

            if (this.player.Position.X + this.player.Texture.Width >= this.screenWidth)
            {
                this.player.Position.X = this.screenWidth - this.player.Texture.Width;
            }

            if (this.player.Position.Y + this.player.Texture.Height >= this.screenHeight)
            {
                this.player.Position.Y = this.screenHeight - this.player.Texture.Height;
            }
        }
    }
}
