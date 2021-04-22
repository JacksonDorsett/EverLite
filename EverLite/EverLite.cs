namespace EverLite
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Audio;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Microsoft.Xna.Framework.Media;
    using System;
    using System.Linq;

    public class EverLite : Game
    {
        public int WindowWidth = 1920;
        public int WindowHeight = 1000;

        public SpriteFont FontOriginTech;
        public SpriteFont FontOriginTechSmall;

        // GameScenes for each window.
        public GameScene MenuScene;
        public GameScene LevelScene;
        public GameScene TopTenScene;
        public GameScene GameWonScene;
        public GameScene GameOverScene;

        // Maintains the score keeping for game.
        public GameScore score;

        public Song DeepSpace;
        public Song Megalovania;
        public Song SolarSystem;

        private GraphicsDeviceManager graphics;

        public SpriteBatch spriteBatch;
        
        // Needed to check for NewKey()
        public KeyboardState keyboardState;
        private KeyboardState previousKeyboardState;

        public EverLite()
        {
            this.graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            this.score = GameScore.Instance;
        }

        protected override void Initialize()
        {
            SpriteLoader.Initialize(this.Content);

            // creating background components
            ScrollingStarsBackgroundComponent starfield = new ScrollingStarsBackgroundComponent(this);
            PlanetBackgroundComponent planetBackground = new PlanetBackgroundComponent(this);
            PlanetExplodeBackgroundComponent planetExplodeBackground = new PlanetExplodeBackgroundComponent(this);
            PlanetRingsBackgroundCompnent planetRingsBackground = new PlanetRingsBackgroundCompnent(this);
            // creating window components
            PlayGameComponent level = new PlayGameComponent(this);
            TopTenComponent topTen = new TopTenComponent(this);
            GameWonComponent gameWon = new GameWonComponent(this);
            GameOverComponent gameOver = new GameOverComponent(this);
            MenuItemsComponent menuItems = new MenuItemsComponent(this, new Vector2(700, 250), Color.Red, Color.Yellow);

            // Listing menu options. Room to grow if we want more options.
            menuItems.AddItem("Play");
            menuItems.AddItem("Top Scores");
            menuItems.AddItem("Quit");
            MenuComponent menu = new MenuComponent(this, menuItems);

            // Putting together the GameScenes, each using a background component and a window component.
            this.MenuScene = new GameScene(this, planetBackground, menu);
            this.LevelScene = new GameScene(this, starfield, level);
            this.TopTenScene = new GameScene(this, planetBackground, topTen);
            this.GameWonScene = new GameScene(this, planetRingsBackground, gameWon);
            this.GameOverScene = new GameScene(this, planetExplodeBackground, gameOver);
            this.MenuScene = new GameScene(this, planetBackground, menu, menuItems);

            // disabling components
            foreach (GameComponent component in Components)
            {
                ChangeComponentState(component, false);
            }

            // window size
            this.graphics.PreferredBackBufferWidth = WindowWidth;
            this.graphics.PreferredBackBufferHeight = WindowHeight;
            this.graphics.GraphicsProfile = GraphicsProfile.Reach;
            this.graphics.IsFullScreen = false;
            this.graphics.ApplyChanges();

            base.Initialize();
        }

        // Resets the levelScene (where the game is played) when player wants to play again.
        public void NewGame()
        {
            PlayGameComponent level = new PlayGameComponent(this);
            ScrollingStarsBackgroundComponent starfield = new ScrollingStarsBackgroundComponent(this);
            this.LevelScene = new GameScene(this, starfield, level);
        }

        // Manages the components state for the scenes so that only enabled scenes show.
        private void ChangeComponentState(GameComponent component, bool enabled)
        {
            component.Enabled = enabled;
            if (component is DrawableGameComponent)
                ((DrawableGameComponent)component).Visible = enabled;
        }

        // Switches to new windows
        public void SwitchScene(GameScene scene)
        {
            GameComponent[] usedComponents = scene.ReturnComponents();
            foreach (GameComponent component in Components)
            {
                bool isUsed = usedComponents.Contains(component);
                ChangeComponentState(component, isUsed);
            }
            previousKeyboardState = keyboardState;
        }

        // Checks for the keys to not cause unwanted runoff when playing.
        public bool NewKey(Keys key)
        {
            return this.keyboardState.IsKeyDown(key) && this.previousKeyboardState.IsKeyUp(key);
        }

        protected override void LoadContent()
        {
            this.spriteBatch = new SpriteBatch(GraphicsDevice);

            // Assigns fancy font.
            this.FontOriginTech = this.Content.Load<SpriteFont>(@"Fonts\font_origin_tech");
            this.FontOriginTechSmall = this.Content.Load<SpriteFont>(@"Fonts\font_origin_tech_small");

            // Assigns music
            this.DeepSpace = Content.Load<Song>(@"Sounds\DeepSpace");
            this.Megalovania = Content.Load<Song>(@"Sounds\Megalovania");
            this.SolarSystem = Content.Load<Song>(@"Sounds\Solar System");
            
            SpriteLoader.Initialize(this.Content);
            
            // MediaPlayer volume set at 10%
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = 0.1f;

            ChangeMusic(this.SolarSystem);
            SwitchScene(this.MenuScene);
        }

        // Changes the music played
        public void ChangeMusic(Song song)
        {
            // Isn't the same song already playing?
            if (MediaPlayer.Queue.ActiveSong != song)
                MediaPlayer.Play(song);
        }

        protected override void Update(GameTime gameTime)
        {
            this.previousKeyboardState = this.keyboardState;
            this.keyboardState = Keyboard.GetState();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);
        }
    }
}
