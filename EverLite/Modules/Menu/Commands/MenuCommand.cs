// <copyright file="MenuCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.Menu.Commands
{
    /// <summary>
    /// Abstract base class for menu command.
    /// </summary>
    public abstract class MenuCommand : ICommand
    {
        /// <summary>
        /// Command executed when menu item is selected.
        /// </summary>
        public abstract void Execute();
    }
}