// <copyright file="MenuState.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    /// <summary>
    /// Represents when the game is in the main menu.
    /// </summary>
    internal class MenuState : GameState
    {
        private int mSelectedIndex = 0;
        private string[] menuOptions;
        private SpriteFont mFont;

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuState"/> class.
        /// </summary>
        /// <param name="game">Game context object.</param>
        public MenuState(Game1 game)
            : base(game)
        {
            this.menuOptions = new string[2];
            this.menuOptions[0] = "Play";
            this.menuOptions[1] = "Quit";
            this.mFont = this.Game.Content.Load<SpriteFont>("Default");
        }

        /// <summary>
        /// Draws the menu.
        /// </summary>
        /// <param name="gameTime">Time elapsed in cycle.</param>
        public override void Draw(GameTime gameTime)
        {
            this.SpriteBatch.Begin();
            for (int i = 0; i < this.menuOptions.Length; i++)
            {
                Color c;
                if (i != this.mSelectedIndex)
                {
                    c = Color.Red;
                }
                else
                {
                    c = Color.White;
                }

                this.SpriteBatch.DrawString(this.mFont, this.menuOptions[i], new Vector2(100, 100 + (i * 100)), c);
            }

            this.SpriteBatch.End();
        }

        /// <summary>
        /// Updates the menu.
        /// </summary>
        /// <param name="gameTime">Time elapsed during cycle.</param>
        public override void Update(GameTime gameTime)
        {
            // To Do: Refactor into menu item class, substitute conditional with polymorphism.
            if (Keyboard.GetState().IsKeyDown(Keys.Down) && this.mSelectedIndex < this.menuOptions.Length - 1)
            {
                this.mSelectedIndex++;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up) && this.mSelectedIndex > 0)
            {
                this.mSelectedIndex--;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Enter) && this.mSelectedIndex == 1)
            {
                this.Game.Exit();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Enter) && this.mSelectedIndex == 0)
            {
                this.StateContext.CurrentState = new PlayGameState(this.Game);
            }
        }
    }
}
