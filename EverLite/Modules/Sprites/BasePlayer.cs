namespace EverLite.Modules.Sprites
{
    using System.Collections.Generic;
    using EverLite.Modules.Behavior;
    using EverLite.Modules.Input;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class BasePlayer : ButtonControls
    {
        public Texture2D Texture { get; set; }

        public Vector2 Position { get; set; }

        public Vector2 Velocity { get; set; }

        public float Speed { get; set; }

        public float NORMALSPEED { get; private set; }

        public float SLOWSPEED { get; private set; }

        public float Angle { get; set; }

        public float LayerDepth { get; set; }

        public float Scale { get; set; }

        public bool IsActive { get; set; }

        public Game GameOn { get; set; }

        private static Dictionary<Game, BasePlayer> PlayerRef;

        static BasePlayer()
        {
            PlayerRef = new Dictionary<Game, BasePlayer>();
        }

        public BasePlayer()
        {
        }

        public BasePlayer(bool active, float angle, float speed)
        {
            this.IsActive = active;
            this.Angle = angle;
            this.Speed = speed;
        }

        public BasePlayer(Texture2D texture, Vector2 position, Vector2 velocity)
        {
            this.IsActive = true;
            this.Texture = texture;
            this.Position = position;
            this.Velocity = velocity;
        }

        public BasePlayer(Texture2D texture, Vector2 position, float angle, float layerDepth, float scale, float normalSpeed, float slowSpeed)
        {
            this.IsActive = true;
            this.Texture = texture;
            this.Angle = angle;
            this.Speed = normalSpeed;
            this.LayerDepth = layerDepth;
            this.Scale = scale;
            this.NORMALSPEED = normalSpeed;
            this.SLOWSPEED = slowSpeed;
        }

        public static BasePlayer Instance(Game game)
        {
            if (!PlayerRef.ContainsKey(game))
            {
                PlayerRef[game] = new RocketMan(game);
            }

            return PlayerRef[game];
        }

        public virtual void Initialize(Texture2D texture, Vector2 position)
        {
        }

        public virtual Vector2 GetPlayerLocation() 
        { 
            return new Vector2(this.GameOn.GraphicsDevice.Viewport.TitleSafeArea.X + (this.GameOn.GraphicsDevice.Viewport.TitleSafeArea.Width / 2), this.GameOn.GraphicsDevice.Viewport.TitleSafeArea.Y + (this.GameOn.GraphicsDevice.Viewport.TitleSafeArea.Height * 4 / 5)); 
        }

        public float GetPlayerSpeed()
        {
            return this.Speed;
        }

        public virtual void Update(GameTime gameTime)
        {
            this.Position += this.Velocity;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
        }
    }
}
