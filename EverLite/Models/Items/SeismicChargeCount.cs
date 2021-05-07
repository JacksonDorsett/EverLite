namespace EverLite.Models.Items
{
    using global::EverLite.ScriptInterperiter;
    using Microsoft.Xna.Framework;
    using System;
    using System.Collections.Generic;

    class SeismicChargeCount
    {
        private int maxCharges;
        private int currentCharges;

        public SeismicChargeCount(int startingBombs)
        {
            this.maxCharges = this.currentCharges = startingBombs;
        }

        public int Charges { get => this.currentCharges; }

        public void AddCharge()
        {
            this.currentCharges += 1;
            this.currentCharges = Math.Min(maxCharges, currentCharges);
        }

        public SeismicCharge SpawnBomb(Vector2 position)
        {
            if (this.currentCharges == 0)
            {
                return null;
            }

            this.currentCharges--;

            SeismicCharge charge = new SeismicCharge(SpriteLoader.LoadSprite("sesmic_charge"), MovementFactory.Create("Stationary", 0, new List<Vector2>() { position }));
            charge.PrimeCharge(new TimeSpan(0, 0, 3));
            return charge;
        }
    }
}
