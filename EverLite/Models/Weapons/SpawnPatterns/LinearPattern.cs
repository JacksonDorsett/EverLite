namespace EverLite.Models.Weapons.SpawnPatterns
{
    using global::EverLite.Models.PlayerModel;
    using Microsoft.Xna.Framework;
    using System.Collections.Generic;

    internal class LinearPattern : SpawnPattern
    {
        private Player mPlayer;


        public LinearPattern(List<Bullet> bullets, SpriteN bulletSprite, float speed, int totalBullets, double spawnRate)
            : base(bullets, bulletSprite, speed, totalBullets, spawnRate)
        {
            mPlayer = Player.Instance();

        }

        public override SpawnPattern Clone()
        {
            return new LinearPattern(bulletList, Sprite, (float)Speed, TotalBullets, SpawnRate);
        }

        public override void Spawn(Vector2 spawnPosition)
        {
            Vector2 dif = mPlayer.Position - spawnPosition;
            dif.Normalize();

            var p = new LinearMovement(spawnPosition, spawnPosition + dif * 2000);

            //var b = new Bullet(this.Sprite, new LifeTimeMovement(5, p));
            var b = new Bullet(Sprite, new LinearVectorMovement(spawnPosition, mPlayer.Position, (float)Speed));
            bulletList.Add(b);
        }

        public override void Update(GameTime gameTime, Vector2 position)
        {
            base.Update(gameTime, position);
        }
    }
}
