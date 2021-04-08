// <copyright file="PlayerLifeManager.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.Behavior
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EverLite.Modules.Menu.Commands;
    using EverLite.Modules.Sprites;
    using Microsoft.Xna.Framework.Graphics;

    class PlayerLifeManager
    {
        private PlayerLives lives;
        private Player player;
        private PlayerLivesDisplay display;
        private ICommand commandOnDeath;
        public PlayerLifeManager(ICommand command)
        {
            this.lives = new PlayerLives(3);
            this.player = Player.Instance();
            this.display = new PlayerLivesDisplay(this.lives);
            this.commandOnDeath = command;
            this.player.OnCollide += (sender, e) => { this.lives.TakeDamage(); };
            this.lives.OnDeath += (sender, e) => { this.commandOnDeath.Execute(); };
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.display.Draw(spriteBatch);
        }

    }
}
