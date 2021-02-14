namespace EverLiteTests
{
    using NUnit.Framework;
    using EverLite.Models;
    using EverLite.Models.WeaponModels;
    using EverLite.Utilities;
    using System;
    using Microsoft.Xna.Framework;

    public class WeaponDesignTests
    {
        private BasicWeapon basicWeapon;

        private BasicRayGun basicRayGun;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void RedRayGunTest()
        {
            basicRayGun = RayGunFactory.CreateRayGun("RedRayGun");
            basicRayGun.SetInitialAmmo(100);
            Assert.AreEqual(basicRayGun.GetColor(), Color.Red);
            Assert.AreEqual(basicRayGun.GetDamageValue(), 1.0);
            Assert.AreEqual(basicRayGun.GetAmmoCount(), 100);
        }
    }
}
