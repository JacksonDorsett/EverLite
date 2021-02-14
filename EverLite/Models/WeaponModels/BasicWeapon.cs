namespace EverLite.Models
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using System.Text;

    public abstract class BasicWeapon
    {
        public int AmmoCount { get; set; }

        public int GetAmmoCount()
        {
            return this.AmmoCount;
        }

        public void SetInitialAmmo(int value)
        {
            this.AmmoCount = value;
        }

        public void AddAmmo(int value)
        {
            this.AmmoCount += value;
        }

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

        public abstract Color GetColor();

        public abstract double GetDamageValue();
    }
}
