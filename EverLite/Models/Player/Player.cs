﻿namespace EverLite
{
    using System;
    using System.Timers;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class Player : ICollidable
    {
        // instance
        private static Player mInstance;
        // constants
        private Vector2 mPosition;
        private SpriteN playerSprite;
        private PlayerShoot shooter;
        bool isHit;

        public event EventHandler OnCollide;

        public SpriteN PlayerSprite { get => this.playerSprite; }

        public Vector2 Position { get => mPosition; set => mPosition = value; }

        public HitCircle HitCircle => new HitCircle(Position, (float)this.PlayerSprite.Texture.Width / 4);

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        /// <param name="game">game reference object.</param>
        private Player()
        {
            this.playerSprite = SpriteLoader.LoadSprite("Rocket");
            this.shooter = new PlayerShoot(SpriteLoader.LoadSprite("TinyBlue"));
            this.isHit = false;
        }



        /// <inheritdoc/>
        public void Update(GameTime gameTime)
        {

            KeyboardState currentKeyboardState = Keyboard.GetState();

            if (currentKeyboardState.IsKeyDown(Keys.J))
            {
                this.shooter.Shoot(this.Position);
            }
        }

        /// <summary>
        /// Draws the Player.
        /// </summary>
        /// <param name="spriteBatch">sprite batch being drawn to.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            Color c = Color.White;
            if (this.isHit) c = Color.Red;


            this.playerSprite.Draw(spriteBatch, this.mPosition, c, .5f);
        }

        public static Player Instance()
        {
            if (mInstance == null) mInstance = new Player();
            return mInstance;
        }

        public void CollidesWith(ICollidable collidable)
        {
            if (!this.isHit)
            {
                this.OnCollide?.Invoke(this, new EventArgs());
                this.Respawn();
            }
        }

        private void Respawn()
        {
            this.isHit = true;
            Timer timer = new Timer(2500); // 0.25 seconds
            timer.Elapsed += (e, o) => { this.isHit = false; };
            timer.AutoReset = false;
            timer.Start();
            BulletManager.Instance.Clear();
        }
    }
}