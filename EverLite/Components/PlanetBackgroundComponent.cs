namespace EverLite
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class PlanetBackgroundComponent : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private EverLite game;
        private Texture2D planetView;

        public PlanetBackgroundComponent(EverLite game)
            : base(game)
        {
            this.game = game;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            this.planetView = this.game.Content.Load<Texture2D>(@"Sprites\space");

            base.LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            this.game.spriteBatch.Begin();

            this.game.spriteBatch.Draw(this.planetView, new Vector2(0, 0), Color.White);

            this.game.spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
