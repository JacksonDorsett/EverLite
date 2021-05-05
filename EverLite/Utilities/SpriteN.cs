namespace EverLite
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class SpriteN
    {
        private Texture2D mTexture;

        public SpriteN(Texture2D texture)
        {
            this.mTexture = texture;
        }

        public Texture2D Texture { get { return this.mTexture; } }

        /// <summary>
        /// Draw extra lives on side panel.
        /// </summary>
        /// <param name="spriteBatch">player sprite.</param>
        /// <param name="position">sprite draw location.</param>
        public virtual void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            Vector2 origin = new Vector2(0, 0);
            origin.X = this.mTexture.Width / 2;
            origin.Y = this.mTexture.Height / 2;
            spriteBatch.Draw(this.mTexture, position, null, Color.White, 0.2f, origin, 0.3f, SpriteEffects.None, 0);
        }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 position, float scale = 1, float rotation = 0)
        {
            Vector2 origin = new Vector2(0, 0);
            origin.X = this.mTexture.Width / 2;
            origin.Y = this.mTexture.Height / 2;
            spriteBatch.Draw(this.mTexture, position, null, Color.White, rotation, origin, scale, SpriteEffects.None, 0);
        }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 position, Color color, float scale = 1, float rotation = 0)
        {
            Vector2 origin = new Vector2(0, 0);
            origin.X = this.mTexture.Width / 2;
            origin.Y = this.mTexture.Height / 2;
            spriteBatch.Draw(this.mTexture, position, null, color, rotation, origin, scale, SpriteEffects.None, 0);
        }
    }
}
