namespace EverLite
{
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Manages the game logic for the PlayGameScene.
    /// </summary>
    public class PlayGameComponent : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private EverLite game;
        private PlayerSystem playerSystem;
        private ToggleStatus pauseStatus;
        private EnemyManager enemyManager;
        private BulletManager bulletManager;
        private CollisionDetector collisionDetector;
        private PlayerLifeManager lifeManager;
        private PlayerSettings playerSettings;
        private SidePanelComponent sidePanel;
        private ItemsManager itemsManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayGameComponent"/> class.
        /// </summary>
        /// <param name="game">game reference object.</param>
        public PlayGameComponent(EverLite game)
            : base(game)
        {
            this.game = game;
            this.sidePanel = new SidePanelComponent(game);
            this.playerSettings = PlayerSettings.Instance;
            this.pauseStatus = new ToggleStatus(this.playerSettings.Pause);
            this.playerSystem = new PlayerSystem(this.Game);
            this.enemyManager = new EnemyManager(this.Game);
            this.itemsManager = new ItemsManager();
            this.bulletManager = BulletManager.Instance;
            this.collisionDetector = new CollisionDetector(
                this.enemyManager.ActiveEnemies,
                this.bulletManager.EnemyBullets,
                this.bulletManager.PlayerBullets,
                this.itemsManager.Items,
                this.playerSystem.Player,
                this.game); // Game1 game is passed to the collisioDetector can access the gamescore instance
        }

        /// <inheritdoc/>
        public override void Initialize()
        {
            base.Initialize();
        }

        /// <inheritdoc/>
        public override void Update(GameTime gameTime)
        {
            this.pauseStatus.Update();
            if (!this.pauseStatus.Status)
            {
                this.playerSystem.Update(gameTime);
                this.enemyManager.Update(gameTime);
                this.bulletManager.Update(gameTime);
                this.collisionDetector.Update(gameTime);
                this.itemsManager.Update(gameTime);
                this.OnWin();
            }

            base.Update(gameTime);
        }

        /// <inheritdoc/>
        public override void Draw(GameTime gameTime)
        {
            this.bulletManager.Draw(this.game.spriteBatch);
            this.playerSystem.Draw(this.game.spriteBatch);
            this.enemyManager.Draw(this.game.spriteBatch);
            this.sidePanel.Draw(gameTime);
            this.lifeManager.Draw(this.game.spriteBatch);
            this.itemsManager.Draw(this.game.spriteBatch);

            base.Draw(gameTime);
        }

        /// <inheritdoc/>
        protected override void LoadContent()
        {
            this.lifeManager = new PlayerLifeManager(this.game);
            base.LoadContent();
        }

        /// <summary>
        /// Switches PlayGameScene to the GameWonScene.
        /// </summary>
        private void OnWin()
        {
            if (!this.enemyManager.IsActive)
            {
                this.game.SceneManager.ChangeMusic(this.game.Megalovania);
                this.game.SceneManager.SwitchScene(this.game.SceneManager.GameWin);
            }
        }
    }
}
