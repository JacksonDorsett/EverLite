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

    /// <summary>
    /// Loads sprites based on string name.
    /// </summary>
    public class SpriteLoader
    {
        private static SpriteLoader mInstance;

        private ContentManager manager;

        private SpriteLoader(ContentManager content)
        {
            this.manager = content;
        }

        /// <summary>
        /// gets the instance of SpriteLoader.
        /// </summary>
        public SpriteLoader Instance
        {
            get
            {
                if (mInstance == null) throw new NullReferenceException("SpriteLoader was not initialize.");

                return mInstance;
            }
        }

        public static void Initialize(ContentManager contentManager)
        {
            if (mInstance != null && contentManager != mInstance.manager) throw new AggregateException("SpriteLoader already Initialized.");

            mInstance = new SpriteLoader(contentManager);
        }
    }
}
