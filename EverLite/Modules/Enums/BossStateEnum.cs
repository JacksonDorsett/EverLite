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
        Leaving = 6,

        // Movement patterns
        MovementPattern1 = 7,
        MovementPattern2 = 8,
        MovementPattern3 = 9,
        MovementPattern4 = 10,

        // Shooting patterns
        ShootingPattern1 = 11,
        ShootingPattern2 = 12,
        ShootingPattern3 = 13,
        ShootingPattern4 = 14
    }
}
