namespace EverLite
{
    using Microsoft.Xna.Framework;
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
        public Song DeepSpace;
        public Song Megalovania;
        public Song SolarSystem;
        public Song MenuBG;

        private EverLite game;
        private GameScene MenuScene;
        private GameScene TopTenScene;
        private GameScene GameWonScene;
        private GameScene GameOverScene;
        private GameScene PlayerSettingsScene;


        /// <summary>
        /// Initializes a new instance of the <see cref="SceneManager"/> class.
        /// </summary>
        /// <param name="game">game reference object.</param>
        public SceneManager(EverLite game)
        {
            this.game = game;
            Initialize();
        }

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
            this.DeepSpace = game.Content.Load<Song>(@"Sounds\DeepSpace");
            this.Megalovania = game.Content.Load<Song>(@"Sounds\Megalovania");
            this.SolarSystem = game.Content.Load<Song>(@"Sounds\Solar System");
            this.MenuBG = game.Content.Load<Song>(@"Sounds\MenuBG");

            // Assigns fancy font.
            this.FontOriginTech = game.Content.Load<SpriteFont>(@"Fonts\font_origin_tech");
            this.FontOriginTechSmall = game.Content.Load<SpriteFont>(@"Fonts\font_origin_tech_small");
            this.FontOriginTechTiny = game.Content.Load<SpriteFont>(@"Fonts\font_origin_tech_tiny");

            // Putting together the GameScenes, each using a background component and a window component.
            this.MenuScene = new GameScene(game, planetBackground, menu);
            this.TopTenScene = new GameScene(game, planetBackground, topTen);
            this.GameWonScene = new GameScene(game, planetRingsBackground, gameWon);
            this.GameOverScene = new GameScene(game, planetExplodeBackground, gameOver);
            this.PlayerSettingsScene = new GameScene(game, planetRingsBackground, playerSettings);
            this.MenuScene = new GameScene(game, planetBackground, menu, menuItems);

            // disabling components
            foreach (GameComponent component in game.Components)
            {
                ChangeComponentState(component, false);
            }
            float f = MediaPlayer.Volume;
            ChangeMusic(this.MenuBG);
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
