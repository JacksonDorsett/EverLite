namespace EverLite
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    public class PlayerSettingsComponent : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private EverLite game;

        public PlayerSettingsComponent(EverLite game) 
            : base(game)
        {
            this.game = game;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {


            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            this.game.spriteBatch.Begin();

            this.game.spriteBatch.DrawString(this.game.FontOriginTech, "Top 10 Scores", new Vector2(80, 120), Color.Blue);
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, this.game.score.TopScore.ToString(), new Vector2(80, 170), Color.Yellow);


            this.game.spriteBatch.End();
            base.Draw(gameTime);
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }
    }
}
