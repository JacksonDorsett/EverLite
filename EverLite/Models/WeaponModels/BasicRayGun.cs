namespace EverLite.Models
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using System.Text;

    // Should be an internal class. Using public for testing for now.
    public abstract class BasicRayGun : BasicWeapon
    {
        private readonly Color color;
        private readonly double dmgValue;

        public BasicRayGun(Color colorValue, double damageValue)
        {
            this.color = colorValue;
            this.dmgValue = damageValue;
        }

        public override Color GetColor()
        {
            return this.color;
        }

        public override double GetDamageValue()
        {
            return this.dmgValue;
        }
    }
}
