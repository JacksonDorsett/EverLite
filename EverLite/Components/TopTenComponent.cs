namespace EverLite
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    using System;
    using System.Collections.Generic;

    public class TopTenComponent : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private EverLite game;

        public TopTenComponent(EverLite game) 
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
            // key pressing
            if (game.NewKey(Keys.D))
                this.game.score.ResetTopTen();
            if (game.NewKey(Keys.Enter))
            {
                this.game.SceneManager.SwitchScene(this.game.SceneManager.Menu);
            }
                
                

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            this.game.spriteBatch.Begin();

            this.game.spriteBatch.DrawString(this.game.FontOriginTech, "Top 5 Scores", new Vector2(80, 120), Color.DeepSkyBlue);

            int position = 200;
            for(int index = 0; index < 5; index++)
            {
                this.game.spriteBatch.DrawString(this.game.FontOriginTech, this.game.score.GetScoreList()[index].Item2, new Vector2(80, position), Color.Yellow);
                this.game.spriteBatch.DrawString(this.game.FontOriginTech, this.game.score.GetScoreList()[index].Item1.ToString(), new Vector2(250, position), Color.Yellow);
                position += 70;
            }

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
