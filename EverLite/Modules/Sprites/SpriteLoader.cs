// <copyright file="SpriteLoader.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.Sprites
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Loads sprites based on string name.
    /// </summary>
    public class SpriteLoader
    {
        private static SpriteLoader mInstance;
        private Dictionary<string, SpriteN> loadedTextrues;

        private ContentManager manager;

        private SpriteLoader(ContentManager content)
        {
            this.manager = content;
            this.loadedTextrues = new Dictionary<string, SpriteN>();
        }

        /// <summary>
        /// gets the instance of SpriteLoader.
        /// </summary>
        public static SpriteLoader Instance
        {
            get
            {
                if (mInstance == null) throw new NullReferenceException("SpriteLoader was not initialize.");

                return mInstance;
            }
        }

        /// <summary>
        /// This function sets the context for the spriteloader.
        /// </summary>
        /// <param name="contentManager">content manager context.</param>
        public static void Initialize(ContentManager contentManager)
        {
            if (mInstance != null && contentManager != mInstance.manager) throw new AggregateException("SpriteLoader already Initialized.");

            mInstance = new SpriteLoader(contentManager);
        }

        /// <summary>
        /// Loads sprite from string.
        /// </summary>
        /// <param name="spriteName">name of the sprite.</param>
        /// <returns>returns the texture with the sprite name.</returns>
        public static SpriteN LoadSprite(string spriteName)
        {
            var instance = SpriteLoader.Instance;
            if (!instance.loadedTextrues.ContainsKey(spriteName))
            {
                instance.loadedTextrues[spriteName] = new SpriteN(instance.manager.Load<Texture2D>(spriteName));
            }

            return instance.loadedTextrues[spriteName];
        }
    }
}
