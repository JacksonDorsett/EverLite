

namespace EverLite.Modules.Managers
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EverLite.Modules.Input;
    using EverLite.Modules.Sprites;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    /// <summary>
    /// Manages the players position.
    /// </summary>
    internal class PlayerMovementManager
    {
        private static readonly float NORMALSPEED = 15.0f;
        private static readonly float SLOWSPEED = 5.0f;
        private Rectangle bounds;
        private Player playerRef;

        public PlayerMovementManager(Player player, Rectangle bounds)
        {
            this.playerRef = player;
            this.bounds = bounds;
            this.playerRef.Position = new Vector2(this.bounds.Width / 2, 3 * this.bounds.Height / 4);
        }

        public void Update(GameTime gameTime)
        {
            this.UpdatePlayerPosition(Keyboard.GetState());
        }

        private void UpdatePlayerPosition(KeyboardState currentKeyboardState)
        {
            // sets the player speed based on the toggle state.
            float sVelocity = this.GetPlayerSpeed();
            Vector2 currentPosition = this.playerRef.Position;

            if (currentKeyboardState.IsKeyDown(Keys.Left) || currentKeyboardState.IsKeyDown(Keys.A))
            {
                currentPosition.X -= sVelocity;
            }

            if (currentKeyboardState.IsKeyDown(Keys.Right) || currentKeyboardState.IsKeyDown(Keys.D))
            {
                currentPosition.X += sVelocity;
            }

            if (currentKeyboardState.IsKeyDown(Keys.Up) || currentKeyboardState.IsKeyDown(Keys.W))
            {
                currentPosition.Y -= sVelocity;
            }

            if (currentKeyboardState.IsKeyDown(Keys.Down) || currentKeyboardState.IsKeyDown(Keys.S))
            {
                currentPosition.Y += sVelocity;
            }

            // Adjust position.
            currentPosition = this.CheckPlayerBoundry(currentPosition);

            this.playerRef.Position = currentPosition;
        }

        private Vector2 CheckPlayerBoundry(Vector2 cPosition)
        {
            if (cPosition.X <= 15)
            {
                cPosition.X = 15;
            }

            if (cPosition.Y <= 0)
            {
                cPosition.Y = 0;
            }

            if (cPosition.X >= this.bounds.Width)
            {
                cPosition.X = this.bounds.Width;
            }

            if (cPosition.Y >= this.bounds.Height)
            {
                cPosition.Y = this.bounds.Height;
            }

            return cPosition;
        }

        private float GetPlayerSpeed()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.G)) return SLOWSPEED;
            return NORMALSPEED;
        }
    }
}
