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
        private List<MenuItem> menuOptions;
        private int mSelectedIndex;
        private bool isKeyDown;

        /// <summary>
        /// Initializes a new instance of the <see cref="Menu"/> class.
        /// </summary>
        public Menu()
        {
            mSelectedIndex = 0;
            menuOptions = new List<MenuItem>();
            isKeyDown = false;
        }

        /// <summary>
        /// Updates the menu logic.
        /// </summary>
        /// <param name="gameTime">Gametime passed.</param>
        public void Update()
        {
            if (menuOptions.Count != 0 && !isKeyDown)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Down) && mSelectedIndex < menuOptions.Count - 1)
                {
                    mSelectedIndex++;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Up) && mSelectedIndex > 0)
                {
                    mSelectedIndex--;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    menuOptions[mSelectedIndex].Select();
                }

                isKeyDown = true;
            }

            if (!Keyboard.GetState().IsKeyDown(Keys.Down) && !Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                isKeyDown = false;
            }
        }

        /// <summary>
        /// Draws the menu.
        /// </summary>
        /// <param name="spriteBatch">Sprite Batch.</param>
        /// <param name="font">Font of menu.</param>
        public void Draw(SpriteBatch spriteBatch, SpriteFont font)
        {
            for (int i = 0; i < menuOptions.Count; i++)
            {
                Color c;
                if (i != mSelectedIndex)
                {
                    c = Color.Red;
                }
                else
                {
                    c = Color.White;
                }

                spriteBatch.DrawString(font, menuOptions[i].Name, new Vector2(100, 100 + i * 100), c);
            }
        }

        /// <summary>
        /// Adds menu item to the menu.
        /// </summary>
        /// <param name="item">item added.</param>
        public void AddMenuItem(MenuItem item)
        {
            menuOptions.Add(item);
        }
    }
}
