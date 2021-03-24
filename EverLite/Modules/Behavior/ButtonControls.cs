// <copyright file="ButtonControls.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.Behavior
{
    using Microsoft.Xna.Framework.Input;

    /// <summary>
    /// Class holds the mapped button controls for the player.
    /// </summary>
    public class ButtonControls
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ButtonControls"/> class.
        /// </summary>
        public ButtonControls()
        {
            this.Shoot = Keys.D;
            this.SlowSpeed = Keys.F;
            this.MoveLeft = Keys.Left;
            this.MoveRight = Keys.Right;
            this.MoveUp = Keys.Up;
            this.MoveDown = Keys.Down;
            this.Pause = Keys.Space;
            this.Menu = Keys.M;

            this.PadSlowSpeed = Buttons.Y;
            this.PadPause = Buttons.Back;
            this.PadMenu = Buttons.Start;
        }

        /// <summary>
        /// Gets or sets the Shoot command.
        /// </summary>
        public Keys Shoot { get; set; }

        /// <summary>
        /// Gets or sets the SlowSpeed command.
        /// </summary>
        public Keys SlowSpeed { get; set; }

        /// <summary>
        /// Gets or sets the MoveLeft command.
        /// </summary>
        public Keys MoveLeft { get; set; }

        /// <summary>
        /// Gets or sets the MoveRight command.
        /// </summary>
        public Keys MoveRight { get; set; }

        /// <summary>
        /// Gets or sets the MoveUp command.
        /// </summary>
        public Keys MoveUp { get; set; }

        /// <summary>
        /// Gets or sets the MoveDown command.
        /// </summary>
        public Keys MoveDown { get; set; }

        /// <summary>
        /// Gets or sets the Pause command.
        /// </summary>
        public Keys Pause { get; set; }

        /// <summary>
        /// Gets or sets the Menu command.
        /// </summary>
        public Keys Menu { get; set; }

        /// <summary>
        /// Gets or sets the PadSlowSpeed command.
        /// </summary>
        public Buttons PadSlowSpeed { get; set; }

        /// <summary>
        /// Gets or sets the PadMenu command.
        /// </summary>
        public Buttons PadMenu { get; set; }

        /// <summary>
        /// Gets or sets the PadPause command.
        /// </summary>
        public Buttons PadPause { get; set; }
    }
}
