namespace EverLite.Models
{
    using Microsoft.Xna.Framework;

    // Should be an internal class. Using public for testing for now.

    /// <summary>
    /// Abstractly creates ray guns.
    /// </summary>
    public abstract class BasicRayGun : BasicWeapon
    {
        private readonly Color color;
        private readonly double dmgValue;
        private readonly double aoe;

        /// <summary>
        /// Initializes a new instance of the <see cref="BasicRayGun"/> class.
        /// Assigns the color and damage multiplier, and area of effect.
        /// </summary>
        /// <param name="colorValue">Assigned from the child color.</param>
        /// <param name="damageValue">Assigned from the child damage multiplier.</param>
        /// <param name="aOE">Assigned from the child area of effect.</param>
        public BasicRayGun(Color colorValue, double damageValue, double aOE)
        {
            this.color = colorValue;
            this.dmgValue = damageValue;
            this.aoe = aOE;
        }

        /// <summary>
        /// Returns the ray gun's color.
        /// </summary>
        /// <returns>Color.</returns>
        public override Color GetColor()
        {
            return this.color;
        }

        /// <summary>
        /// Returns the ray gun's damage multiplier.
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
