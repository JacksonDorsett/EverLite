namespace EverLite.Models.Weapons
{
    using Microsoft.Xna.Framework;

    public class PlayerShoot : IShootingPattern
    {
        SpriteN bulletSprite;
        BulletManager manager;

        public PlayerShoot(SpriteN bulletSprite)
        {
            this.bulletSprite = bulletSprite;
            manager = BulletManager.Instance;
        }

        public void Shoot(Vector2 position)
        {
            var fpos = position;
            fpos.Y -= 1000;

            manager.AddPlayerBullet(new Bullet(bulletSprite, new LinearVectorMovement(position, fpos, 25)));
        }
    }
}
