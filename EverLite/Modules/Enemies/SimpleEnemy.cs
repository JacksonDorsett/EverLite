using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace EverLite.Modules.Enemies
{
    internal class SimpleEnemy : Enemy
    {
        public SimpleEnemy() { }
        public SimpleEnemy(Texture2D newTexture, Vector2 newPosition) : base(newTexture, newPosition) { }

        public override string spriteName { get; set; } = "wsu";
        public override bool isVisible { get; set; } = true;
    }
}
