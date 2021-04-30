namespace EverLite
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Manages the side panel component for the PlayGameScene.
    /// </summary>
    public class SidePanelComponent : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private EverLite game;
        private PlayerSettings playerSettings;
        private Texture2D sidePanel;
        private HighScore highScore;
        /// <summary>
        /// Initializes a new instance of the <see cref="SidePanelComponent"/> class.
        /// </summary>
        /// <param name="game">game reference object.</param>
        public SidePanelComponent(EverLite game)
            : base(game)
        {
            this.game = game;
            this.playerSettings = PlayerSettings.Instance;
            this.sidePanel = this.game.Content.Load<Texture2D>(@"Sprites\background_narrowspace");
            this.highScore = new HighScore { Id = 0, Name = "AAA", Score = 0 };
        }

        /// <inheritdoc/>
        public override void Initialize()
        {
            base.Initialize();
        }

        /// <inheritdoc/>
        protected override void LoadContent()
        {
            base.LoadContent();
        }

        /// <inheritdoc/>
        public override void Draw(GameTime gameTime)
        {
            // THis cheks for the top score in the DB. If DB is empty, the default highScore shows on sidepanel.
            foreach (HighScore s in this.game.score.GetScoreList())
            {
                if (this.highScore.Score < s.Score)
                {
                    this.highScore = s;
                }
            }

            this.game.spriteBatch.Begin();
            this.game.spriteBatch.Draw(this.sidePanel, new Vector2(1500, 0), Color.White * 0.8f);

            // player score
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, "SCORE", new Vector2(1520, 120), Color.Yellow);
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, this.game.score.Score.ToString(), new Vector2(1520, 160), Color.Yellow);
            // top score
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, "Top Score", new Vector2(1520, 240), Color.Blue);

            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, this.highScore.Name, new Vector2(1520, 280), Color.BlueViolet);
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, this.highScore.Score.ToString(), new Vector2(1650, 280), Color.BlueViolet);
            // player controls map
            this.game.spriteBatch.DrawString(this.game.FontOriginTechTiny, "Move: ", new Vector2(1520, 640), Color.Yellow);
            if (this.playerSettings.MoveUp == Microsoft.Xna.Framework.Input.Keys.Up)
                this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, this.playerSettings.MoveUp.ToString(), new Vector2(1740, 600), Color.Red);
            else
                this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, this.playerSettings.MoveUp.ToString(), new Vector2(1825, 600), Color.Red);
            if (this.playerSettings.MoveLeft == Microsoft.Xna.Framework.Input.Keys.Left)
                this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, this.playerSettings.MoveLeft.ToString(), new Vector2(1660, 640), Color.Red);
            else
                this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, this.playerSettings.MoveLeft.ToString(), new Vector2(1800, 640), Color.Red);
            if (this.playerSettings.MoveDown == Microsoft.Xna.Framework.Input.Keys.Down)
                this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, this.playerSettings.MoveDown.ToString(), new Vector2(1710, 680), Color.Red);
            else
                this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, this.playerSettings.MoveDown.ToString(), new Vector2(1830, 680), Color.Red);
            if (this.playerSettings.MoveRight == Microsoft.Xna.Framework.Input.Keys.Right)
                this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, this.playerSettings.MoveRight.ToString(), new Vector2(1770, 640), Color.Red);
            else
                this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, this.playerSettings.MoveRight.ToString(), new Vector2(1860, 640), Color.Red);
            this.game.spriteBatch.DrawString(this.game.FontOriginTechTiny, "Shoot: ", new Vector2(1520, 750), Color.Yellow);
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, this.playerSettings.Shoot.ToString(), new Vector2(1830, 750), Color.Red);
            this.game.spriteBatch.DrawString(this.game.FontOriginTechTiny, "Slow Down: ", new Vector2(1520, 800), Color.Yellow);
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, this.playerSettings.SlowSpeed.ToString(), new Vector2(1830, 800), Color.Red);
            this.game.spriteBatch.DrawString(this.game.FontOriginTechTiny, "Change Weapon: ", new Vector2(1520, 850), Color.Yellow);
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, this.playerSettings.SwitchWeapon.ToString(), new Vector2(1830, 850), Color.Red);
            this.game.spriteBatch.End();
        }
    }
}
