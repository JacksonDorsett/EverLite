using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace EverLite.Modules.Enemies
{
    internal class SimpleEnemyAlternative : Enemy
    {
        public SimpleEnemyAlternative() { }
        public SimpleEnemyAlternative(Texture2D newTexture, Vector2 newPosition) : base(newTexture, newPosition) { }

        public override string spriteName { get; set; } = "uw";
        public override bool isVisible { get; set; } = true;
    }
}
