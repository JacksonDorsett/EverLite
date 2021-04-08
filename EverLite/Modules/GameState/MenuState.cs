// <copyright file="MenuState.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.GameState
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EverLite;
    using EverLite.Modules.Menu;
    using EverLite.Modules.Menu.Commands;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    /// <summary>
    /// Represents when the game is in the main menu.
    /// </summary>
    internal class MenuState : GameState
    {

        private SpriteFont mFont;
        private Menu menu;

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuState"/> class.
        /// </summary>
        /// <param name="game">Game context object.</param>
        public MenuState(Game1 game)
            : base(game)
        {
            mFont = Game.Content.Load<SpriteFont>("Default");
            InitMenu();
        }

        /// <summary>
        /// Draws the menu.
        /// </summary>
        /// <param name="gameTime">Time elapsed in cycle.</param>
        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin();
            menu.Draw(SpriteBatch, mFont);
            SpriteBatch.End();
        }

        /// <summary>
        /// Called on entering the state.
        /// </summary>
        public override void OnEnter()
        {
        }

        /// <summary>
        /// Updates the menu.
        /// </summary>
        /// <param name="gameTime">Time elapsed during cycle.</param>
        public override void Update(GameTime gameTime)
        {
            menu.Update();
        }

        /// <summary>
        /// Called on destruction.
        /// </summary>
        public override void OnExit()
        {
        }

        private void InitMenu()
        {
            // Add any menu options here.
            menu = new Menu();
            menu.AddMenuItem(new MenuItem("Play", new ChangeStateCommand(Game, new PlayGameState(Game))));
            menu.AddMenuItem(new MenuItem("Test", new QuitCommand(Game)));
            menu.AddMenuItem(new MenuItem("Quit", new QuitCommand(Game)));
        }
    }
}
