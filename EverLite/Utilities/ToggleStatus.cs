namespace EverLite
{
    using Microsoft.Xna.Framework.Input;

    /// <summary>
    /// Updates the status for if the game is paused or not.
    /// </summary>
    public class ToggleStatus
    {
        private KeyboardState prevState;
        private bool mStatus;
        private Keys pauseKey;

        /// <summary>
        /// Initializes a new instance of the <see cref="ToggleStatus"/> class.
        /// </summary>
        /// <param name="pauseKey">selected key to pause the system.</param>
        public ToggleStatus(Keys pauseKey)
        {
            mStatus = false;
            this.pauseKey = pauseKey;
        }

        /// <summary>
        /// Gets a value indicating whether the system is paused or not.
        /// </summary>
        public bool Status
        {
            get
            {
                return mStatus;
            }
        }

        /// <summary>
        /// Updates the keystate and switches if pause is selected.
        /// </summary>
        public void Update()
        {
            if (Keyboard.GetState().IsKeyDown(pauseKey) && !prevState.IsKeyDown(pauseKey))
            {
                mStatus = !mStatus;
            }

            prevState = Keyboard.GetState();
        }
    }
}
