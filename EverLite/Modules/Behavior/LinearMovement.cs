

namespace EverLite.Modules.Behavior
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Represents a linear movement path.
    /// </summary>
    public class LinearMovement : IMovement
    {
        private Vector2 mInitialPos;
        private Vector2 diff;

        /// <summary>
        /// Initializes a new instance of the <see cref="LinearMovement"/> class.
        /// </summary>
        /// <param name="initialPos">Initial Position of path.</param>
        /// <param name="finalPos">Final position of path.</param>
        public LinearMovement(Vector2 initialPos, Vector2 finalPos)
        {
            this.mInitialPos = initialPos;
            this.diff = finalPos - initialPos;
        }

        // inheritdoc
        public Vector2 GetPosition(double halfLife)
        {
            return this.mInitialPos + ((float)halfLife * this.diff);
        }
    }
}
