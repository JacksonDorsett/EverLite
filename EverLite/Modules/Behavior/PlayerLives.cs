// <copyright file="PlayerLives.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.Behavior
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    class PlayerLives
    {
        private int maxLives;
        private int currentLives;

        public PlayerLives(int startingLives)
        {
            this.maxLives = this.currentLives = startingLives;
        }

        public event EventHandler OnDeath;

        public int Lives { get => this.currentLives; }

        public void TakeDamage()
        {
            this.currentLives--;
            if (currentLives == 0)
            {
                this.OnDeath?.Invoke(this, new EventArgs());
            }
        }
    }
}
