namespace EverLite.Modules.Sprites
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public class FontLoader
    {
        private static FontLoader mInstance;
        private Dictionary<string, FontN> loadedTextrues;

        private ContentManager manager;

        private FontLoader(ContentManager content)
        {
            this.manager = content;
            this.loadedTextrues = new Dictionary<string, FontN>();
        }

        /// <summary>
        /// gets the instance of SpriteLoader.
        /// </summary>
        public static FontLoader Instance
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

            mInstance = new FontLoader(contentManager);
        }

        public static FontN LoadFont(string spriteName)
        {
            var instance = FontLoader.Instance;
            if (!instance.loadedTextrues.ContainsKey(spriteName))
            {
                instance.loadedTextrues[spriteName] = new FontN(instance.manager.Load<SpriteFont>(spriteName));
            }

            return instance.loadedTextrues[spriteName];
        }
    }
}
