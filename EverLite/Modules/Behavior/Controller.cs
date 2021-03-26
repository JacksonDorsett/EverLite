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
    using System;

    /// <summary>
    /// The Controller class manages the user controls for gameplay.
    /// </summary>
    public class Controller : ButtonControls
    {
        private static Controller instance;
        private int screenWidth;
        private int screenHeight;
        private Game game;
        private Player player;
        //private Vector2 position;
        public Vector2 Position
        {
            get { return this.player.Position; }
            set { this.player.Position = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Controller"/> class.
        /// </summary>
        /// <param name="g">game reference.</param>
        /// <param name="p">player object.</param>
        public Controller(Game g, Player p)
        {
            this.player = p;
            this.game = g;
            this.SetGameBoundary();
        }
        
        public Controller(Game g)
        {
            this.game = g;
            this.SetGameBoundary();
            Player.Initialize(g);
        }

        /// <summary>
        /// Updates dynamic control inputs.
        /// </summary>
        /// <param name="gameTime">SpriteBatch source.</param>
        public void Update(GameTime gameTime)
        {
            GamePadState gamePad = GamePad.GetState(PlayerIndex.One);
            KeyboardState keyBoard = Keyboard.GetState();

            this.UpdatePlayerPositionGamePad(gamePad);
            this.UpdatePlayerPosition(keyBoard);
        }
        
        public static Controller Instance()
        {
            if (instance == null)
                throw new Exception("Controller not initialized.");

            return instance;
        }

        /*
        /// <summary>
        /// Makes the player shoot.
        /// </summary>
        /// <returns>Returns the blaster location for shooting bullets PEW PEW.</returns>
        public Sprite ShootLocation()
        {
            return this.blaster.Shoot(this.player.Position);
        }*/
        public static void Initialize(Game game)
        {
            if (instance != null)
                throw new Exception("Controller already initialized.");
            instance = new Controller(game);
        }

        /// <summary>
        /// Can the player shoot.
        /// </summary>
        /// <returns>T/F if player is shooting.</returns>
        public bool CanShoot()
        {
            return GamePad.GetState(PlayerIndex.One).Triggers.Right != 0.0f || Keyboard.GetState().IsKeyDown(this.player.Shoot);
        }

        /// <summary>
        /// Keyboard controls.
        /// </summary>
        /// <param name="currentKeyboardState">keyboard state.</param>
        private void UpdatePlayerPosition(KeyboardState keyBoard)
        {
            // sets the player speed based on the toggle state.
            //this.player.SetsVelocity(this.player.GetPlayerSpeed());
            //this.player.Speed = this.player.GetPlayerSpeed();

            if (keyBoard.IsKeyDown(this.MoveLeft))
            {
                //this.player.Position.X -= this.player.GetsVelocity();
                this.player.Position = new Vector2(this.player.Position.X - this.player.Speed, this.player.Position.Y);
            }

            if (keyBoard.IsKeyDown(this.MoveRight))
            {
                //this.player.Position.X += this.player.GetsVelocity();
                this.player.Position = new Vector2(this.player.Position.X + this.player.Speed, this.player.Position.Y);
            }

            if (keyBoard.IsKeyDown(this.MoveUp))
            {
                //this.player.Position.Y -= this.player.GetsVelocity();
                this.player.Position = new Vector2(this.player.Position.X, this.player.Position.Y - this.player.Speed);
            }

            if (keyBoard.IsKeyDown(this.MoveDown))
            {
                //this.player.Position.Y += this.player.GetsVelocity();
                this.player.Position = new Vector2(this.player.Position.X, this.player.Position.Y + this.player.Speed);
            }

            //this.CheckPlayerBoundry();
        }

        /// <summary>
        /// Gamepad control.
        /// </summary>
        /// <param name="currentGamePadState">gamepad state.</param>
        private void UpdatePlayerPositionGamePad(GamePadState gamePad)
        {
            if (gamePad.IsButtonDown(this.PadPause))
            {
                this.game.Exit();
            }

            if (gamePad.IsButtonDown(this.PadSlowSpeed))
            {
                //this.player.SetsVelocity(SLOWSPEED);
                this.player.ChangeSpeed("slow");
            }

            if (gamePad.IsButtonUp(this.PadSlowSpeed))
            {
                //this.player.SetsVelocity(NORMALSPEED);
                this.player.ChangeSpeed("normal");
            }

            //this.player.Position.X += gamePad.ThumbSticks.Left.X * this.player.GetsVelocity();

            //this.player.Position.Y -= gamePad.ThumbSticks.Left.Y * this.player.GetsVelocity();

            this.player.Position += new Vector2(gamePad.ThumbSticks.Left.X * this.player.Speed, this.player.Position.Y);

            this.player.Position -= new Vector2(this.player.Position.X, gamePad.ThumbSticks.Left.Y * this.player.Speed);
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

        public void Draw(SpriteBatch spriteBatch)
        {
            //Vector2 origin;

            //this.playerSprite.Draw(spriteBatch, this.mPosition, .5f);
            this.player.playerSprite.Draw(spriteBatch, this.player.Position, this.player.SCALE);
        }

        /// <summary>
        /// Keeps the player forever trapped withen the display.
        /// </summary>
        private void CheckPlayerBoundry()
        {
            if (this.player.Position.X <= 15)
            {
                //this.player.Position.X = 15;
                this.player.Position = new Vector2(15, this.player.Position.Y);
            }

            if (this.player.Position.Y <= 45)
            {
                //this.player.Position.Y = 45;
                this.player.Position = new Vector2(this.player.Position.X, 15);
            }

            if (this.player.Position.X + this.player.playerSprite.Texture.Height >= this.screenWidth)
            {
                //this.player.Position.X = this.screenWidth - this.player.Texture.Width;
                this.player.Position = new Vector2(this.screenWidth - this.player.playerSprite.Texture.Width, this.player.Position.Y);
            }

            if (this.player.Position.Y + this.player.playerSprite.Texture.Height >= this.screenHeight)
            {
                //this.player.Position.Y = this.screenHeight - this.player.Texture.Height;
                this.player.Position = new Vector2(this.player.Position.X, this.screenHeight - this.player.playerSprite.Texture.Height);
            }
        }
    }

}
