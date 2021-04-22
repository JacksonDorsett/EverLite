namespace EverLite
{
    using Microsoft.Xna.Framework;

    public class PlayerShoot : IShootingPattern
    {
        SpriteN bulletSprite;
        BulletManager manager;

        public PlayerShoot(SpriteN bulletSprite)
        {
            this.bulletSprite = bulletSprite;
            this.manager = BulletManager.Instance;
        }

        public void Shoot(Vector2 position)
        {
            var fpos = position;
            fpos.Y -= 1000;
            this.manager.AddPlayerBullet(new Bullet(this.bulletSprite, new LifeTimeMovement(.7f, new LinearMovement(position, fpos))));
        }
    }
}
