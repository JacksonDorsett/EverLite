// <copyright file="QuitCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.Menu.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Command to quit the game.
    /// </summary>
    internal class QuitCommand : MenuCommand
    {
        private Game mGame;

        /// <summary>
        /// Initializes a new instance of the <see cref="QuitCommand"/> class.
        /// </summary>
        /// <param name="game">Game to quit.</param>
        public QuitCommand(Game game)
        {
            mGame = game;
        }

        /// <summary>
        /// Executes quit command on game.
        /// </summary>
        public override void Execute()
        {
            mGame.Exit();
        }
    }
}
