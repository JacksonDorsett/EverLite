// <copyright file="Game1.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite
{
    using System.Collections.Generic;
    using EverLite.Models;
    using EverLite.Models.Sprites;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Modules.Enemies;
    using Modules;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Main game class.
    /// </summary>
    public class Game1 : Game
    {
        private GraphicsDeviceManager mGraphics;
        private SpriteBatch mSpriteBatch;
        private GameStateContext mContext;



        //Game World
        Random random = new Random();


        /// <summary>
        /// Initializes a new instance of the <see cref="Game1"/> class.
        /// </summary>
        public Game1()
        {
            this.mGraphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
        }

        /// <summary>
        /// Gets the games sprite batch.
        /// </summary>
        public SpriteBatch SpriteBatch
        {
            get
            {
                return this.mSpriteBatch;
            }
        }

        /// <summary>
        /// Gets current GameState.
        /// </summary>
        internal GameStateContext StateContext
        {
            get
            {
                return this.mContext;
            }
        }

        /// <summary>
        /// Function called at instantiation. Initialized the game object.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
            this.mContext = new GameStateContext(this);
        }

        /// <summary>
        /// Loads game content into this.Content.
        /// </summary>
        protected override void LoadContent()
        {
            this.mSpriteBatch = new SpriteBatch(this.GraphicsDevice);

            // TODO: use this.Content to load your game content here

            this.mGraphics.GraphicsProfile = GraphicsProfile.Reach;

            this.mGraphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            this.mGraphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            this.mGraphics.HardwareModeSwitch = false;
            this.mGraphics.ApplyChanges();

        }

        /// <summary>
        /// Updates every game loop cycle. Used for updating game logic.
        /// </summary>
        /// <param name="gameTime">time passed every cycle.</param>
        protected override void Update(GameTime gameTime)
        {
            this.mContext.Update(gameTime);
            // TODO: Add your update logic here
            base.Update(gameTime);
        }

        /// <summary>
        /// Called every gameloop cycle. Draws entities to the screen.
        /// </summary>
        /// <param name="gameTime">time elapsed in cycle.</param>
        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.Black);

            
            // TODO: Add your drawing code here
            //this.mSpriteBatch.Begin();
            this.mContext.Draw(gameTime);
            //this.mSpriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
