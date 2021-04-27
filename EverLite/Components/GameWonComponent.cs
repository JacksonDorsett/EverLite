namespace EverLite
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using System.Collections.Generic;
    using System.Text;

    public class GameWonComponent : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private EverLite game;
        PlayerSettings playerSettings;
        private List<string> letters1;
        private List<string> letters2;
        private List<string> letters3;
        private string letter1;
        private string letter2;
        private string letter3;
        //private string listName;
        private Color itemColor;
        private Color selectedItemColor;

        private ListName listName;

        enum ListName
        {
            letters1,
            letters2,
            letters3,
        }

        public GameWonComponent(EverLite game) : base(game)
        {
            this.game = game;
            this.playerSettings = PlayerSettings.Instance;
            this.letters1 = this.letters2 = this.letters3 = new List<string> { "A", "B", "C", "D", "E", "F", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "!", "@", "#", "$" };
            this.itemColor = Color.Red;
            this.selectedItemColor = Color.Blue;
            this.letter1 = "A"; 
            this.letter2 = "A"; 
            this.letter3 = "A";
            this.listName = ListName.letters3;
        }

        public void SelectUp()
        {
            if (listName == ListName.letters1)
            {
                int index = letters1.IndexOf(letter1);
                if (index > 0)
                    letter1 = letters1[index - 1];
                else
                    letter1 = letters1[letters1.Count - 1];
            }
            if (listName == ListName.letters2)
            {
                int index = letters2.IndexOf(letter2);
                if (index > 0)
                    letter2 = letters2[index - 1];
                else
                    letter2 = letters2[letters2.Count - 1];
            }
            if (listName == ListName.letters3)
            {
                int index = letters3.IndexOf(letter2);
                if (index > 0)
                    letter3 = letters3[index - 1];
                else
                    letter3 = letters3[letters3.Count - 1];
            }
        }

        public void SelectDown()
        {
            if (listName == ListName.letters1)
            {
                int index = letters1.IndexOf(letter1);
                if (index < letters1.Count - 1)
                    letter1 = letters1[index + 1];
                else
                    letter1 = letters1[0];
            }
            if (listName == ListName.letters2)
            {
                int index = letters2.IndexOf(letter2);
                if (index < letters2.Count - 1)
                    letter2 = letters2[index + 1];
                else
                    letter2 = letters2[0];
            }
            if (listName == ListName.letters3)
            {
                int index = letters3.IndexOf(letter3);
                if (index < letters3.Count - 1)
                    letter3 = letters3[index + 1];
                else
                    letter3 = letters3[0];
            }
        }

        public void SelectLeft()
        {
            if (this.listName == ListName.letters1)
                this.listName = ListName.letters3;
            if (this.listName == ListName.letters2)
                this.listName = ListName.letters1;
            if (this.listName == ListName.letters3)
                this.listName = ListName.letters2;
        }

        public void SelectRight()
        {
            if (this.listName == ListName.letters1)
                this.listName = ListName.letters2;
            if (this.listName == ListName.letters2)
                this.listName = ListName.letters3;
            if (this.listName == ListName.letters3)
                this.listName = ListName.letters1;
        }

        private Color colorStatus(ListName name)
        {
            if (this.listName == name)
                return this.selectedItemColor;
            return this.itemColor;
        }

        private string playerInitials()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.letter1);
            builder.Append(this.letter2);
            builder.Append(this.letter3);
            return builder.ToString();
        }

        public override void Draw(GameTime gameTime)
        {
            this.game.score.AddTopScore(this.game.score.Score);
            this.game.spriteBatch.Begin();

            // Directions to leave screen.
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, "Press 'Enter' to", new Vector2(800, 600), Color.Yellow);
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, "return to main screen", new Vector2(850, 650), Color.Yellow);

            // Score stuff.
            this.game.spriteBatch.DrawString(this.game.FontOriginTech, "WINNER!", new Vector2(400, 150), Color.Red);
            this.game.spriteBatch.DrawString(this.game.FontOriginTech, "SCORE ", new Vector2(400, 210), Color.Blue);
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, this.game.score.Score.ToString(), new Vector2(400, 260), Color.Yellow);

            // Player initials
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, this.letter1, new Vector2(600, 100), colorStatus(ListName.letters1));
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, this.letter2, new Vector2(640, 100), colorStatus(ListName.letters2));
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, this.letter3, new Vector2(680, 100), colorStatus(ListName.letters3));

            this.game.spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            // key pressing
            if (game.NewKey(Keys.Enter))
            {
                //this.game.score.Reset();
                this.game.score.AddPlayerInitials(playerInitials());
                this.game.SceneManager.ChangeMusic(this.game.SolarSystem);
                this.game.SceneManager.SwitchScene(this.game.SceneManager.Menu);
            }

            if (game.NewKey(Keys.Up))
                SelectUp();
            if (game.NewKey(Keys.Down))
                SelectDown();
            if (game.NewKey(Keys.Left))
                SelectLeft();
            if (game.NewKey(Keys.Right))
                SelectRight();

            base.Update(gameTime);
        }
    }
}
