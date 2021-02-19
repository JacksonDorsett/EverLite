namespace EverLiteTests
{
    using NUnit.Framework;
    using EverLite.Models;

    public class PlayerDesignTests
    {
        private Sprite player;

        /// <summary>
        /// Checking to see if the player is correctly created.
        /// </summary>
        [Test]
        public void CreatePlayerTest()
        {
            player = SpriteFactory.CreateSprite(FactoryEnum.Player);
            Assert.AreEqual(player.isSpriteType(), FactoryEnum.Player);
        }

        /// <summary>
        /// Checking to see that the sprite class assigns spriteType field correctly.
        /// Checks for correct, then checks that a different spriteType isn't assigned.
        /// </summary>
        [Test]
        public void PlayerEnumTypeFailureTest()
        {
            player = SpriteFactory.CreateSprite(FactoryEnum.Player);
            Assert.AreEqual(player.isSpriteType(), FactoryEnum.Player);
            Assert.AreNotEqual(player.isSpriteType(), FactoryEnum.Bullets);
        }
    }
}
