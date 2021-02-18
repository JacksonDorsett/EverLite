// <copyright file="ScrollingBG.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Represents a scrolling background.
    /// </summary>
    public class ScrollingBG
    {
        private static readonly int SPEED = 350;
        private Game1 game;
        private Rectangle r1;
        private Rectangle r2;
        private Texture2D texture;
        private ScrollState currentState;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScrollingBG"/> class.
        /// </summary>
        /// <param name="game">game object reference.</param>
        public ScrollingBG(Game1 game)
        {
            this.game = game;
            this.texture = this.game.Content.Load<Texture2D>("road");
            this.r1 = this.texture.Bounds;
            this.r2 = this.r1;
            this.r1.Y = this.r1.Height;
            this.currentState = ScrollState.Start;
        }

        private enum ScrollState
        {
            Stop,
            Start,
        }

        /// <summary>
        /// Called to draw the background.
        /// </summary>
        /// <param name="gameTime">Game time passed during game cycle.</param>
        public void Draw(GameTime gameTime)
        {
            this.game.SpriteBatch.Draw(this.texture, this.r1, Color.White);
            this.game.SpriteBatch.Draw(this.texture, this.r2, Color.White);
        }

        /// <summary>
        /// updates the background every frame.
        /// </summary>
        /// <param name="gameTime">Game time passed during game cycle.</param>
        public void Update(GameTime gameTime)
        {
            if (this.currentState == ScrollState.Start)
            {
                if (this.r1.Bottom < 0)
                {
                    this.r1.Y = this.r2.Bottom;
                }

                if (this.r2.Bottom < 0)
                {
                    this.r2.Y = this.r1.Bottom;
                }

                this.r1.Y -= (int)(SPEED * gameTime.ElapsedGameTime.TotalSeconds);
                this.r2.Y -= (int)(SPEED * gameTime.ElapsedGameTime.TotalSeconds);
            }
        }

        /// <summary>
        /// Starts the scrolling.
        /// </summary>
        public void Start()
        {
            this.currentState = ScrollState.Start;
        }

        /// <summary>
        /// Stops scrolling.
        /// </summary>
        public void Stop()
        {
            this.currentState = ScrollState.Stop;
        }

        private Rectangle GetWindowSize()
        {
            Rectangle r = this.game.Window.ClientBounds;
            r.X = 0;
            r.Y = 0;
            return r;
        }
    }
}
