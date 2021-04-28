namespace EverLite
{
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Manages the side panel component for the PlayGameScene.
    /// </summary>
    public class SidePanelComponent : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private EverLite game;
        private PlayerSettings playerSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="SidePanelComponent"/> class.
        /// </summary>
        /// <param name="game">game reference object.</param>
        public SidePanelComponent(EverLite game)
            : base(game)
        {
            this.game = game;
            this.playerSettings = PlayerSettings.Instance;
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
            this.game.spriteBatch.Begin();
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, "SCORE", new Vector2(80, 120), Color.Yellow);
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, this.game.score.Score.ToString(), new Vector2(80, 160), Color.Yellow);
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, "Top Score", new Vector2(80, 240), Color.Blue);
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, this.game.score.GetScoreList()[0].Item2, new Vector2(80, 280), Color.BlueViolet);
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, this.game.score.GetScoreList()[0].Item1.ToString(), new Vector2(200, 280), Color.BlueViolet);
            this.game.spriteBatch.DrawString(this.game.FontOriginTechTiny, "Move: ", new Vector2(100, 640), Color.Yellow);
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, this.playerSettings.MoveUp.ToString(), new Vector2(325, 600), Color.Red);
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, this.playerSettings.MoveLeft.ToString(), new Vector2(200, 640), Color.Red);
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, this.playerSettings.MoveDown.ToString(), new Vector2(330, 680), Color.Red);
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, this.playerSettings.MoveRight.ToString(), new Vector2(360, 640), Color.Red);
            this.game.spriteBatch.DrawString(this.game.FontOriginTechTiny, "Shoot: ", new Vector2(100, 750), Color.Yellow);
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, this.playerSettings.Shoot.ToString(), new Vector2(330, 750), Color.Red);
            this.game.spriteBatch.DrawString(this.game.FontOriginTechTiny, "Slow Down: ", new Vector2(60, 800), Color.Yellow);
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, this.playerSettings.SlowSpeed.ToString(), new Vector2(330, 800), Color.Red);
            this.game.spriteBatch.DrawString(this.game.FontOriginTechTiny, "Change Weapon: ", new Vector2(40, 850), Color.Yellow);
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, this.playerSettings.SwitchWeapon.ToString(), new Vector2(330, 850), Color.Red);
            this.game.spriteBatch.End();
        }
    }
}
