namespace EverLite
{
    using global::EverLite.Models.PlayerModel;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    internal class PlayerMovementManager
    {
        private static readonly float NORMALSPEED = 15.0f;
        private static readonly float SLOWSPEED = 5.0f;
        private Rectangle bounds;
        private Player playerRef;
        private PlayerSettings playerSettings;
        private SoundManager sound;
        private VolumeManager volume;

        public PlayerMovementManager(Player player, Rectangle bounds)
        {
            this.playerSettings = PlayerSettings.Instance;
            this.playerRef = player;
            this.bounds = bounds;
            this.playerRef.Position = this.SpawnPoint;
            this.sound = SoundManager.Instance;
            this.volume = VolumeManager.Instance;
            this.playerRef.OnCollide += (sender, e) => { this.sound.Explosion1.Play(volume: volume.SoundLevel, pitch: 0.0f, pan: 0.0f);  this.playerRef.Position = this.SpawnPoint; };
        }

        // Adjuested the X-axis spawn point to reflect sideGamePanel taking up some of the game space.
        private Vector2 SpawnPoint { get => new Vector2((this.bounds.Width + 150) / 2, 3 * this.bounds.Height / 4); }

        public void Update(GameTime gameTime)
        {
            this.UpdatePlayerPosition(Keyboard.GetState());
            //this.UpdatePlayerPosition();
        }

        private void UpdatePlayerPosition(KeyboardState currentKeyboardState)
        {
            // sets the player speed based on the toggle state.
            float sVelocity = this.GetPlayerSpeed();
            Vector2 currentPosition = this.playerRef.Position; // currentKeyboardState.IsKeyDown(Keys.A)
            
            if (currentKeyboardState.IsKeyDown(this.playerSettings.MoveLeft))
            {
                currentPosition.X -= sVelocity;
            }

            if (currentKeyboardState.IsKeyDown(this.playerSettings.MoveRight))
            {
                currentPosition.X += sVelocity;
            }

            if (currentKeyboardState.IsKeyDown(this.playerSettings.MoveUp))
            {
                currentPosition.Y -= sVelocity;
            }

            if (currentKeyboardState.IsKeyDown(this.playerSettings.MoveDown))
            {
                currentPosition.Y += sVelocity;
            }

            // Adjust position.
            currentPosition = this.CheckPlayerBoundry(currentPosition);

            this.playerRef.Position = currentPosition;
        }

        private Vector2 CheckPlayerBoundry(Vector2 cPosition)
        {
            var pb = this.playerRef.PlayerSprite.Texture.Bounds;
            // Adjusted to prevent player from moving under the sideGamePanel.
            if (cPosition.X <= pb.Width/4)
            {
                cPosition.X = pb.Width/4;
            }

            if (cPosition.Y <= pb.Height/4)
            {
                cPosition.Y = pb.Height/4;
            }

            if (cPosition.X >= this.bounds.Width - pb.Width / 4)
            {
                cPosition.X = this.bounds.Width - pb.Width / 4;
            }

            if (cPosition.Y >= this.bounds.Height - pb.Height / 4)
            {
                cPosition.Y = this.bounds.Height - pb.Height / 4;
            }

            return cPosition;
        }
        
        private float GetPlayerSpeed()
        {
            if (Keyboard.GetState().IsKeyDown(this.playerSettings.SlowSpeed)) return SLOWSPEED;
            return NORMALSPEED;
        }
    }
}
