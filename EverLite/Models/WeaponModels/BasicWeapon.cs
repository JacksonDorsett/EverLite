namespace EverLite.Models
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    /// <summary>
    /// This is the base weapon format for all weapons.
    /// </summary>
    public abstract class BasicWeapon
    {
        /// <summary>
        /// Gets or sets tracks the ammo count for the weapon instance.
        /// </summary>
        public int AmmoCount { get; set; }

        /// <summary>
        /// Sets the starting ammo for the weapon instance.
        /// </summary>
        /// <param name="value">initial ammo count</param>
        public void SetInitialAmmo(int value)
        {
            this.AmmoCount = value;
        }

        /// <summary>
        /// Reloads ammo.
        /// </summary>
        /// <param name="value">amount of ammo to reload.</param>
        public void AddAmmo(int value)
        {
            this.AmmoCount += value;
        }

        /// <summary>
        /// Removes one round at a time. Designed for shooting.
        /// </summary>
        public void RemoveAmmo()
        {
            if (this.AmmoCount > 0)
            {
                this.AmmoCount -= 1;
            }
            else
            {
                this.AmmoCount = 0;
            }
        }

        /// <summary>
        /// Removes a specific amount of ammo. Designed for ability to remove
        /// multiple rounds at once.
        /// </summary>
        /// <param name="value">Amount of ammo to remove.</param>
        public void RemoveAmmo(int value)
        {
            if (this.AmmoCount > value)
            {
                this.AmmoCount = this.AmmoCount - value;
            }
            else
            {
                this.AmmoCount = 0;
            }
        }

        /// <summary>
        /// Returns the color of the weapon.
        /// </summary>
        /// <returns>Weapon color.</returns>
        public abstract Color GetColor();

        /// <summary>
        /// Returns damage multiplier of weapon.
        /// </summary>
        /// <returns>damage multiplier.</returns>
        public abstract double GetDamageValue();

        /// <summary>
        /// Returns the missile's Area of Effect.
        /// </summary>
        /// <returns>Area of effect.</returns>
        public abstract double GetAOE();
    }
}
