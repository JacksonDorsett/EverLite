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
        public SpriteBatch spriteBatch;
        public KeyboardState keyboardState;
        private KeyboardState previousKeyboardState;
        private GraphicsDeviceManager graphics;

        /// <summary>
        /// Initializes a new instance of the <see cref="EverLite"/> class.
        /// </summary>
        public EverLite()
        {
            this.graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            this.score = GameScore.Instance;
            this.playerSettings = PlayerSettings.Instance;
            this.highScores = new HighScoreDataStore();
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
        /// Initializes the local highscore list.
        /// </summary>
        protected async void InitializeSql()
        {
            Task<bool> result;
            List<HighScore> scores = await highScores.GetAsync(false);
            if(scores.Count <= 0)
            {
                scores = await highScores.GetAsync(false);
            }
            List<HighScore> sorted = scores.OrderByDescending(o => o.Score).ToList();

            this.score.GetSqlData(sorted);
        }

        /// <inheritdoc/>
        protected override void Initialize()
        {
            SpriteLoader.Initialize(this.Content);
            this.InitializeSql();

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

            SpriteLoader.Initialize(this.Content);
            
            MediaPlayer.IsRepeating = true;

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
