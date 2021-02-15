namespace EverLiteTests
{
    using NUnit.Framework;
    using EverLite.Models;
    using EverLite.Models.WeaponModels.Missiles;
    using Microsoft.Xna.Framework;
    using EverLite.Models.WeaponModels.RayGuns;

    public class WeaponDesignTests
    {
        private BasicRayGun basicRayGun;
        private BasicMissile basicMissile;

        [SetUp]
        public void Setup()
        {
        }

        #region Creating instance tests
        [Test]
        public void CreateRedRayGunTest()
        {
            basicRayGun = RayGunFactory.CreateRayGun(RayGunEnum.RedRayGun);
            basicRayGun.SetInitialAmmo(100);
            Assert.AreEqual(basicRayGun.GetColor(), Color.Red);
        }

        [Test]
        public void CreateBlueRayGunTest()
        {
            basicRayGun = RayGunFactory.CreateRayGun(RayGunEnum.BlueRayGun);
            basicRayGun.SetInitialAmmo(100);
            Assert.AreEqual(basicRayGun.GetColor(), Color.Blue);
        }

        [Test]
        public void CreateSimpleGreenMissileTest()
        {
            basicMissile = MissileFactory.CreateMissile(MissileEnum.SingleGreenMissile);
            basicMissile.SetInitialAmmo(10);
            Assert.AreEqual(basicMissile.GetColor(), Color.Green);
        }

        [Test]
        public void CreateSimpleAquaMissileTest()
        {
            basicMissile = MissileFactory.CreateMissile(MissileEnum.SingleAquaMissile);
            basicMissile.SetInitialAmmo(10);
            Assert.AreEqual(basicMissile.GetColor(), Color.Aqua);
        }
        #endregion


        #region Testing 2x single round shot usage
        [Test]
        public void RedRayGunAmmoSingleRoundUsageTest()
        {
            basicRayGun = RayGunFactory.CreateRayGun(RayGunEnum.RedRayGun);
            basicRayGun.SetInitialAmmo(100);
            basicRayGun.ShootAmmo();
            basicRayGun.ShootAmmo();
            Assert.AreEqual(basicRayGun.AmmoCount, 98);
        }

        [TestCase(97)]
        [TestCase(99)]
        public void RedRayGunAmmoSingleRoundUsageboundryTest(int edge)
        {
            basicRayGun = RayGunFactory.CreateRayGun(RayGunEnum.RedRayGun);
            basicRayGun.SetInitialAmmo(100);
            basicRayGun.ShootAmmo();
            basicRayGun.ShootAmmo();
            Assert.AreNotEqual(basicRayGun.AmmoCount, edge);
        }


        [Test]
        public void BlueRayGunAmmoSingleRoundUsageTest()
        {
            basicRayGun = RayGunFactory.CreateRayGun(RayGunEnum.BlueRayGun);
            basicRayGun.SetInitialAmmo(100);
            basicRayGun.ShootAmmo();
            basicRayGun.ShootAmmo();
            Assert.AreEqual(basicRayGun.AmmoCount, 98);
        }

        [TestCase(7)]
        [TestCase(9)]
        public void BlueRayGunAmmoSingleRoundUsageBoundaryTest(int edge)
        {
            basicRayGun = RayGunFactory.CreateRayGun(RayGunEnum.BlueRayGun);
            basicRayGun.SetInitialAmmo(100);
            basicRayGun.ShootAmmo();
            basicRayGun.ShootAmmo();
            Assert.AreNotEqual(basicRayGun.AmmoCount, edge);
        }

        [Test]
        public void SingleGreenMissileAmmoSingleRoundUsageTest()
        {
            basicMissile = MissileFactory.CreateMissile(MissileEnum.SingleGreenMissile);
            basicMissile.SetInitialAmmo(10);
            basicMissile.ShootAmmo();
            basicMissile.ShootAmmo();
            Assert.AreEqual(basicMissile.AmmoCount, 8);
        }

        [TestCase(7)]
        [TestCase(9)]
        public void SingleGreenMissileAmmoSingleRoundUsageBoundaryTest(int edge)
        {
            basicMissile = MissileFactory.CreateMissile(MissileEnum.SingleGreenMissile);
            basicMissile.SetInitialAmmo(10);
            basicMissile.ShootAmmo();
            basicMissile.ShootAmmo();
            Assert.AreNotEqual(basicMissile.AmmoCount, edge);
        }

        [Test]
        public void SingleAquaMissileAmmoSingleRoundUsageTest()
        {
            basicMissile = MissileFactory.CreateMissile(MissileEnum.SingleAquaMissile);
            basicMissile.SetInitialAmmo(10);
            basicMissile.ShootAmmo();
            basicMissile.ShootAmmo();
            Assert.AreEqual(basicMissile.AmmoCount, 8);
        }

        [TestCase(7)]
        [TestCase(9)]
        public void SingleAquaMissileAmmoSingleRoundUsageBoundaryTest(int edge)
        {
            basicMissile = MissileFactory.CreateMissile(MissileEnum.SingleAquaMissile);
            basicMissile.SetInitialAmmo(10);
            basicMissile.ShootAmmo();
            basicMissile.ShootAmmo();
            Assert.AreNotEqual(basicMissile.AmmoCount, edge);
        }
        #endregion


        #region Testing ammo count not dropping below zero.
        [Test]
        public void RedRayGunAmmoNotNegativeTest()
        {
            basicRayGun = RayGunFactory.CreateRayGun(RayGunEnum.RedRayGun);
            basicRayGun.SetInitialAmmo(1);
            basicRayGun.RemoveAmmo(5);
            Assert.AreEqual(basicRayGun.AmmoCount, 0);
        }

        [Test]
        public void BlueRayGunAmmoNotNegativeTest()
        {
            basicRayGun = RayGunFactory.CreateRayGun(RayGunEnum.BlueRayGun);
            basicRayGun.SetInitialAmmo(1);
            basicRayGun.RemoveAmmo(5);
            Assert.AreEqual(basicRayGun.AmmoCount, 0);
        }

        [Test]
        public void SingleAquaAmmoNotNegativeTest()
        {
            basicMissile = MissileFactory.CreateMissile(MissileEnum.SingleAquaMissile);
            basicMissile.SetInitialAmmo(10);
            basicMissile.RemoveAmmo(12);
            Assert.AreEqual(basicMissile.AmmoCount, 0);
        }

        [Test]
        public void SingleGreenAmmoNotNegativeTest()
        {
            basicMissile = MissileFactory.CreateMissile(MissileEnum.SingleGreenMissile);
            basicMissile.SetInitialAmmo(10);
            basicMissile.RemoveAmmo(12);
            Assert.AreEqual(basicMissile.AmmoCount, 0);
        }
        #endregion


        # region Testing multiple round removal
        [Test]
        public void RedRayGunRemoveMultipleRoundsAtOnceTest()
        {
            basicRayGun = RayGunFactory.CreateRayGun(RayGunEnum.RedRayGun);
            basicRayGun.SetInitialAmmo(100);
            basicRayGun.RemoveAmmo(25);
            Assert.AreEqual(basicRayGun.AmmoCount, 75);
        }

        [Test]
        public void BlueRayGunRemoveMultipleRoundsAtOnceTest()
        {
            basicRayGun = RayGunFactory.CreateRayGun(RayGunEnum.BlueRayGun);
            basicRayGun.SetInitialAmmo(100);
            basicRayGun.RemoveAmmo(25);
            Assert.AreEqual(basicRayGun.AmmoCount, 75);
        }

        [Test]
        public void SingleAquaMissileRemoveMultipleMissilesAtOnceTest()
        {
            basicMissile = MissileFactory.CreateMissile(MissileEnum.SingleAquaMissile);
            basicMissile.SetInitialAmmo(10);
            basicMissile.RemoveAmmo(4);
            Assert.AreEqual(basicMissile.AmmoCount, 6);
        }

        [Test]
        public void SingleGreenMissileRemoveMultipleMissilesAtOnceTest()
        {
            basicMissile = MissileFactory.CreateMissile(MissileEnum.SingleGreenMissile);
            basicMissile.SetInitialAmmo(10);
            basicMissile.RemoveAmmo(4);
            Assert.AreEqual(basicMissile.AmmoCount, 6);
        }
        #endregion
    }
}
