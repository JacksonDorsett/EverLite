namespace EverLite.Models.PlayerModel
{
    using System;
    using System.Collections.Generic;
    using System.Timers;
    using global::EverLite.Models.Items;
    using global::EverLite.Models.Weapons;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class Player : ICollidable
    {
        // instance
        private static Player mInstance;
        private PlayerSettings playerSettings;
        // constants
        private Vector2 mPosition;
        private SpriteN playerSprite;
        private PlayerShoot shooter;
        private SoundManager sound;
        private VolumeManager volume;
        bool isHit;
        bool bombCooldown = false;

        public event EventHandler OnCollide;
        public event EventHandler OnBombPress;
        public event EventHandler OnBombPickup;

        public SpriteN PlayerSprite { get => playerSprite; }

        public Vector2 Position { get => mPosition; set => mPosition = value; }

        public HitCircle HitCircle => new HitCircle(Position, (float)PlayerSprite.Texture.Width / 4);

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        /// <param name="game">game reference object.</param>
        private Player()
        {
            playerSprite = SpriteLoader.LoadSprite("Rocket");
            shooter = new PlayerShoot(SpriteLoader.LoadSprite("TinyBlue"));
            isHit = false;
            playerSettings = PlayerSettings.Instance;
            sound = SoundManager.Instance;
            volume = VolumeManager.Instance;
        }



        /// <inheritdoc/>
        public void Update(GameTime gameTime)
        {

            KeyboardState currentKeyboardState = Keyboard.GetState();

            if (currentKeyboardState.IsKeyDown(playerSettings.Shoot))
            {
                sound.LaserShot.Play(volume: volume.SoundLevel, pitch: 0.0f, pan: 0.0f);
                shooter.Shoot(Position);
            }

            if (currentKeyboardState.IsKeyDown(playerSettings.UseBomb) && !bombCooldown)
            {
                OnBombPress?.Invoke(this, new EventArgs());
                this.bombCooldown = true;
                Timer timer = new Timer(new TimeSpan(0, 0, 3).TotalMilliseconds);
                timer.AutoReset = false;
                timer.Elapsed += (e, a) => { this.bombCooldown = false; };
                timer.Start();
            }
        }

        /// <summary>
        /// Draws the Player.
        /// </summary>
        /// <param name="spriteBatch">sprite batch being drawn to.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            Color c = Color.White;
            if (isHit) c = Color.Red;


            playerSprite.Draw(spriteBatch, mPosition, c, .5f);
        }

        public static Player Instance()
        {
            if (mInstance == null) mInstance = new Player();
            return mInstance;
        }

        public void CollidesWith(ICollidable collidable)
        {
            if (!isHit)
            {
                OnCollide?.Invoke(this, new EventArgs());
                sound.Explosion.Play(volume.SoundLevel, 0.0f, 0.0f);
                Respawn();
            }
        }

        internal void PickUpItem(Item item)
        {
            if (item is SeismicCharge)
            {
                OnBombPickup?.Invoke(this, new EventArgs());
            }
        }

        private void Respawn()
        {
            isHit = true;
            Timer timer = new Timer(2500); // 0.25 seconds
            timer.Elapsed += (e, o) => { isHit = false; };
            timer.AutoReset = false;
            timer.Start();
            BulletManager.Instance.Clear();
        }
    }
}
