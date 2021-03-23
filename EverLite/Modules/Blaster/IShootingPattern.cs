// <copyright file="IShootingPattern.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.Blaster
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Shooting pattern interface.
    /// </summary>
    interface IShootingPattern
    {
        void Shoot(Vector2 position);
    }
}
