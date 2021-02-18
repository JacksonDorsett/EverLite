using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace EverLite
{
    class Enemie
    {
        public Texture2D texture;
        public Vector2 position;
        public Vector2 velocity;

        public bool isVisible = true;

        Random random = new Random();
        int randX, randY;

        public Enemie(Texture2D newTexture, Vector2 newPosition)
        {
            this.texture = newTexture;
            this.position = newPosition;

            this.randY = this.random.Next(-4, 4);
            this.randX = this.random.Next(-4, -1);

            this.velocity = new Vector2(this.randX, this.randY);
        }

        public void Update(GraphicsDevice graphics)
        {
            position += velocity;

            if (position.Y <= 0 || position.Y >= graphics.Viewport.Height - texture.Height)
                velocity.Y = -velocity.Y;

            if(position.X < 0 - texture.Width)
                isVisible = false;
        }

        public void Draw(SpriteBatch sprite)
        {
            sprite.Draw(texture, position, Color.White);
        }
    }

}
