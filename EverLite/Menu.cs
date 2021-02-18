// <copyright file="Menu.cs" company="PlaceholderCompany">
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
    /// Represents a menu.
    /// </summary>
    public class Menu
    {
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
        /// Updates the menu logic.
        /// </summary>
        /// <param name="gameTime">Gametime passed.</param>
        public void Update()
        {
            if (this.menuOptions.Count != 0)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Down) && this.mSelectedIndex < this.menuOptions.Count - 1)
                {
                    this.mSelectedIndex++;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Up) && this.mSelectedIndex > 0)
                {
                    this.mSelectedIndex--;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    this.menuOptions[this.mSelectedIndex].Select();
                }
            }
        }

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
