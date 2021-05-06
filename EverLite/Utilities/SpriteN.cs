﻿namespace EverLite
{
    using global::EverLite.Utilities;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class SpriteN
    {
        TransformManager TransformManager;
        private Texture2D mTexture;

        public SpriteN(Texture2D texture)
        {
            this.mTexture = texture;
            this.TransformManager = TransformManager.Instance;
        }

        public Texture2D Texture { get { return this.mTexture; } }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 position, float scale = 1, float rotation = 0, bool applyTransform = true)
        {
            Vector2 origin = new Vector2(0, 0);
            origin.X = this.mTexture.Width / 2;
            origin.Y = this.mTexture.Height / 2;

            var m = Matrix.Identity;
            var npos = Vector2.Transform(position, m);
            var nOrigin = Vector2.Transform(origin, m);
            spriteBatch.Draw(this.mTexture, Vector2.Transform(position, TransformManager.Transform), null, Color.White, rotation + TransformManager.Angle, origin, scale, SpriteEffects.None, 0);
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
