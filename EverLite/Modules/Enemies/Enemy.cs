using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace EverLite.Modules.Enemies
{
    abstract class Enemy
    {
        public Texture2D texture;
        public Vector2 position;
        public Vector2 velocity;

        abstract public string spriteName { get; set; }

        abstract public bool isVisible { get; set; }

        public Random random = new Random();
        public int randX, randY;

        public Enemy() { }
        public Enemy(Texture2D newTexture, Vector2 newPosition)
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
                this.isVisible = false;
        }

        /// <summary>
        /// Function that sets new velocity.
        /// </summary>
        /// <param name="newVelocity"> new velocity to set.</param>
        public void ChangeVelocity(Vector2 newVelocity)
        {
            this.velocity = newVelocity;
        }

        /// <summary>
        /// Function that sets new position.
        /// </summary>
        /// <param name="newPosition"> new position to set.</param>
        public void ChangePosition(Vector2 newPosition)
        {
            this.position = newPosition;
        }

        public void SetRandomVelocity()
        {
            this.randY = this.random.Next(-4, 4);
            this.randX = this.random.Next(-4, -1);

            this.velocity = new Vector2(this.randX, this.randY);
        }

        /// <summary>
        /// Function that sets new texture.
        /// </summary>
        /// <param name="newTexture"> new velocity to set.</param>
        public void ChangeTexture(Texture2D newTexture)
        {
            this.texture = newTexture;
        }

        public void Draw(SpriteBatch sprite)
        {
            sprite.Draw(this.texture, this.position, Color.White);
        }
    }

}
