// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite
{
    using System;

    /// <summary>
    /// Main program running game object.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Main function calling game object.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            using (var game = new Game1())
            {
                game.Run();
            }
        }
    }
}
