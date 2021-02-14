namespace EverLite.Models.WeaponModels.Missiles
{
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Abstractly creates missiles.
    /// </summary>
    public abstract class BasicMissile : BasicWeapon
    {
        private readonly Color color;
        private readonly double dmgValue;
        private readonly double aoe;

        /// <summary>
        /// Initializes a new instance of the <see cref="BasicMissile"/> class.
        /// Assigns the coloer, damage multiplier, and area of effect.
        /// </summary>
        /// <param name="colorValue">Assigned from the child color.</param>
        /// <param name="damageValue">Assigned from the child damage multiplier.</param>
        /// <param name="aOE">Assigned from the child area of effect.</param>
        public BasicMissile(Color colorValue, double damageValue, double aOE)
        {
            this.color = colorValue;
            this.dmgValue = damageValue;
            this.aoe = aOE;
        }

        /// <summary>
        /// Returns the missile's color.
        /// </summary>
        /// <returns>Color.</returns>
        public override Color GetColor()
        {
            return this.color;
        }

        /// <summary>
        /// Returns the missile's damage multiplier.
        /// </summary>
        /// <returns>Damage multiplier.</returns>
        public override double GetDamageValue()
        {
            return this.dmgValue;
        }

        /// <summary>
        /// Returns the missile's Area of Effect.
        /// </summary>
        /// <returns>Area of effect.</returns>
        public override double GetAOE()
        {
            return this.aoe;
        }
    }
}
