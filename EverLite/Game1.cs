// <copyright file="Game1.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite
{
    using EverLite.Modules.GameState;
    using EverLite.Modules.Sprites;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Main game class.
    /// </summary>
    public class Game1 : Game
    {
        // The Sprite fonts are setup here and accessed where needed through 'this.Game.fontName'.
        public SpriteFont fontOriginTech;
        public SpriteFont fontOriginTechSmall;
        // The GameScore instance is here so that all the other game states can access it.
        public GameScore score;
        private GraphicsDeviceManager mGraphics;
        private SpriteBatch mSpriteBatch;
        private GameStateContext mContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="Game1"/> class.
        /// </summary>
        public Game1()
        {

            this.mGraphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
            this.score = GameScore.Instance;
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
            SpriteLoader.Initialize(this.Content);
        }

        /// <summary>
        /// Loads game content into this.Content.
        /// </summary>
        protected override void LoadContent()
        {
            this.mSpriteBatch = new SpriteBatch(this.GraphicsDevice);

            this.fontOriginTech = this.Content.Load<SpriteFont>(@"Fonts\font_origin_tech");
            this.fontOriginTechSmall = this.Content.Load<SpriteFont>(@"Fonts\font_origin_tech_small");
            this.mGraphics.GraphicsProfile = GraphicsProfile.Reach;

            this.mGraphics.PreferredBackBufferWidth = 1920;
            this.mGraphics.PreferredBackBufferHeight = 1080;
            this.mGraphics.HardwareModeSwitch = false;
            this.mGraphics.ApplyChanges();
            SpriteLoader.Initialize(this.Content);

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
            this.mContext.Draw(gameTime);
            base.Draw(gameTime);
        }
    }
}
