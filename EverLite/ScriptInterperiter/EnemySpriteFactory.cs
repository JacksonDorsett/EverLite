using System;
using System.Collections.Generic;
using System.Text;

namespace EverLite.ScriptInterperiter
{
    class EnemySpriteFactory
    {
        public static SpriteN Create(string type)
        {
            switch (type)
            {
                case "B":
                    return SpriteLoader.LoadSprite("enemy2");
                case "MB":
                    return SpriteLoader.LoadSprite("mid-boss");
                case "FB":
                    return SpriteLoader.LoadSprite("final-boss");
                default:
                    return SpriteLoader.LoadSprite("enemy1");

            }
        }
    }
}
