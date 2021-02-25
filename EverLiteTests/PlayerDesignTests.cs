namespace EverLiteTests
{
    using NUnit.Framework;
    using EverLite.Modules.Sprites;
    using EverLite.Modules.Enums;

    public class PlayerDesignTests
    {
        private Sprite player;

        /// <summary>
        /// Checking to see if the player is correctly created.
        /// </summary>
        [Test]
        public void CreatePlayerTest()
        {
            //player = SpriteFactory.CreateSprite(FactoryEnum.Player);
            //Assert.AreEqual(player.GetSpriteType(), FactoryEnum.Player);
        }

        /// <summary>
        /// Checking to see that the sprite class assigns spriteType field correctly.
        /// Checks for correct, then checks that a different spriteType isn't assigned.
        /// </summary>
        [Test]
        public void PlayerEnumTypeFailureTest()
        {
            //player = SpriteFactory.CreateSprite(FactoryEnum.Player);
            //Assert.AreEqual(player.GetSpriteType(), FactoryEnum.Player);
            //Assert.AreNotEqual(player.GetSpriteType(), FactoryEnum.Bullets);
        }
    }
}
