

namespace EverLite.Modules.Managers
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EverLite.Modules.Input;
    using EverLite.Modules.Sprites;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    class PlayerMovementManager
    {
        private static readonly float NORMALSPEED = 15.0f;
        private static readonly float SLOWSPEED = 5.0f;
        private int screenWidth;
        private int screenHeight;
        private Player playerRef;

        public PlayerMovementManager(Player player, Rectangle bounds)
        {
            this.playerRef = player;
            this.screenWidth = bounds.Width;
            this.screenHeight = bounds.Height;
            playerRef.Position = new Vector2(screenWidth / 2, 3 * screenHeight / 4);
        }

        public void Update(GameTime gameTime)
        {
            this.UpdatePlayerPosition(Keyboard.GetState());
        }

        private void UpdatePlayerPosition(KeyboardState currentKeyboardState)
        {
            // sets the player speed based on the toggle state.
            float sVelocity = this.GetPlayerSpeed();
            Vector2 CurrentPosition = this.playerRef.Position;

            if (currentKeyboardState.IsKeyDown(Keys.Left) || currentKeyboardState.IsKeyDown(Keys.A))
            {
                CurrentPosition.X -= sVelocity;
            }

            if (currentKeyboardState.IsKeyDown(Keys.Right) || currentKeyboardState.IsKeyDown(Keys.D))
            {
                CurrentPosition.X += sVelocity;
            }

            if (currentKeyboardState.IsKeyDown(Keys.Up) || currentKeyboardState.IsKeyDown(Keys.W))
            {
                CurrentPosition.Y -= sVelocity;
            }

            if (currentKeyboardState.IsKeyDown(Keys.Down) || currentKeyboardState.IsKeyDown(Keys.S))
            {
                CurrentPosition.Y += sVelocity;
            }

            // Adjust position.
            CurrentPosition = this.CheckPlayerBoundry(CurrentPosition);

            this.playerRef.Position = CurrentPosition;
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

            if (cPosition.X >= this.screenWidth)
            {
                cPosition.X = this.screenWidth;
            }

            if (cPosition.Y >= this.screenHeight)
            {
                cPosition.Y = this.screenHeight;
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
