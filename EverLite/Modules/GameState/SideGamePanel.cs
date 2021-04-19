namespace EverLite.Modules.GameState
{
    using System;
    using EverLite.Modules.Behavior;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class SideGamePanel
    {
        private Game1 game;
        //private GameScore score;
        private Texture2D background;
        private Rectangle r1;
        private Rectangle r2;
        /*
        public SideGamePanel(Game1 g, GameScore s)
        {
            this.game = g;
            this.score = s;
            this.background = this.game.Content.Load<Texture2D>("background_narrowspace");
            this.r1 = this.background.Bounds;
            this.r2 = this.r1;
        }*/

        public SideGamePanel(Game1 g)
        {
            this.game = g;
            //this.score = g.score;
            this.background = this.game.Content.Load<Texture2D>("background_narrowspace");
            this.r1 = this.background.Bounds;
            this.r2 = this.r1;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(this.background, this.r1, this.r2, Color.White * 0.8f);
            spriteBatch.DrawString(this.game.fontBloxSmall, "sCoRe ", new Vector2(80, 120), Color.Yellow);
            spriteBatch.DrawString(this.game.fontBloxSmall, this.game.score.Score.ToString(), new Vector2(80, 160), Color.Yellow);
            spriteBatch.End();
        }
    }
}
