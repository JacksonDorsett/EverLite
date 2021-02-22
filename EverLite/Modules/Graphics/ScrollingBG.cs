// <copyright file="ScrollingBG.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.Graphics
{
    using EverLite;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Represents a scrolling background.
    /// </summary>
    public class ScrollingBG
    {
        private static readonly int SPEED = 250;
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
            texture = this.game.Content.Load<Texture2D>("road");
            r1 = texture.Bounds;
            r2 = r1;
            r1.Y = -r1.Height;
            currentState = ScrollState.Start;
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
            game.SpriteBatch.Begin();
            game.SpriteBatch.Draw(texture, r1, Color.White);
            game.SpriteBatch.Draw(texture, r2, Color.White);
            game.SpriteBatch.End();
        }

        /// <summary>
        /// updates the background every frame.
        /// </summary>
        /// <param name="gameTime">Game time passed during game cycle.</param>
        public void Update(GameTime gameTime)
        {
            if (currentState == ScrollState.Start)
            {
                if (r1.Top > r1.Height)
                {
                    r1.Y = r2.Top - r1.Height;
                }

                if (r2.Top > r1.Height)
                {
                    r2.Y = r1.Top - r1.Height;
                }

                r1.Y += (int)(SPEED * gameTime.ElapsedGameTime.TotalSeconds);
                r2.Y += (int)(SPEED * gameTime.ElapsedGameTime.TotalSeconds);
            }
        }

        /// <summary>
        /// Starts the scrolling.
        /// </summary>
        public void Start()
        {
            currentState = ScrollState.Start;
        }

        /// <summary>
        /// Stops scrolling.
        /// </summary>
        public void Stop()
        {
            currentState = ScrollState.Stop;
        }

        private Rectangle GetWindowSize()
        {
            Rectangle r = game.Window.ClientBounds;
            r.X = 0;
            r.Y = 0;
            return r;
        }
    }
}
