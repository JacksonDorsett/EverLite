﻿namespace EverLite
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
            this.game.spriteBatch.End();
            //this.lifeManager.Draw(this.game.spriteBatch);

            base.Draw(gameTime);
        }

        private void OnWin()
        {
            if (!this.enemyManager.IsActive)
            {
                this.game.SwitchScene(this.game.GameWonScene);
            }
        }
    }
}