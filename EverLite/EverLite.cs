namespace EverLite
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Microsoft.Xna.Framework.Media;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class EverLite : Game
    {
        public HighScoreDataStore highScores;
        public PlayerSettings playerSettings;
        public GameScore score;
        public int WindowWidth = 1920;
        public int WindowHeight = 1000;

        public SpriteFont FontOriginTech;
        public SpriteFont FontOriginTechSmall;
        public SpriteFont FontOriginTechTiny;

        public Song DeepSpace;
        public Song Megalovania;
        public Song SolarSystem;

        private GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        
        // Needed to check for NewKey()
        public KeyboardState keyboardState;
        private KeyboardState previousKeyboardState;

        /// <summary>
        /// Initializes a new instance of the <see cref="EverLite"/> class.
        /// </summary>
        public EverLite()
        {
            Task<bool> result;
            this.graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            this.score = GameScore.Instance;
            this.playerSettings = PlayerSettings.Instance;
            this.highScores = new HighScoreDataStore();
            if (this.score.GetScoreList().Count <= 0)
                result = InsertData();// Only run this once
        }

        public SceneManager SceneManager { get; private set; }

        /// <summary>
        /// Checks key input to prevent repeat from holding down key too long.
        /// </summary>
        /// <param name="key">Key type.</param>
        /// <returns>T or F.</returns>
        public bool NewKey(Keys key)
        {
            return this.keyboardState.IsKeyDown(key) && this.previousKeyboardState.IsKeyUp(key);
        }

        /// <summary>
        /// Inserts the new highscore to the DB.
        /// </summary>
        /// <returns></returns>
        public async Task<bool> InsertHighScore()
        {
            try
            {
                await highScores.AddAsync(new HighScore() { Id = this.score.HighScore.Id, Name = this.score.HighScore.Name, Score = this.score.HighScore.Score });
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Builds the initial high score database.
        /// </summary>
        /// <returns></returns>
        public async Task<bool> InsertData()
        {
            try
            {
                await highScores.AddAsync(new HighScore() { Id = 0, Name = "BOB", Score = 1000 });
                await highScores.AddAsync(new HighScore() { Id = 1, Name = "NOM", Score = 90 });
                await highScores.AddAsync(new HighScore() { Id = 2, Name = "NOM", Score = 80 });
                await highScores.AddAsync(new HighScore() { Id = 3, Name = "NOM", Score = 70 });
                await highScores.AddAsync(new HighScore() { Id = 4, Name = "WOW", Score = 60 });
                await highScores.AddAsync(new HighScore() { Id = 5, Name = "NOM", Score = 50 });
                await highScores.AddAsync(new HighScore() { Id = 6, Name = "NOM", Score = 40 });
                await highScores.AddAsync(new HighScore() { Id = 7, Name = "NOM", Score = 30 });
                await highScores.AddAsync(new HighScore() { Id = 8, Name = "NOM", Score = 20 });
                await highScores.AddAsync(new HighScore() { Id = 9, Name = "HUH", Score = 10 });
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Initializes the local highscore list.
        /// </summary>
        protected async void InitializeSql()
        {
            List<HighScore> scores = await highScores.GetAsync(false);
            List<HighScore> sorted = scores.OrderByDescending(o => o.Score).ToList();
            this.score.GetSqlData(scores);
        }

        /// <inheritdoc/>
        protected override void Initialize()
        {
            SpriteLoader.Initialize(this.Content);
            
            // window size
            this.graphics.PreferredBackBufferWidth = WindowWidth;
            this.graphics.PreferredBackBufferHeight = WindowHeight;
            this.graphics.GraphicsProfile = GraphicsProfile.Reach;
            this.graphics.IsFullScreen = false;
            this.graphics.ApplyChanges();
            this.SceneManager = new SceneManager(this);

            base.Initialize();
        }

        /// <inheritdoc/>
        protected override void LoadContent()
        {
            this.spriteBatch = new SpriteBatch(GraphicsDevice);

            // Assigns fancy font.
            this.FontOriginTech = this.Content.Load<SpriteFont>(@"Fonts\font_origin_tech");
            this.FontOriginTechSmall = this.Content.Load<SpriteFont>(@"Fonts\font_origin_tech_small");
            this.FontOriginTechTiny = this.Content.Load<SpriteFont>(@"Fonts\font_origin_tech_tiny");
            // Assigns music
            this.DeepSpace = Content.Load<Song>(@"Sounds\DeepSpace");
            this.Megalovania = Content.Load<Song>(@"Sounds\Megalovania");
            this.SolarSystem = Content.Load<Song>(@"Sounds\Solar System");
            this.InitializeSql();
            SpriteLoader.Initialize(this.Content);
            
            // MediaPlayer volume set at 10%
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = 0.0f;

            this.SceneManager.ChangeMusic(this.SolarSystem);
            this.SceneManager.SwitchScene(this.SceneManager.Menu);

        }

        /// <inheritdoc/>
        protected override void Update(GameTime gameTime)
        {
            this.previousKeyboardState = this.keyboardState;
            this.keyboardState = Keyboard.GetState();

            base.Update(gameTime);
        }

        /// <inheritdoc/>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);
        }
    }
}
