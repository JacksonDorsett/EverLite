namespace EverLiteTests
{
    using NUnit.Framework;
    using EverLite.Models;
    using EverLite.Models.WeaponModels;
    using EverLite.Models.WeaponModels.Missiles;
    using EverLite.Utilities;
    using System;
    using Microsoft.Xna.Framework;
    using EverLite.Models.WeaponModels.RayGuns;
    using System.Collections.Generic;

    public class PlayerDesignTests
    {
        private List<BasicWeapon> weaponList;
        private PlayerCharacter player;
        private BasicRayGun basicRayGun;

        [Test]
        public void CreatePlayerTest()
        {
            player = new PlayerCharacter();
            Assert.AreEqual(player.CurrentWeaponList().Count, 0);
        }

        [Test]
        public void AddOneWeaponTest()
        {
            player = new PlayerCharacter();
            basicRayGun = RayGunFactory.CreateRayGun(RayGunEnum.RedRayGun);
            basicRayGun.SetInitialAmmo(100);
            player.AddNewWeapon(basicRayGun);
            Assert.AreEqual(player.CurrentWeaponList().Count, 1);
        }

        [Test]
        public void OneWeaponAmmoCountTest()
        {
            player = new PlayerCharacter();
            basicRayGun = RayGunFactory.CreateRayGun(RayGunEnum.RedRayGun);
            basicRayGun.SetInitialAmmo(100);
            player.AddNewWeapon(basicRayGun);
            Assert.AreEqual(player.GetWeapon(basicRayGun).AmmoCount, 100);
        }

        [Test]
        public void AddDuplicateWeaponTest()
        {
            player = new PlayerCharacter();
            basicRayGun = RayGunFactory.CreateRayGun(RayGunEnum.RedRayGun);
            basicRayGun.SetInitialAmmo(100);
            player.AddNewWeapon(basicRayGun);
            player.AddNewWeapon(basicRayGun);
            Assert.AreEqual(player.CurrentWeaponList().Count, 1);
        }

        [Test]
        public void DuplicateWeaponAmmoCountTest()
        {
            player = new PlayerCharacter();
            basicRayGun = RayGunFactory.CreateRayGun(RayGunEnum.RedRayGun);
            basicRayGun.SetInitialAmmo(100);
            player.AddNewWeapon(basicRayGun);
            player.AddNewWeapon(basicRayGun);
            Assert.AreEqual(player.GetWeapon(basicRayGun).AmmoCount, 200);
        }

        [Test]
        public void AddTwoDifferentRayGunTest()
        {
            player = new PlayerCharacter();
            weaponList = new List<BasicWeapon>();
            basicRayGun = RayGunFactory.CreateRayGun(RayGunEnum.RedRayGun);
            basicRayGun.SetInitialAmmo(100);
            player.AddNewWeapon(basicRayGun);
            basicRayGun = RayGunFactory.CreateRayGun(RayGunEnum.BlueRayGun);
            player.AddNewWeapon(basicRayGun);
            Assert.AreEqual(player.CurrentWeaponList().Count, 2);
        }

        [Test]
        public void TwoDifferentRayGunTypeTest()
        {
            player = new PlayerCharacter();
            basicRayGun = RayGunFactory.CreateRayGun(RayGunEnum.RedRayGun);
            basicRayGun.SetInitialAmmo(100);
            player.AddNewWeapon(basicRayGun);
            basicRayGun = RayGunFactory.CreateRayGun(RayGunEnum.BlueRayGun);
            player.AddNewWeapon(basicRayGun);

            weaponList = player.CurrentWeaponList();

            Assert.That(weaponList, Is.Unique);
        }
    }
}
