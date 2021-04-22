// <copyright file="Menu.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.Menu
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    /// <summary>
    /// Represents a menu.
    /// </summary>
    public class Menu
    {
        private KeyboardState keyboardState;
        private KeyboardState previousKeyboardState;

        private List<MenuItem> menuOptions;
        private int mSelectedIndex;

        /// <summary>
        /// Initializes a new instance of the <see cref="Menu"/> class.
        /// </summary>
        public Menu()
        {
            this.mSelectedIndex = 0;
            this.menuOptions = new List<MenuItem>();
        }

        /// <summary>
        /// Selects the next menu option.
        /// </summary>
        public void SelectNext()
        {
            if (this.mSelectedIndex < this.menuOptions.Count - 1)
                this.mSelectedIndex++;
        }

        /// <summary>
        /// Selects previous menu option.
        /// </summary>
        public void SelectPrevious()
        {
            if (this.mSelectedIndex > 0)
                this.mSelectedIndex--;
        }

        /// <summary>
        /// Checks the key and previous key status.
        /// </summary>
        /// <param name="key">Key state.</param>
        /// <returns>True or False.</returns>
        public bool NewKey(Keys key)
        {
            return this.keyboardState.IsKeyDown(key) && this.previousKeyboardState.IsKeyUp(key);
        }

        /// <summary>
        /// Updates the menu logic.
        /// </summary>
        /// <param name="gameTime">Gametime passed.</param>
        public void Update()
        {
            // keyboard state
            this.previousKeyboardState = this.keyboardState;
            this.keyboardState = Keyboard.GetState();

            if (this.menuOptions.Count != 0)
            {
                if (this.NewKey(Keys.Down))
                    this.SelectNext();

                if (this.NewKey(Keys.Up))
                    this.SelectPrevious();

                if (this.NewKey(Keys.Enter))
                    this.menuOptions[this.mSelectedIndex].Select();
            }
        }

        /// <summary>
        /// Draws the menu.
        /// </summary>
        /// <param name="spriteBatch">Sprite Batch.</param>
        /// <param name="font">Font of menu.</param>
        public void Draw(SpriteBatch spriteBatch, SpriteFont font)
        {
            for (int i = 0; i < this.menuOptions.Count; i++)
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

                spriteBatch.DrawString(font, this.menuOptions[i].Name, new Vector2(100, 100 + (i * 100)), c);
            }
        }

        /// <summary>
        /// Adds menu item to the menu.
        /// </summary>
        /// <param name="item">item added.</param>
        public void AddMenuItem(MenuItem item)
        {
            this.menuOptions.Add(item);
        }
    }
}
