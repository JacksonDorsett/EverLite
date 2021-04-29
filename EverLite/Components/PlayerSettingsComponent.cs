namespace EverLite
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    using System.Collections.Generic;

    /// <summary>
    /// Manages the player setting logic for the PlayerSettingsScene.
    /// </summary>
    public class PlayerSettingsComponent : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private EverLite game;
        private List<string> controlList;
        private PlayerSettings playerSettings;
        private Color itemColor;
        private Color selectedItemColor;
        private string selectedControl;
        private KeyboardState keyboardState;
        private KeyboardState previousKeyboardState;
        private eGameState gameState;
        
        enum eGameState
        {
            Playing,
            Pause,
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerSettingsComponent"/> class.
        /// </summary>
        /// <param name="game">game reference object.</param>
        public PlayerSettingsComponent(EverLite game) 
            : base(game)
        {
            this.game = game;
            this.playerSettings = PlayerSettings.Instance;
            this.controlList = new List<string> { "Move Up:", "Move Left:", "Move Down:", "Move Right:", "Shoot:", "Slow Down:", "Change Weapon:", "Pause:" };
            this.itemColor = Color.Red;
            this.selectedItemColor = Color.Yellow;
            this.selectedControl = "Move Up:";
        }

        /// <inheritdoc/>
        public override void Initialize()
        {
            this.gameState = eGameState.Playing;
            base.Initialize();
        }

        /// <inheritdoc/>
        public override void Update(GameTime gameTime)
        {
            this.previousKeyboardState = this.keyboardState;
            this.keyboardState = Keyboard.GetState();

            // This section is for selecting which player setting the user wants to change.
            if (this.gameState == eGameState.Playing)
            {
                if (this.game.NewKey(Keys.Escape))
                    this.game.SceneManager.SwitchScene(this.game.SceneManager.Menu);

                if (this.game.NewKey(Keys.Up))
                    SelectPrevious();
                if (this.game.NewKey(Keys.Down))
                    SelectNext();

                if (this.game.NewKey(Keys.Enter))
                    this.gameState = eGameState.Pause;
            }

            // This sections is for changing the selected player setting to new key.
            if (this.gameState == eGameState.Pause)
            {
                bool success = false;

                if (this.game.NewKey(GetKey(this.keyboardState)))
                {
                    success = this.SetPlayerSetting(this.selectedControl, GetKey(this.keyboardState));
                }

                if (success)
                {
                    this.gameState = eGameState.Playing;
                }
            }

            base.Update(gameTime);
        }

        /// <inheritdoc/>
        public override void Draw(GameTime gameTime)
        {
            this.game.spriteBatch.Begin();

            // Player settings for mapping.
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, this.controlList[0], new Vector2(100, 100), colorStatus("Move Up:"));
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, this.playerSettings.MoveUp.ToString(), new Vector2(500, 100), colorStatus("Move Up:"));
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, this.controlList[1], new Vector2(100, 200), colorStatus("Move Left:"));
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, this.playerSettings.MoveLeft.ToString(), new Vector2(500, 200), colorStatus("Move Left:"));
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, this.controlList[2], new Vector2(100, 300), colorStatus("Move Down:"));
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, this.playerSettings.MoveDown.ToString(), new Vector2(500, 300), colorStatus("Move Down:"));
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, this.controlList[3], new Vector2(100, 400), colorStatus("Move Right:"));
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, this.playerSettings.MoveRight.ToString(), new Vector2(500, 400), colorStatus("Move Right:"));
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, this.controlList[4], new Vector2(100, 500), colorStatus("Shoot:"));
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, this.playerSettings.Shoot.ToString(), new Vector2(500, 500), colorStatus("Shoot:"));
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, this.controlList[5], new Vector2(100, 600), colorStatus("Slow Down:"));
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, this.playerSettings.SlowSpeed.ToString(), new Vector2(500, 600), colorStatus("Slow Down:"));
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, this.controlList[6], new Vector2(100, 700), colorStatus("Change Weapon:"));
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, this.playerSettings.SwitchWeapon.ToString(), new Vector2(500, 700), colorStatus("Change Weapon:"));
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, this.controlList[7], new Vector2(100, 800), colorStatus("Pause:"));
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, this.playerSettings.Pause.ToString(), new Vector2(500, 800), colorStatus("Pause:"));

            // Instructions
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, "Press Up or Down to select", new Vector2(900, 250), Color.Yellow);
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, "setting you want to change.", new Vector2(950, 300), Color.Yellow);
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, "Press 'Enter' once, then", new Vector2(900, 450), Color.MediumVioletRed);
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, "press key you want mapped.", new Vector2(950, 500), Color.MediumVioletRed);
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, "(letters, arrow keys,", new Vector2(950, 550), Color.MediumVioletRed);
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, " control, shift, spacebar)", new Vector2(960, 600), Color.MediumVioletRed);
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, "Press 'Esc' to", new Vector2(1350, 850), Color.DeepSkyBlue);
            this.game.spriteBatch.DrawString(this.game.FontOriginTechSmall, "return to main screen", new Vector2(1200, 900), Color.DeepSkyBlue);

            this.game.spriteBatch.End();
            base.Draw(gameTime);
        }

        /// <inheritdoc/>
        protected override void LoadContent()
        {
            base.LoadContent();
        }

        /// <summary>
        /// Returns a key value that matches the user's choice.
        /// </summary>
        /// <param name="k">User input.</param>
        /// <returns>Chosen Key.</returns>
        private Keys GetKey(KeyboardState k)
        {
            if (k.IsKeyDown(Keys.A))
                return Keys.A;
            if (k.IsKeyDown(Keys.B))
                return Keys.B;
            if (k.IsKeyDown(Keys.C))
                return Keys.C;
            if (k.IsKeyDown(Keys.D))
                return Keys.D;
            if (k.IsKeyDown(Keys.E))
                return Keys.E;
            if (k.IsKeyDown(Keys.F))
                return Keys.F;
            if (k.IsKeyDown(Keys.G))
                return Keys.G;
            if (k.IsKeyDown(Keys.H))
                return Keys.H;
            if (k.IsKeyDown(Keys.I))
                return Keys.I;
            if (k.IsKeyDown(Keys.J))
                return Keys.J;
            if (k.IsKeyDown(Keys.K))
                return Keys.K;
            if (k.IsKeyDown(Keys.L))
                return Keys.L;
            if (k.IsKeyDown(Keys.M))
                return Keys.M;
            if (k.IsKeyDown(Keys.N))
                return Keys.N;
            if (k.IsKeyDown(Keys.O))
                return Keys.O;
            if (k.IsKeyDown(Keys.P))
                return Keys.P;
            if (k.IsKeyDown(Keys.Q))
                return Keys.Q;
            if (k.IsKeyDown(Keys.R))
                return Keys.R;
            if (k.IsKeyDown(Keys.S))
                return Keys.S;
            if (k.IsKeyDown(Keys.T))
                return Keys.T;
            if (k.IsKeyDown(Keys.U))
                return Keys.U;
            if (k.IsKeyDown(Keys.V))
                return Keys.V;
            if (k.IsKeyDown(Keys.W))
                return Keys.W;
            if (k.IsKeyDown(Keys.X))
                return Keys.X;
            if (k.IsKeyDown(Keys.Y))
                return Keys.Y;
            if (k.IsKeyDown(Keys.Z))
                return Keys.Z;
            if (k.IsKeyDown(Keys.Up))
                return Keys.Up;
            if (k.IsKeyDown(Keys.Down))
                return Keys.Down;
            if (k.IsKeyDown(Keys.Left))
                return Keys.Left;
            if (k.IsKeyDown(Keys.Right))
                return Keys.Right;
            if (k.IsKeyDown(Keys.LeftShift))
                return Keys.LeftShift;
            if (k.IsKeyDown(Keys.RightShift))
                return Keys.RightShift;
            if (k.IsKeyDown(Keys.LeftControl))
                return Keys.LeftControl;
            if (k.IsKeyDown(Keys.RightControl))
                return Keys.RightControl;
            if (k.IsKeyDown(Keys.Space))
                return Keys.Space;
            return Keys.OemTilde;
        }

        /// <summary>
        /// Sets the highlighted command to user's preference.
        /// </summary>
        /// <param name="choice">Command to be changed.</param>
        /// <param name="k">New key to mapped command.</param>
        /// <returns>T or F on success.</returns>
        private bool SetPlayerSetting(string choice, Keys k)
        {
            switch(choice)
            {
                case "Move Up:":
                    if (k != Keys.OemTilde)
                    {
                        this.playerSettings.MoveUp = k;
                        return true;
                    }
                    return false;
                case "Move Left:":
                    if (k != Keys.OemTilde)
                    {
                        this.playerSettings.MoveLeft = k;
                        return true;
                    }
                    return false;
                case "Move Down:":
                    if (k != Keys.OemTilde)
                    {
                        this.playerSettings.MoveDown = k;
                        return true;
                    }
                    return false;
                case "Move Right:":
                    if (k != Keys.OemTilde)
                    {
                        this.playerSettings.MoveRight = k;
                        return true;
                    }
                    return false;
                case "Shoot:":
                    if (k != Keys.OemTilde)
                    {
                        this.playerSettings.Shoot = k;
                        return true;
                    }
                    return false;
                case "Slow Down:":
                    if (k != Keys.OemTilde)
                    {
                        this.playerSettings.SlowSpeed = k;
                        return true;
                    }
                    return false;
                case "Change Weapon:":
                    if (k != Keys.OemTilde)
                    {
                        this.playerSettings.SwitchWeapon = k;
                        return true;
                    }
                    return false;
                case "Pause:":
                    if (k != Keys.OemTilde)
                    {
                        this.playerSettings.Pause = k;
                        return true;
                    }
                    return false;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Used by the player initial to show which initial can be changed.
        /// </summary>
        /// <param name="name">Name of active initial list.</param>
        /// <returns>Appropriate Color choice.</returns>
        private Color colorStatus(string name)
        {
            if (this.selectedControl == name)
                return this.selectedItemColor;
            return this.itemColor;
        }

        /// <summary>
        /// Cycles through the menuOptions.
        /// </summary>
        private void SelectNext()
        {
            int index = controlList.IndexOf(selectedControl);
            if (index < controlList.Count - 1)
                selectedControl = controlList[index + 1];
            else
                selectedControl = controlList[0];
        }

        /// <summary>
        /// Cycles through the menuOptions.
        /// </summary>
        private void SelectPrevious()
        {
            int index = controlList.IndexOf(selectedControl);
            if (index > 0)
                selectedControl = controlList[index - 1];
            else
                selectedControl = controlList[controlList.Count - 1];
        }
    }
}
