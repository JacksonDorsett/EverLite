namespace EverLite.Models.WeaponModels
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using System.Text;

    internal class RedRayGun : BasicRayGun
    {
        public RedRayGun()
            : base(Color.Red, 1.0)
        {
        }
    }
}
