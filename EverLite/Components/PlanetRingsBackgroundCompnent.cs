namespace EverLite
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class PlanetRingsBackgroundCompnent : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private EverLite game;
        private Texture2D planetView;

        public PlanetRingsBackgroundCompnent(EverLite game) : base(game)
        {
            this.game = game;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            this.planetView = this.Game.Content.Load<Texture2D>(@"Sprites\background_planetrings");

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
