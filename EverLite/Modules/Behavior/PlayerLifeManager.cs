// <copyright file="PlayerLifeManager.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.Behavior
{
    using EverLite.Modules.Sprites;
    using System;
    using System.Collections.Generic;
    using System.Text;

    class PlayerLifeManager
    {
        private PlayerLives lives;
        private Player player;

        public PlayerLifeManager()
        {
            this.lives = new PlayerLives(5);
            this.player = Player.Instance();
        }
    }
}
