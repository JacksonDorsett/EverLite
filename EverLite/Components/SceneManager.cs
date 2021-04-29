namespace EverLite
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    using Microsoft.Xna.Framework.Media;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Manages the gameScenes.
    /// </summary>
    public class SceneManager
    {
        public KeyboardState keyboardState;
        private KeyboardState previousKeyboardState;
        private EverLite game;

        // GameScenes for each window.
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


            // Task<bool> result = InsertData(); // Only run this once
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

            ChangeMusic(this.game.SolarSystem);
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
            // Isn't the same song already playing?
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
            previousKeyboardState = keyboardState;
        }
    }
}
