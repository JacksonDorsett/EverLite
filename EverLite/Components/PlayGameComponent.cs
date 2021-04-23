namespace EverLite
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    public class PlayGameComponent : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private EverLite game;
        private PlayerSystem playerSystem;
        private ToggleStatus pauseStatus;
        private EnemyManager enemyManager;
        private BulletManager bulletManager;
        private CollisionDetector collisionDetector;
        private PlayerLifeManager lifeManager;
        
        public PlayGameComponent(EverLite game)
            : base(game)
        {
            this.game = game;
            this.pauseStatus = new ToggleStatus(Keys.Space);
            this.playerSystem = new PlayerSystem(this.Game);
            this.enemyManager = new EnemyManager(this.Game);
            this.bulletManager = BulletManager.Instance;
            this.collisionDetector = new CollisionDetector(
                this.enemyManager.ActiveEnemies,
                this.bulletManager.EnemyBullets,
                this.bulletManager.PlayerBullets,
                this.playerSystem.Player,
                this.game); // Game1 game is passed to the collisioDetector can access the gamescore instance
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            this.lifeManager = new PlayerLifeManager(this.game);
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            this.pauseStatus.Update();
            if (!this.pauseStatus.Status)
            {
                this.playerSystem.Update(gameTime);
                this.enemyManager.Update(gameTime);
                this.bulletManager.Update(gameTime);
                this.collisionDetector.Update(gameTime);
                this.OnWin();
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            this.bulletManager.Draw(this.game.spriteBatch);
            this.playerSystem.Draw(this.game.spriteBatch);
            this.enemyManager.Draw(this.game.spriteBatch);
            this.lifeManager.Draw(this.game.spriteBatch);
            // SidePanel is drawn first so that the extra lives appear above the sidepanel background.
            this.game.spriteBatch.Begin();
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, "SCORE", new Vector2(80, 120), Color.Yellow);
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, this.game.score.Score.ToString(), new Vector2(80, 160), Color.Yellow);
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, "Top Scores", new Vector2(80, 240), Color.Blue);
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, this.game.score.TopScore.ToString(), new Vector2(80, 280), Color.Blue);

            // Control layout
            this.game.spriteBatch.DrawString(this.game.FontOriginTechTiny, "Move: ", new Vector2(100, 640), Color.Yellow);
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, this.game.playerSettings.MoveUp.ToString(), new Vector2(325, 600), Color.Red);
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, this.game.playerSettings.MoveLeft.ToString(), new Vector2(300, 640), Color.Red);
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, this.game.playerSettings.MoveDown.ToString(), new Vector2(330, 680), Color.Red);
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, this.game.playerSettings.MoveRight.ToString(), new Vector2(350, 640), Color.Red);

            this.game.spriteBatch.DrawString(this.game.FontOriginTechTiny, "Shoot: ", new Vector2(100, 750), Color.Yellow);
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, this.game.playerSettings.Shoot.ToString(), new Vector2(330, 750), Color.Red);
            this.game.spriteBatch.DrawString(this.game.FontOriginTechTiny, "Slow Down: ", new Vector2(60, 800), Color.Yellow);
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, this.game.playerSettings.SlowSpeed.ToString(), new Vector2(330, 800), Color.Red);
            this.game.spriteBatch.DrawString(this.game.FontOriginTechTiny, "Change Weapon: ", new Vector2(40, 850), Color.Yellow);
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, this.game.playerSettings.SwitchWeapon.ToString(), new Vector2(330, 850), Color.Red);

            this.game.spriteBatch.End();
            //this.lifeManager.Draw(this.game.spriteBatch);

            base.Draw(gameTime);
        }

        private void OnWin()
        {
            if (!this.enemyManager.IsActive)
            {
                this.game.ChangeMusic(this.game.Megalovania);

                this.game.SceneManager.SwitchScene(this.game.SceneManager.GameWin);
            }
        }
    }
}
