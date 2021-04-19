// <copyright file="SideGamePanel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.GameState
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class SideGamePanel : GameState
    {
        private Texture2D background;
        private Rectangle r1;
        private Rectangle r2;

        public SideGamePanel(Game1 game) 
            : base(game)
        {
            this.background = this.Game.Content.Load<Texture2D>("background_narrowspace");
            this.r1 = this.background.Bounds;
            this.r2 = this.r1;
        }

        public override void Draw(GameTime gameTime)
        {
            this.SpriteBatch.Begin();
            this.SpriteBatch.Draw(this.background, this.r1, this.r2, Color.White * 0.8f);
            this.SpriteBatch.DrawString(this.Game.fontOriginTechSmall, "SCORE", new Vector2(80, 120), Color.Yellow);
            this.SpriteBatch.DrawString(this.Game.fontOriginTechSmall, this.Game.score.Score.ToString(), new Vector2(80, 160), Color.Yellow);
            this.SpriteBatch.DrawString(this.Game.fontOriginTechSmall, "Top Scores", new Vector2(80, 220), Color.Blue);
            this.SpriteBatch.DrawString(this.Game.fontOriginTechSmall, this.Game.score.TopScore.ToString(), new Vector2(80, 260), Color.Blue);
            this.SpriteBatch.End();
        }

        public override void OnEnter()
        {
        }

        public override void Update(GameTime gameTime)
        {
        }

        public override void OnExit()
        {
        }
    }
}
