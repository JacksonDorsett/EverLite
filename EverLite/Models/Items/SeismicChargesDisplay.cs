namespace EverLite.Models.Items
{
    using global::EverLite.Models.PlayerModel;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Manages the drawing of the player's extra lives.
    /// </summary>
    class SeismicChargesDisplay
    {
        private SpriteN chargeSprite;
        private SeismicChargeCount seismicChargeCount;

        public SeismicChargesDisplay(SeismicChargeCount seismicChargeCount)
        {
            this.chargeSprite = ItemsSpriteFactory.Create("seismic");
            this.seismicChargeCount = seismicChargeCount;
        }

        private int CurrentCharges { get => this.seismicChargeCount.Charges; }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Adjusted the sprite size and spawn pattern to fit in the sideGamePanel background nicely.
            Vector2 position = new Vector2((this.chargeSprite.Texture.Width / 2) + 1500, (this.chargeSprite.Texture.Height / 2) + 90);
            spriteBatch.Begin();
            for (int i = 0; i < this.CurrentCharges; i++)
            {
                this.chargeSprite.Draw(spriteBatch, position);
                position.X += this.chargeSprite.Texture.Width / 2;
            }

            spriteBatch.End();
        }
    }
}