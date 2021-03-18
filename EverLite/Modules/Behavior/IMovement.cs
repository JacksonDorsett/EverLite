// <copyright file="IMovement.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.Behavior
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.Xna.Framework;

    /// <summary>
    /// represents the movement path.
    /// </summary>
    public interface IMovement
    {
        /// <summary>
        /// Gets the position along the path based the owners lifetime percentage.
        /// 0 <= haldLife <= 1
        /// </summary>
        /// <param name="halfLife">Halflife represents the percentage an object is through its lifetime.</param>
        /// <returns>returns the position along the path.</returns>
        Vector2 GetPosition(double halfLife);

        float Angle(double halfLife);
    }
}
