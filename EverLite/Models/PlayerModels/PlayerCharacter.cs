// <copyright file="PlayerCharacter.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Text;

    /// <summary>
    /// Object class of the player character.
    /// </summary>
    public class PlayerCharacter : INotifyPropertyChanged
    {
        private HealthBar healthbar;

        public event PropertyChangedEventHandler PropertyChanged;

        public HealthBar GetHealthbar()
        {
            return this.healthbar;
        }

        public void SetHealthbar(HealthBar value)
        {
            this.healthbar = value;
            this.RaisePropertyChanged("Healthbar");
        }


        private void RaisePropertyChanged(string propertyname)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
