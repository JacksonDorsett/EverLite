namespace EverLite
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

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
            this.playerRef.Position = this.SpawnPoint;
            this.playerRef.OnCollide += (sender, e) => { this.playerRef.Position = this.SpawnPoint; };
        }

        // Adjuested the X-axis spawn point to reflect sideGamePanel taking up some of the game space.
        private Vector2 SpawnPoint { get => new Vector2((this.bounds.Width + 150) / 2, 3 * this.bounds.Height / 4); }

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
            // Adjusted to prevent player from moving under the sideGamePanel.
            if (cPosition.X <= 500)
            {
                cPosition.X = 500;
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
