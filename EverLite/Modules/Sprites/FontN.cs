namespace EverLite.Modules.Sprites
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class FontN
    {
        private SpriteFont mTexture;

        public FontN(SpriteFont texture)
        {
            this.mTexture = texture;
        }

        public SpriteFont Texture { get { return this.mTexture; } }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 position, float scale = 1, float rotation = 0)
        {
            //Vector2 origin = new Vector2(0, 0);
            //origin.X = this.mTexture.Width / 2;
            //origin.Y = this.mTexture.Height / 2;
            //spriteBatch.Draw(this.mTexture, position, null, Color.White, rotation, origin, scale, SpriteEffects.None, 0);
        }
    }
}
