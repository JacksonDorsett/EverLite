// <copyright file="Player.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.Sprites
{
    using System;
    using System.Collections.Generic;
    using System.Timers;
    using EverLite.Modules.Behavior;
    using EverLite.Modules.Blaster;
    using EverLite.Modules.Enums;
    using EverLite.Modules.Input;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    /// <summary>
    /// The Player class created will handle the special stuff the player can do.
    /// </summary>
    public class Player: ICollidable
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

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        /// <param name="game">game reference object.</param>
        public Player()
        {
            this.playerSprite = SpriteLoader.LoadSprite(EnumToStringFactory.GetEnumToString(FactoryEnum.Player));
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


            this.playerSprite.Draw(spriteBatch, this.mPosition,c, .5f);
        }

        /// <summary>
        /// Gets instance of player for game object.
        /// </summary>
        /// <param name="game">game object.</param>
        /// <returns>returns player associated with the game.</returns>

        /// <summary>
        /// Handles collision with an object.
        /// </summary>
        /// <param name="collidable"> object colided with.</param>


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
