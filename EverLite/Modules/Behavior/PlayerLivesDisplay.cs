using EverLite.Modules.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace EverLite.Modules.Behavior
{
    class PlayerLivesDisplay
    {
        SpriteN playerSprite;
        PlayerLives playerLives;

        public PlayerLivesDisplay(PlayerLives playerLives)
        {
            this.playerSprite = Player.Instance().PlayerSprite;
            this.playerLives = playerLives;
        }

        private int CurrentLives { get => playerLives.Lives; }

        public void Draw(SpriteBatch spriteBatch)
        {
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
