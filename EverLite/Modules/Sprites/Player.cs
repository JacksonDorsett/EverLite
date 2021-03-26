// <copyright file="Player.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.Sprites
{
    using System.Collections.Generic;
    using EverLite.Modules.Enums;
    using EverLite.Modules.Input;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;


    /// <summary>
    /// The Player class created will handle the special stuff the player can do.
    /// </summary>
    public class Player
    {
        private static readonly float NORMALSPEED = 15.0f;
        private static readonly float SLOWSPEED = 5.0f;
        private static Dictionary<Game, Player> sPlayerRef;
        private readonly float scale = 0.5f;
        private readonly float layerDepth = 0.0f;
        private Game mGame;
        private ToggleStatus slowSpeedStatus;


        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// Sets isActive, angle, velocity, and spriteType fields.
        /// </summary>
        /// <param name="newBulletTexture">The picture of the bullet object.</param>
        public Player()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        /// <param name="game">game reference object.</param>
        public Player(Game game)
            //: base(0, NORMALSPEED, game.Content.Load<Texture2D>(EnumToStringFactory.GetEnumToString(FactoryEnum.Player)), Vector2.Zero)
        {
            this.mGame = game;
            this.Initialize(game.Content.Load<Texture2D>(EnumToStringFactory.GetEnumToString(FactoryEnum.Player)), this.GetPlayerLocation());

            this.slowSpeedStatus = new ToggleStatus(Keys.G);
        }

        /// <summary>
        /// Gets instance of player for game object.
        /// </summary>
        /// <param name="game">game object.</param>
        /// <returns>returns player associated with the game.</returns>
        public static Player Instance(Game game)
        {
            if (!sPlayerRef.ContainsKey(game))
            {
                sPlayerRef[game] = new Player(game);
            }

            return sPlayerRef[game];
        }

        /// <summary>
        /// This combines the Texture2D and Rectangle objects into the player for control.
        /// </summary>
        /// <param name="texture">The picture of the player object.</param>
        /// <param name="position">Starting position for the player object.</param>
        public override void Initialize(Texture2D texture, Vector2 position)
        {
            this.Texture = texture;
            this.Position = position;
        }

        /// <inheritdoc/>
        public void Update(GameTime gameTime)
        {
        }

        public Vector2 GetPosition()
        {
            return this.mPosition;
        }

        /// <summary>
        /// Draws the Player.
        /// </summary>
        /// <param name="spriteBatch">sprite batch being drawn to.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 origin;

            this.playerSprite.Draw(spriteBatch, this.mPosition,.5f);
        }

        private Vector2 GetPlayerLocation()
        {
            return new Vector2(this.mGame.GraphicsDevice.Viewport.TitleSafeArea.X + (this.mGame.GraphicsDevice.Viewport.TitleSafeArea.Width / 2), this.mGame.GraphicsDevice.Viewport.TitleSafeArea.Y + (this.mGame.GraphicsDevice.Viewport.TitleSafeArea.Height * 4 / 5));
        }
        
        public float GetPlayerSpeed()
        {
            this.slowSpeedStatus.Update();
            if (!this.slowSpeedStatus.Status)
            {
                return NORMALSPEED;
            }
            else
            {
                return SLOWSPEED;
            }
        }
    }
}
