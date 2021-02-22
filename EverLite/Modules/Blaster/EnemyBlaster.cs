using EverLite.Modules.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace EverLite.Modules.Blaster
{
    class EnemyBlaster : IBlaster
    {
        Player player;
        Texture2D texture;

        public Sprite Shoot(Vector2 position)
        {
            return new TinyRedBullets();
        }
    }
}
