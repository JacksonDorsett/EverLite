using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace EverLite
{
    /// <summary>
    /// Updates the status for if the game is paused or not.
    /// </summary>
    public class PauseStatus
    {
        private KeyboardState prevState;
        private bool mStatus;
        private Keys pauseKey;

        /// <summary>
        /// Initializes a new instance of the <see cref="PauseStatus"/> class.
        /// </summary>
        /// <param name="pauseKey">selected key to pause the system.</param>
        public PauseStatus(Keys pauseKey)
        {
            this.mStatus = false;
            this.pauseKey = pauseKey;
        }

        /// <summary>
        /// Gets a value indicating whether the system is paused or not.
        /// </summary>
        public bool IsPaused
        {
            get
            {
                return this.mStatus;
            }
        }

        /// <summary>
        /// Updates the keystate and switches if pause is selected.
        /// </summary>
        public void Update()
        {
            if (Keyboard.GetState().IsKeyDown(this.pauseKey) && !this.prevState.IsKeyDown(this.pauseKey))
            {
                this.mStatus = !this.mStatus;
            }

            this.prevState = Keyboard.GetState();
        }

    }
}
