namespace EverLite.Components
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Audio;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Media;
    using System;
    using System.Linq;

    /// <summary>
    /// Manages the gameScenes.
    /// </summary>
    public class SceneManager
    {
        public SpriteFont FontOriginTech;
        public SpriteFont FontOriginTechSmall;
        public SpriteFont FontOriginTechTiny;

        private SoundManager soundManager;
        private EverLite game;
        private GameScene MenuScene;
        private GameScene TopTenScene;
        private GameScene GameWonScene;
        private GameScene GameOverScene;
        private GameScene PlayerSettingsScene;
        private VolumeManager volume;
        private SoundManager sound;

        /// <summary>
        /// Initializes a new instance of the <see cref="SceneManager"/> class.
        /// </summary>
        /// <param name="game">game reference object.</param>
        public SceneManager(EverLite game)
        {
            this.game = game;
            this.volume = VolumeManager.Instance;
            this.soundManager = SoundManager.Instance;
            this.sound = SoundManager.Instance;
            Initialize();
        }

        public VolumeManager Volume => volume;
        /// <summary>
        /// Gets the MenuScene.
        /// </summary>
        public GameScene Menu => MenuScene;

        /// <summary>
        /// Gets the GameOverScene.
        /// </summary>
        public GameScene GameOver => GameOverScene;

        /// <summary>
        /// Gets the GameWonScene.
        /// </summary>
        public GameScene GameWin => GameWonScene;

        /// <summary>
        /// Gets the TopTenScene.
        /// </summary>
        public GameScene TopTen => TopTenScene;

        public GameScene PlayerSettings => PlayerSettingsScene;

        /// <summary>
        /// Gets the PlayGameScene.
        /// </summary>
        public GameScene NewGame => CreateNewGame();

        /// <summary>
        /// Initializes all the gameScenes.
        /// Sets the menuScene as the active scene.
        /// </summary>
        private void Initialize()
        {
            // creating background components
            PlanetBackgroundComponent planetBackground = new PlanetBackgroundComponent(game);
            PlanetExplodeBackgroundComponent planetExplodeBackground = new PlanetExplodeBackgroundComponent(game);
            PlanetRingsBackgroundCompnent planetRingsBackground = new PlanetRingsBackgroundCompnent(game);

            // creating window components
            TopTenComponent topTen = new TopTenComponent(game);
            GameWonComponent gameWon = new GameWonComponent(game);
            GameOverComponent gameOver = new GameOverComponent(game);
            PlayerSettingsComponent playerSettings = new PlayerSettingsComponent(game);
            MenuItemsComponent menuItems = new MenuItemsComponent(game, new Vector2(700, 250), Color.Red, Color.Yellow);

            // Listing menu options. Room to grow if we want more options.
            menuItems.AddItem("Play");
            menuItems.AddItem("Top Scores");
            menuItems.AddItem("Player Settings");
            menuItems.AddItem("Quit");
            MenuComponent menu = new MenuComponent(game, menuItems);

            // Assigns music
            soundManager.SetDeepSpaceMusic(game.Content.Load<Song>(@"Sounds\DeepSpace"));
            soundManager.SetMegalovaniaMusic(game.Content.Load<Song>(@"Sounds\Megalovania"));
            soundManager.SetSolarSystemMusic(game.Content.Load<Song>(@"Sounds\Solar System"));
            soundManager.SetMenuBGMusic(game.Content.Load<Song>(@"Sounds\MenuBG"));
            
            // Assigns sound effects
            soundManager.SetGunShotSound(game.Content.Load<SoundEffect>(@"Sounds\gunShot"));
            soundManager.SetExplosionSound(game.Content.Load<SoundEffect>(@"Sounds\explosion"));
            soundManager.SetExplosion1Sound(game.Content.Load<SoundEffect>(@"Sounds\explosion1"));
            soundManager.SetLaserShotSound(game.Content.Load<SoundEffect>(@"Sounds\laserShot"));
            soundManager.SetLaserShot1Sound(game.Content.Load<SoundEffect>(@"Sounds\laserShot1"));
            soundManager.SetLosingSound(game.Content.Load<SoundEffect>(@"Sounds\losing"));
            
            // Assigns fancy font.
            FontOriginTech = game.Content.Load<SpriteFont>(@"Fonts\font_origin_tech");
            FontOriginTechSmall = game.Content.Load<SpriteFont>(@"Fonts\font_origin_tech_small");
            FontOriginTechTiny = game.Content.Load<SpriteFont>(@"Fonts\font_origin_tech_tiny");

            // Putting together the GameScenes, each using a background component and a window component.
            MenuScene = new GameScene(game, planetBackground, menu);
            TopTenScene = new GameScene(game, planetBackground, topTen);
            GameWonScene = new GameScene(game, planetRingsBackground, gameWon);
            GameOverScene = new GameScene(game, planetExplodeBackground, gameOver);
            PlayerSettingsScene = new GameScene(game, planetRingsBackground, playerSettings);
            MenuScene = new GameScene(game, planetBackground, menu, menuItems);

            // disabling components
            foreach (GameComponent component in game.Components)
            {
                ChangeComponentState(component, false);
            }
            
            ChangeMusic(this.sound.MenuBG);
        }

        /// <summary>
        /// Creates the PlayGameScene.
        /// </summary>
        /// <returns>New PlayGameScene.</returns>
        public GameScene CreateNewGame()
        {
            PlayGameComponent level = new PlayGameComponent(game);
            ScrollingStarsBackgroundComponent starfield = new ScrollingStarsBackgroundComponent(game);
            return new GameScene(game, starfield, level);
        }

        /// <summary>
        /// Changes the active gameScene to a different gameScene.
        /// </summary>
        /// <param name="component">GameComponent.</param>
        /// <param name="enabled">T or F if component is part of active scene.</param>
        private void ChangeComponentState(GameComponent component, bool enabled)
        {
            component.Enabled = enabled;
            if (component is DrawableGameComponent)
                ((DrawableGameComponent)component).Visible = enabled;
        }

        /// <summary>
        /// Changes the music for the gameScenes.
        /// </summary>
        /// <param name="song"></param>
        public void ChangeMusic(Song song)
        {
            if (MediaPlayer.Queue.ActiveSong != song)
                MediaPlayer.Play(song);
        }

        /// <summary>
        /// Switches the active scene to the next gameScene.
        /// </summary>
        /// <param name="scene"></param>
        public void SwitchScene(GameScene scene)
        {
            GameComponent[] usedComponents = scene.ReturnComponents();
            foreach (GameComponent component in game.Components)
            {
                bool isUsed = usedComponents.Contains(component);
                ChangeComponentState(component, isUsed);
            }
        }
    }
}
