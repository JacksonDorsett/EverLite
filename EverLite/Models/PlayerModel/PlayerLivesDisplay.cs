namespace EverLite
{
    using global::EverLite.Models.PlayerModel;
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
            Vector2 position = new Vector2((this.playerSprite.Texture.Width / 4) + 1520, this.playerSprite.Texture.Height / 4);
            spriteBatch.Begin();
            for (int i = 0; i < this.CurrentLives; i++)
            {
                this.playerSprite.Draw(spriteBatch, position);
                position.X += this.playerSprite.Texture.Width / 3;
            }

            spriteBatch.End();
        }
    }
}
