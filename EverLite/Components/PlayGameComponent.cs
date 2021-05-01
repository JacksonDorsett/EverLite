namespace EverLite.Components
{
    using global::EverLite.Models.Enemies;
    using global::EverLite.Models.PlayerModel;
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Manages the game logic for the PlayGameScene.
    /// </summary>
    public class PlayGameComponent : DrawableGameComponent
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
            sidePanel = new SidePanelComponent(game);
            playerSettings = PlayerSettings.Instance;
            pauseStatus = new ToggleStatus(playerSettings.Pause);
            playerSystem = new PlayerSystem(Game);
            enemyManager = new EnemyManager(Game);
            itemsManager = new ItemsManager();
            bulletManager = BulletManager.Instance;
            collisionDetector = new CollisionDetector(
                enemyManager.ActiveEnemies,
                bulletManager.EnemyBullets,
                bulletManager.PlayerBullets,
                itemsManager.Items,
                playerSystem.Player,
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
            pauseStatus.Update();
            if (!pauseStatus.Status)
            {
                playerSystem.Update(gameTime);
                enemyManager.Update(gameTime);
                bulletManager.Update(gameTime);
                collisionDetector.Update(gameTime);
                itemsManager.Update(gameTime);
                OnWin();
            }

            base.Update(gameTime);
        }

        /// <inheritdoc/>
        public override void Draw(GameTime gameTime)
        {
            bulletManager.Draw(game.spriteBatch);
            playerSystem.Draw(game.spriteBatch);
            enemyManager.Draw(game.spriteBatch);
            sidePanel.Draw(gameTime);
            lifeManager.Draw(game.spriteBatch);
            itemsManager.Draw(game.spriteBatch);

            base.Draw(gameTime);
        }

        /// <inheritdoc/>
        protected override void LoadContent()
        {
            lifeManager = new PlayerLifeManager(game);
            base.LoadContent();
        }

        /// <summary>
        /// Switches PlayGameScene to the GameWonScene.
        /// </summary>
        private void OnWin()
        {
            if (!enemyManager.IsActive)
            {
                game.SceneManager.ChangeMusic(game.SceneManager.Megalovania);
                game.SceneManager.SwitchScene(game.SceneManager.GameWin);
            }
        }
    }
}
