namespace EverLiteTests
{
    using NUnit.Framework;
    using EverLite.Models;
    using EverLite.Models.WeaponModels;
    using EverLite.Models.WeaponModels.Missiles;
    using EverLite.Utilities;
    using System;
    using Microsoft.Xna.Framework;

    public class WeaponDesignTests
    {
        private BasicRayGun basicRayGun;
        private BasicMissile basicMissile;

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
            Assert.AreEqual(basicRayGun.AmmoCount, 100);
        }

        [Test]
        public void BlueRayGunTest()
        {
            basicRayGun = RayGunFactory.CreateRayGun("BlueRayGun");
            basicRayGun.SetInitialAmmo(100);
            Assert.AreEqual(basicRayGun.GetColor(), Color.Blue);
            Assert.AreEqual(basicRayGun.GetDamageValue(), 1.1);
            Assert.AreEqual(basicRayGun.AmmoCount, 100);
        }

        [Test]
        public void SimpleGreenMissileTest()
        {
            basicMissile = MissileFactory.CreateMissile("SingleGreenMissile");
            basicMissile.SetInitialAmmo(10);
            Assert.AreEqual(basicMissile.GetColor(), Color.Green);
            //Assert.AreEqual(basicMissile.GetDamageValue(), 1.5);
            //Assert.AreEqual(basicMissile.AmmoCount, 10);
            //Assert.AreEqual(basicMissile.GetAOE(), 2.0);
        }

        [Test]
        public void SimpleAquaMissileTest()
        {
            basicMissile = MissileFactory.CreateMissile("SingleAquaMissile");
            basicMissile.SetInitialAmmo(10);
            Assert.AreEqual(basicMissile.GetColor(), Color.Aqua);
            //Assert.AreEqual(basicMissile.GetDamageValue(), 2.5);
            //Assert.AreEqual(basicMissile.AmmoCount, 10);
            //Assert.AreEqual(basicMissile.GetAOE(), 1.5);
        }
    }
}
