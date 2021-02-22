// <copyright file="BossStateEnum.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.Enums
{
    /// <summary>
    /// Enums for boss states.
    /// </summary>
    internal enum BossStateEnum : int
    {
        Entering = 0,
        Idle = 1,
        Moving = 2,
        Dodging = 3,
        Charging = 4,
        Targetting = 5,

        // Movement patterns
        MovementPattern1 = 6,
        MovementPattern2 = 7,
        MovementPattern3 = 8,
        MovementPattern4 = 9,

        // Shooting patterns
        ShootingPattern1 = 10,
        ShootingPattern2 = 11,
        ShootingPattern3 = 12,
        ShootingPattern4 = 13
    }
}
