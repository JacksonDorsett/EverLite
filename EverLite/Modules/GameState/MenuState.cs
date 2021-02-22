﻿// <copyright file="MenuState.cs" company="PlaceholderCompany">
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
        private string[] menuOptions;
        private SpriteFont mFont;
        private Menu menu;

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuState"/> class.
        /// </summary>
        /// <param name="game">Game context object.</param>
        public MenuState(Game1 game)
            : base(game)
        {
            this.menuOptions = new string[2];
            this.mFont = this.Game.Content.Load<SpriteFont>("Default");
            this.InitMenu();
        }

        /// <summary>
        /// Draws the menu.
        /// </summary>
        /// <param name="gameTime">Time elapsed in cycle.</param>
        public override void Draw(GameTime gameTime)
        {
            this.SpriteBatch.Begin();
            this.menu.Draw(this.SpriteBatch, this.mFont);
            this.SpriteBatch.End();
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
            this.menu.Update();
        }

        /// <summary>
        /// Called on destruction.
        /// </summary>
        protected override void OnExit()
        {
        }

        private void InitMenu()
        {
            // Add any menu options here.
            this.menu = new Menu();
            this.menu.AddMenuItem(new MenuItem("Play", new ChangeStateCommand(this.Game, new PlayGameState(this.Game))));
            this.menu.AddMenuItem(new MenuItem("Test", new QuitCommand(this.Game)));
            this.menu.AddMenuItem(new MenuItem("Quit", new QuitCommand(this.Game)));
        }
    }
}