namespace EverLite.Models.WeaponModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class RayGunFactory
    {
        public static BasicRayGun CreateRayGun(string rayGun)
        {
            switch (rayGun)
            {
                case "RedRayGun":
                    return new RedRayGun();
                default:
                    return null;
            }
        }
    }
}
