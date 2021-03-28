

namespace EverLite.Modules.Blaster
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EverLite.Modules.Behavior;
    using EverLite.Modules.Sprites;
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
            this.manager.AddPlayerBullet(new Bullet(this.bulletSprite, new LinearMovement(position, fpos), .7));
        }
    }
}
