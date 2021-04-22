namespace EverLite
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    public class TopTenComponent : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private EverLite game;

        public TopTenComponent(EverLite game) : base(game)
        {
            this.game = game;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            // key pressing
            if (game.NewKey(Keys.D))
                this.game.score.ResetTopTen();
            if (game.NewKey(Keys.Enter))
                this.game.SwitchScene(this.game.MenuScene);

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            this.game.spriteBatch.Begin();

            this.game.spriteBatch.DrawString(this.game.FontOriginTech, "Top 10 Scores", new Vector2(80, 120), Color.Blue);
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, this.game.score.TopScore.ToString(), new Vector2(80, 160), Color.Yellow);

            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, "Press 'Enter' to", new Vector2(900, 600), Color.Yellow);
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, "return to main screen", new Vector2(950, 650), Color.Yellow);
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, "Press 'D' to reset", new Vector2(900, 700), Color.Red);
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, "top scores.", new Vector2(950, 750), Color.Red);
            this.game.spriteBatch.End();
            base.Draw(gameTime);
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }
    }
}
