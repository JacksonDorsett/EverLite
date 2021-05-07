namespace EverLite.Components
{
    using global::EverLite.Models.Enemies;
    using global::EverLite.Models.PlayerModel;
    using global::EverLite.Utilities;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Audio;
    using Microsoft.Xna.Framework.Input;

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
        private VolumeManager volume;
        private TransformManager transformManager;
        private SoundManager sound;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayGameComponent"/> class.
        /// </summary>
        /// <param name="game">game reference object.</param>
        public PlayGameComponent(EverLite game)
            : base(game)
        {
            this.game = game;
            this.volume = VolumeManager.Instance;
            this.sound = SoundManager.Instance;
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
            this.transformManager = TransformManager.Instance;
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
                transformManager.Update(gameTime);
                OnWin();
            }


            // Volume control
            if (Keyboard.GetState().IsKeyDown(Keys.OemPlus))
                this.volume.VolumeUp();
            if (Keyboard.GetState().IsKeyDown(Keys.OemMinus))
                this.volume.VolumeDown();
            if (Keyboard.GetState().IsKeyDown(Keys.OemCloseBrackets))
                this.volume.SoundUp();
            if (Keyboard.GetState().IsKeyDown(Keys.OemOpenBrackets))
                this.volume.SoundDown();
            if (this.game.NewKey(Keys.D0))
                this.volume.Mute();
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
                sound.Winning.Play(volume: volume.SoundLevel, pitch: 0.0f, pan: 0.0f);
                game.SceneManager.ChangeMusic(sound.Megalovania);
                game.SceneManager.SwitchScene(game.SceneManager.GameWin);
            }
        }
    }
}
