namespace EverLite
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class NoSprite : SpriteN
    {
        public NoSprite(Texture2D texture = null)
            : base(null)
        {
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, float scale = 1, float rotation = 0)
        {

        }
    }
}
