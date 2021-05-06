namespace EverLite
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    using System.Threading.Tasks;

    /// <summary>
    /// Manages the TopTenComponent for the TopTenScene.
    /// </summary>
    public class TopTenComponent : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private EverLite game;
        private VolumeManager volume;
        private SoundManager sound;

        /// <summary>
        /// Initializes a new instance of the <see cref="TopTenComponent"/> class.
        /// </summary>
        /// <param name="game">game reference object.</param>
        public TopTenComponent(EverLite game) 
            : base(game)
        {
            this.game = game;
            this.volume = VolumeManager.Instance;
            this.sound = SoundManager.Instance;
        }

        /// <inheritdoc/>
        public override void Initialize()
        {
            base.Initialize();
        }

        /// <inheritdoc/>
        public override void Update(GameTime gameTime)
        {
            if (game.NewKey(Keys.Enter))
            {
                this.sound.StartUpSound.Play(volume: volume.SoundLevel, pitch: 0.0f, pan: 0.0f);
                this.game.SceneManager.ChangeMusic(this.sound.MenuBG);
                this.game.SceneManager.SwitchScene(this.game.SceneManager.Menu);
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
        public async override void Draw(GameTime gameTime)
        {
            int position = 200;
            int count = 1;

            this.game.spriteBatch.Begin();

            this.game.spriteBatch.DrawString(this.game.SceneManager.FontOriginTech, "Top 10 Scores", new Vector2(80, 120), Color.DeepSkyBlue);
            
            foreach (HighScore s in this.game.score.GetScoreList())
            {
                this.game.spriteBatch.DrawString(this.game.SceneManager.FontOriginTech, s.Name, new Vector2(80, position), Color.Yellow);
                this.game.spriteBatch.DrawString(this.game.SceneManager.FontOriginTech, s.Score.ToString(), new Vector2(250, position), Color.Yellow);
                position += 70;
                count++;
                if (count > 10)
                    break;
            }

            this.game.spriteBatch.DrawString(this.game.SceneManager.FontOriginTechSmall, "Press 'Enter' to", new Vector2(900, 600), Color.Yellow);
            this.game.spriteBatch.DrawString(this.game.SceneManager.FontOriginTechSmall, "return to main screen", new Vector2(950, 650), Color.Yellow);
            //this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, "Press 'D' to reset", new Vector2(900, 700), Color.Red);
            //this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, "top scores.", new Vector2(950, 750), Color.Red);
            this.game.spriteBatch.End();
            base.Draw(gameTime);
        }

        /// <inheritdoc/>
        protected override void LoadContent()
        {
            base.LoadContent();
        }
    }
}
