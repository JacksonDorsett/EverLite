namespace EverLite
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class PlayerSystem
    {
        private Player player;
        private PlayerMovementManager movementManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerSystem"/> class.
        /// </summary>
        /// <param name="game">game Reference object.</param>
        public PlayerSystem(Game game)
        {
            this.player = Player.Instance();
            this.movementManager = new PlayerMovementManager(this.player, new Rectangle(0, 0, 1920, 1000));
        }

        /// <summary>
        /// Gets the player object.
        /// Note: This Method needs refactoring.
        /// </summary>
        public Player Player
        {
            get
            {
                return this.player;
            }
        }

        /// <summary>
        /// Calls on the player and bullet updates.
        /// </summary>
        /// <param name="gameTime">GameTime.</param>
        public void Update(GameTime gameTime)
        {
            this.player.Update(gameTime);
            this.movementManager.Update(gameTime);
        }

        /// <summary>
        /// Draws shapes in the game.
        /// </summary>
        /// <param name="sprite">SpriteBatch.</param>
        public void Draw(SpriteBatch sprite)
        {
            sprite.Begin();
            this.player.Draw(sprite);
            sprite.End();
        }
    }
}
