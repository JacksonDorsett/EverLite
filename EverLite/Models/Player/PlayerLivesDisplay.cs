namespace EverLite
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Manages the drawing of the player's extra lives.
    /// </summary>
    class PlayerLivesDisplay
    {
        private SpriteN playerSprite;
        private PlayerLives playerLives;

        public PlayerLivesDisplay(PlayerLives playerLives)
        {
            this.playerSprite = Player.Instance().PlayerSprite;
            this.playerLives = playerLives;
        }

        private int CurrentLives { get => this.playerLives.Lives; }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Adjusted the sprite size and spawn pattern to fit in the sideGamePanel background nicely.
            Vector2 position = new Vector2(this.playerSprite.Texture.Width / 4, this.playerSprite.Texture.Height / 4);
            spriteBatch.Begin();
            for (int i = 0; i < this.CurrentLives; i++)
            {
                this.playerSprite.Draw(spriteBatch, position, .4f);
                position.X += this.playerSprite.Texture.Width / 2;
            }

            spriteBatch.End();
        }
    }
}
