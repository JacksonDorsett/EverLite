namespace EverLite
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Manages the game logic for the GameWonScene.
    /// </summary>
    public class GameWonComponent : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private EverLite game;
        private List<string> alphabet1;
        private List<string> alphabet2;
        private List<string> alphabet3;
        private string letter1;
        private string letter2;
        private string letter3;
        private Color itemColor;
        private Color selectedItemColor;
        private ListName listName;
        private VolumeManager volume;

        /// <summary>
        /// Enum to cycle through the 3 alphabet lists used for the player's initials.
        /// </summary>
        enum ListName
        {
            letters1,
            letters2,
            letters3
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameWonComponent"/> class.
        /// </summary>
        /// <param name="game">game reference object.</param>
        public GameWonComponent(EverLite game) : base(game)
        {
            this.game = game;
            this.alphabet1 = this.alphabet2 = this.alphabet3 = new List<string> { "A", "B", "C", "D", "E", "F", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "!", "@", "#", "$" };
            this.itemColor = Color.Red;
            this.selectedItemColor = Color.Yellow;
            this.letter1 = this.letter2 = this.letter3 = "A";
            this.listName = ListName.letters1;
            this.volume = VolumeManager.Instance;
        }

        /// <inheritdoc/>
        public override void Draw(GameTime gameTime)
        {
            //this.game.score.AddTopScore(this.game.score.Score);
            this.game.spriteBatch.Begin();

            // Directions to leave screen.
            this.game.spriteBatch.DrawString(this.game.SceneManager.FontOriginTechSmall, "Press 'Enter' to", new Vector2(800, 600), Color.Yellow);
            this.game.spriteBatch.DrawString(this.game.SceneManager.FontOriginTechSmall, "return to main screen", new Vector2(850, 650), Color.Yellow);

            // Score stuff.
            this.game.spriteBatch.DrawString(this.game.SceneManager.FontOriginTech, "WINNER!", new Vector2(400, 150), Color.Red);
            this.game.spriteBatch.DrawString(this.game.SceneManager.FontOriginTechSmall, "SCORE - ", new Vector2(400, 210), Color.Yellow);
            this.game.spriteBatch.DrawString(this.game.SceneManager.FontOriginTechSmall, this.game.score.Score.ToString(), new Vector2(600, 210), Color.Yellow);

            // Player initials
            this.game.spriteBatch.DrawString(this.game.SceneManager.FontOriginTechSmall, "Player Initials", new Vector2(400, 300), Color.Red);
            this.game.spriteBatch.DrawString(this.game.SceneManager.FontOriginTechSmall, this.letter1, new Vector2(400, 350), colorStatus(ListName.letters1));
            this.game.spriteBatch.DrawString(this.game.SceneManager.FontOriginTechSmall, this.letter2, new Vector2(440, 350), colorStatus(ListName.letters2));
            this.game.spriteBatch.DrawString(this.game.SceneManager.FontOriginTechSmall, this.letter3, new Vector2(480, 350), colorStatus(ListName.letters3));

            this.game.spriteBatch.End();
        }

        /// <inheritdoc/>
        public override void Update(GameTime gameTime)
        {
            if (game.NewKey(Keys.Enter))
            {
                this.game.score.AddPlayerInitials(playerInitials());
                this.game.score.AddToScoreList(this.game.score.Score);
                Task<bool> result = this.game.InsertHighScore();
                this.game.score.Reset();
                this.game.SceneManager.ChangeMusic(this.game.SceneManager.MenuBG);
                this.game.SceneManager.SwitchScene(this.game.SceneManager.Menu);
            }

            if (game.NewKey(Keys.Up) || this.game.NewKey(this.game.playerSettings.MoveUp))
                SelectUp(this.listName);
            if (game.NewKey(Keys.Down) || this.game.NewKey(this.game.playerSettings.MoveDown))
                SelectDown(this.listName);
            if (game.NewKey(Keys.Left) || this.game.NewKey(this.game.playerSettings.MoveLeft))
                SelectLeft(this.listName);
            if (game.NewKey(Keys.Right) || this.game.NewKey(this.game.playerSettings.MoveRight))
                SelectRight(this.listName);

            // Volume control
            if (Keyboard.GetState().IsKeyDown(Keys.OemPlus))
                this.volume.VolumeUp();
            if (Keyboard.GetState().IsKeyDown(Keys.OemMinus))
                this.volume.VolumeDown();
            if (this.game.NewKey(Keys.D0))
                this.volume.Mute();

            base.Update(gameTime);
        }

        /// <summary>
        /// Used by the player initial to show which initial can be changed.
        /// </summary>
        /// <param name="name">Name of active initial list.</param>
        /// <returns>Appropriate Color choice.</returns>
        private Color colorStatus(ListName name)
        {
            if (this.listName == name)
                return this.selectedItemColor;
            return this.itemColor;
        }

        /// <summary>
        /// Takes the selected initials from each list and returns a string.
        /// </summary>
        /// <returns>String 3 initials.</returns>
        private string playerInitials()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.letter1);
            builder.Append(this.letter2);
            builder.Append(this.letter3);
            return builder.ToString();
        }

        /// <summary>
        /// Cycles through the alphabet of the active list.
        /// </summary>
        /// <param name="name">Name of active initial list.</param>
        private void SelectUp(ListName name)
        {
            ListName l = name;
            if (l == ListName.letters1)
            {
                int index = this.alphabet1.IndexOf(this.letter1);
                if (index > 0)
                    this.letter1 = this.alphabet1[index - 1];
                else
                    this.letter1 = this.alphabet1[this.alphabet1.Count - 1];
            }
            if (l == ListName.letters2)
            {
                int index = this.alphabet2.IndexOf(this.letter2);
                if (index > 0)
                    this.letter2 = this.alphabet2[index - 1];
                else
                    this.letter2 = this.alphabet2[this.alphabet2.Count - 1];
            }
            if (l == ListName.letters3)
            {
                int index = this.alphabet3.IndexOf(this.letter3);
                if (index > 0)
                    this.letter3 = this.alphabet3[index - 1];
                else
                    this.letter3 = this.alphabet3[this.alphabet3.Count - 1];
            }
        }

        /// <summary>
        /// Cycles through the alphabet of the active list.
        /// </summary>
        /// <param name="name">Name of active initial list.</param>
        private void SelectDown(ListName name)
        {
            ListName l = name;
            if (l == ListName.letters1)
            {
                int index = this.alphabet1.IndexOf(this.letter1);
                if (index < this.alphabet1.Count - 1)
                    this.letter1 = this.alphabet1[index + 1];
                else
                    this.letter1 = this.alphabet1[0];
            }
            if (l == ListName.letters2)
            {
                int index = this.alphabet2.IndexOf(this.letter2);
                if (index < this.alphabet2.Count - 1)
                    this.letter2 = this.alphabet2[index + 1];
                else
                    this.letter2 = this.alphabet2[0];
            }
            if (l == ListName.letters3)
            {
                int index = this.alphabet3.IndexOf(this.letter3);
                if (index < this.alphabet3.Count - 1)
                    this.letter3 = this.alphabet3[index + 1];
                else
                    this.letter3 = this.alphabet3[0];
            }
        }

        /// <summary>
        /// Switches active list.
        /// </summary>
        /// <param name="name">Name of active initial list.</param>
        private void SelectLeft(ListName name)
        {
            ListName l = name;
            if (l == ListName.letters1)
                this.listName = ListName.letters3;
            if (l == ListName.letters2)
                this.listName = ListName.letters1;
            if (l == ListName.letters3)
                this.listName = ListName.letters2;
        }

        /// <summary>
        /// Switches active list.
        /// </summary>
        /// <param name="name">Name of active initial list.</param>
        private void SelectRight(ListName name)
        {
            ListName l = name;
            if (l == ListName.letters1)
                this.listName = ListName.letters2;
            if (l == ListName.letters2)
                this.listName = ListName.letters3;
            if (l == ListName.letters3)
                this.listName = ListName.letters1;
        }
    }
}
