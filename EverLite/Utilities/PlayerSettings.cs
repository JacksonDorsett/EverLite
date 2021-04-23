namespace EverLite
{
    using Microsoft.Xna.Framework.Input;

    /// <summary>
    /// Class holds the mapped button controls for the player.
    /// </summary>
    public class PlayerSettings
    {`
        public PlayerSettings()
        {
        }

        /// <summary>
        /// Gets or sets the Shoot command.
        /// </summary>
        public Keys Shoot { get; set; } = Keys.J;

        /// <summary>
        /// Gets or sets the SlowSpeed command.
        /// </summary>
        public Keys SlowSpeed { get; set; } = Keys.G;

        /// <summary>
        /// Gets or sets the MoveLeft command.
        /// </summary>
        public Keys MoveLeft { get; set; } = Keys.A;

        /// <summary>
        /// Gets or sets the MoveRight command.
        /// </summary>
        public Keys MoveRight { get; set; } = Keys.D;

        /// <summary>
        /// Gets or sets the MoveUp command.
        /// </summary>
        public Keys MoveUp { get; set; } = Keys.W;

        /// <summary>
        /// Gets or sets the MoveDown command.
        /// </summary>
        public Keys MoveDown { get; set; } = Keys.S;

        /// <summary>
        /// Gets or sets the Pause command.
        /// </summary>
        public Keys Pause { get; set; } = Keys.Space;

        /// <summary>
        /// Gets or sets the Menu command.
        /// </summary>
        public Keys Menu { get; set; } = Keys.M;

        /// <summary>
        /// Gets or sets the switch weapon command.
        /// </summary>
        public Keys SwitchWeapon { get; set; } = Keys.T;
    }
}
