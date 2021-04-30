namespace EverLite
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    using System.Threading.Tasks;

    /// <summary>
    /// Manages the TopTenComponent for the TopTenScene.
    /// </summary>
    public class TopTenComponent : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private EverLite game;

        /// <summary>
        /// Initializes a new instance of the <see cref="TopTenComponent"/> class.
        /// </summary>
        /// <param name="game">game reference object.</param>
        public TopTenComponent(EverLite game) 
            : base(game)
        {
            this.game = game;
        }

        /// <inheritdoc/>
        public override void Initialize()
        {
            base.Initialize();
        }

        /// <inheritdoc/>
        public override void Update(GameTime gameTime)
        {
            Task<bool> result;

            if (game.NewKey(Keys.Enter))
            {
                this.game.SceneManager.SwitchScene(this.game.SceneManager.Menu);
            }

            base.Update(gameTime);
        }

        /// <inheritdoc/>
        public async override void Draw(GameTime gameTime)
        {
            int position = 200;
            int count = 1;

            this.game.spriteBatch.Begin();

            this.game.spriteBatch.DrawString(this.game.FontOriginTech, "Top 10 Scores", new Vector2(80, 120), Color.DeepSkyBlue);
            
            foreach (HighScore s in this.game.score.GetScoreList())
            {
                this.game.spriteBatch.DrawString(this.game.FontOriginTech, s.Name, new Vector2(80, position), Color.Yellow);
                this.game.spriteBatch.DrawString(this.game.FontOriginTech, s.Score.ToString(), new Vector2(250, position), Color.Yellow);
                position += 70;
                count++;
                if (count > 10)
                    break;
            }

            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, "Press 'Enter' to", new Vector2(900, 600), Color.Yellow);
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, "return to main screen", new Vector2(950, 650), Color.Yellow);
            //this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, "Press 'D' to reset", new Vector2(900, 700), Color.Red);
            //this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, "top scores.", new Vector2(950, 750), Color.Red);
            this.game.spriteBatch.End();
            base.Draw(gameTime);
        }

        /// <inheritdoc/>
        protected override void LoadContent()
        {
            base.LoadContent();
        }
    }
}
