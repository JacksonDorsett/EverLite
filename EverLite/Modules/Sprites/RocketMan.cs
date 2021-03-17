namespace EverLite.Modules.Sprites
{
    using System.Collections.Generic;
    using EverLite.Modules.Behavior;
    using EverLite.Modules.Enums;
    using EverLite.Modules.Input;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class RocketMan : BasePlayer
    {
        public static readonly float NORMALSPEED = 15.0f;
        public static readonly float SLOWSPEED = 5.0f;
        private static readonly float LAYERDEPTH = 5.0f;
        private static readonly float SCALE = 5.0f;
        private static readonly float ANGLE = 0.0f;

        public RocketMan(Game game)
            : base(game.Content.Load<Texture2D>(EnumToStringFactory.GetEnumToString(FactoryEnum.Player)), Vector2.Zero, ANGLE, LAYERDEPTH, SCALE, NORMALSPEED, SLOWSPEED)
        {
            this.GameOn = game;
            this.Initialize(game.Content.Load<Texture2D>(EnumToStringFactory.GetEnumToString(FactoryEnum.Player)), this.GetPlayerLocation());
        }

        public override void Initialize(Texture2D texture, Vector2 position)
        {
            this.Texture = texture;
            this.Position = position;
        }

        public override Vector2 GetPlayerLocation()
        {
            return new Vector2(this.GameOn.GraphicsDevice.Viewport.TitleSafeArea.X + (this.GameOn.GraphicsDevice.Viewport.TitleSafeArea.Width / 2), this.GameOn.GraphicsDevice.Viewport.TitleSafeArea.Y + (this.GameOn.GraphicsDevice.Viewport.TitleSafeArea.Height * 4 / 5));
        }
    }
}
