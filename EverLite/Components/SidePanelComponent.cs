namespace EverLite
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    /// <summary>
    /// Manages the side panel component for the PlayGameScene.
    /// </summary>
    public class SidePanelComponent : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private EverLite game;
        private PlayerSettings playerSettings;
        private Texture2D sidePanel;
        private HighScore highScore;
        private VolumeManager volume;

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
            this.volume = VolumeManager.Instance;
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
            // This cheks for the top score in the DB. If DB is empty, the default highScore shows on sidepanel.
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
            this.game.spriteBatch.DrawString(this.game.SceneManager.FontOriginTechSmall, "SCORE", new Vector2(1520, 120), Color.Yellow);
            this.game.spriteBatch.DrawString(this.game.SceneManager.FontOriginTechSmall, this.game.score.Score.ToString(), new Vector2(1520, 160), Color.Yellow);
            
            // top score
            this.game.spriteBatch.DrawString(this.game.SceneManager.FontOriginTechSmall, "Top Score", new Vector2(1520, 240), Color.Blue);
            this.game.spriteBatch.DrawString(this.game.SceneManager.FontOriginTechSmall, this.highScore.Name, new Vector2(1520, 280), Color.BlueViolet);
            this.game.spriteBatch.DrawString(this.game.SceneManager.FontOriginTechSmall, this.highScore.Score.ToString(), new Vector2(1650, 280), Color.BlueViolet);
            
            // player controls map
            this.game.spriteBatch.DrawString(this.game.SceneManager.FontOriginTechTiny, "Move: ", new Vector2(1520, 640), Color.Yellow);
            if (this.playerSettings.MoveUp == Keys.Up)
                this.game.spriteBatch.DrawString(this.game.SceneManager.FontOriginTechSmall, this.playerSettings.MoveUp.ToString(), new Vector2(1740, 600), Color.Red);
            else
                this.game.spriteBatch.DrawString(this.game.SceneManager.FontOriginTechSmall, this.playerSettings.MoveUp.ToString(), new Vector2(1825, 600), Color.Red);
            if (this.playerSettings.MoveLeft == Keys.Left)
                this.game.spriteBatch.DrawString(this.game.SceneManager.FontOriginTechSmall, this.playerSettings.MoveLeft.ToString(), new Vector2(1660, 640), Color.Red);
            else
                this.game.spriteBatch.DrawString(this.game.SceneManager.FontOriginTechSmall, this.playerSettings.MoveLeft.ToString(), new Vector2(1800, 640), Color.Red);
            if (this.playerSettings.MoveDown == Keys.Down)
                this.game.spriteBatch.DrawString(this.game.SceneManager.FontOriginTechSmall, this.playerSettings.MoveDown.ToString(), new Vector2(1710, 680), Color.Red);
            else
                this.game.spriteBatch.DrawString(this.game.SceneManager.FontOriginTechSmall, this.playerSettings.MoveDown.ToString(), new Vector2(1830, 680), Color.Red);
            if (this.playerSettings.MoveRight == Keys.Right)
                this.game.spriteBatch.DrawString(this.game.SceneManager.FontOriginTechSmall, this.playerSettings.MoveRight.ToString(), new Vector2(1770, 640), Color.Red);
            else
                this.game.spriteBatch.DrawString(this.game.SceneManager.FontOriginTechSmall, this.playerSettings.MoveRight.ToString(), new Vector2(1860, 640), Color.Red);
            this.game.spriteBatch.DrawString(this.game.SceneManager.FontOriginTechTiny, "Shoot: ", new Vector2(1520, 750), Color.Yellow);
            this.game.spriteBatch.DrawString(this.game.SceneManager.FontOriginTechSmall, this.playerSettings.Shoot.ToString(), new Vector2(1830, 750), Color.Red);
            this.game.spriteBatch.DrawString(this.game.SceneManager.FontOriginTechTiny, "Use Bomb: ", new Vector2(1520, 800), Color.Yellow);
            this.game.spriteBatch.DrawString(this.game.SceneManager.FontOriginTechSmall, this.playerSettings.UseBomb.ToString(), new Vector2(1830, 800), Color.Red);
            this.game.spriteBatch.DrawString(this.game.SceneManager.FontOriginTechTiny, "Slow Down: ", new Vector2(1520, 850), Color.Yellow);
            this.game.spriteBatch.DrawString(this.game.SceneManager.FontOriginTechSmall, this.playerSettings.SlowSpeed.ToString(), new Vector2(1830, 850), Color.Red);

            // volume level
            this.game.spriteBatch.DrawString(this.game.SceneManager.FontOriginTechTiny, "Volume: ", new Vector2(1600, 920), Color.Chartreuse);
            this.game.spriteBatch.DrawString(this.game.SceneManager.FontOriginTechTiny, this.volume.VolumeLevel.ToString(), new Vector2(1750, 920), Color.Chartreuse);
            this.game.spriteBatch.DrawString(this.game.SceneManager.FontOriginTechTiny, "SFX: ", new Vector2(1600, 960), Color.Chartreuse);
            this.game.spriteBatch.DrawString(this.game.SceneManager.FontOriginTechTiny, (this.volume.SoundLevel*20).ToString(), new Vector2(1750, 960), Color.Chartreuse);
            this.game.spriteBatch.End();
        }
    }
}
