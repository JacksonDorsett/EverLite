// <copyright file="Menu.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite
{
    /// <summary>
    /// Represents a single menu option.
    /// </summary>
    public class MenuItem
    {
        private ICommand mCommand;
        private string mName;

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuItem"/> class.
        /// </summary>
        /// <param name="name">name of the menu option.</param>
        /// <param name="command">command executed when selected.</param>
        public MenuItem(string name, MenuCommand command)
        {
            this.mCommand = command;
            this.mName = name;
        }

        /// <summary>
        /// Gets name of menu item.
        /// </summary>
        public string Name
        {
            get
            {
                return this.mName;
            }
        }

        /// <summary>
        /// Runs the given command when selected.
        /// </summary>
        public void Select()
        {
            this.mCommand.Execute();
        }
    }
}