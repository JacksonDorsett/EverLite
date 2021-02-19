// <copyright file="Game1.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Modules.Enemies;
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

        //Game World
        List<Enemy> enemies = new List<Enemy>();
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
        /// Function called at instantiation. Initialized the game object.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        /// <summary>
        /// Loads game content into this.Content.
        /// </summary>
        protected override void LoadContent()
        {
            this.mSpriteBatch = new SpriteBatch(this.GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        float spawn = 0;

        /// <summary>
        /// Updates every game loop cycle. Used for updating game logic.
        /// </summary>
        /// <param name="gameTime">time passed every cycle.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }

            spawn += (float)gameTime.ElapsedGameTime.TotalSeconds;

            foreach (Enemy enemie in enemies)
                enemie.Update(mGraphics.GraphicsDevice);
            LoadEnemies();
            // TODO: Add your update logic here
            base.Update(gameTime);
        }

        public void LoadEnemies()
        {
            int randY = random.Next(100, 400);
            if (spawn >= 1)
            {
                spawn = 0;
                if(enemies.Count < 4)
                {
                    Enemy enemy = new SimpleEnemy();
                    enemy.ChangeTexture(Content.Load<Texture2D>(enemy.spriteName));
                    enemy.ChangePosition(new Vector2(1100, randY));
                    enemy.SetRandomVelocity();
                    enemies.Add(enemy);

                    enemy = new SimpleEnemyAlternative();
                    enemy.ChangeTexture(Content.Load<Texture2D>(enemy.spriteName));
                    enemy.ChangePosition(new Vector2(1000, randY));
                    enemy.SetRandomVelocity();
                    enemies.Add(enemy);
                }

                for(int i = 0; i < enemies.Count; i++)
                {
                    if(!enemies[i].isVisible)
                    {
                        enemies.RemoveAt(i);
                        i--;
                    }
                }

            }
        }

        /// <summary>
        /// Called every gameloop cycle. Draws entities to the screen.
        /// </summary>
        /// <param name="gameTime">time elapsed in cycle.</param>
        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.CornflowerBlue);

            mSpriteBatch.Begin();
            foreach (Enemy enemie in enemies)
                enemie.Draw(mSpriteBatch);
            mSpriteBatch.End();
            // TODO: Add your drawing code here
            base.Draw(gameTime);
        }
    }
}
