namespace EverLite
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class GameOverComponent : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private EverLite game;

        public GameOverComponent(EverLite game) : base(game)
        {
            this.game = game;
        }

        public override void Draw(GameTime gameTime)
        {
            this.game.score.AddTopScore(this.game.score.Score);
            this.game.spriteBatch.Begin();
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, "Press 'Enter' to", new Vector2(800, 600), Color.Yellow);
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, "return to main screen", new Vector2(850, 650), Color.Yellow);
            this.game.spriteBatch.DrawString(this.game.FontOriginTech, "GAME OVER", new Vector2(200, 150), Color.Red);
            
            this.game.spriteBatch.DrawString(this.game.FontOriginTech, "SCORE ", new Vector2(200, 210), Color.Blue);
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, this.game.score.Score.ToString(), new Vector2(200, 260), Color.Yellow);
            //this.game.spriteBatch.DrawString(this.game.FontOriginTech, "Top Scores", new Vector2(200, 310), Color.Blue);
            //this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, this.game.score.TopScore.ToString(), new Vector2(200, 360), Color.Yellow);
            this.game.spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            // key pressing
            if (game.NewKey(Keys.Enter))
            {
                this.game.score.Reset();
                this.game.SceneManager.ChangeMusic(this.game.SolarSystem);
                this.game.SceneManager.SwitchScene(this.game.SceneManager.Menu);
            }

            base.Update(gameTime);
        }
    }
}
