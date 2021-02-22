// <copyright file="ChangeStateCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Changes the state.
    /// </summary>
    public class ChangeStateCommand : MenuCommand
    {
        private GameState state;
        private Game1 game;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeStateCommand"/> class.
        /// </summary>
        /// <param name="game">context for game.</param>
        /// <param name="state">the next state.</param>
        public ChangeStateCommand(Game1 game, GameState state)
        {
            this.game = game;
            this.state = state;
        }

        /// <summary>
        /// changes the state.
        /// </summary>
        public override void Execute()
        {
            this.game.StateContext.SetState(this.state);
        }
    }
}
