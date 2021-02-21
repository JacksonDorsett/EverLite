// <copyright file="BGM.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Audio
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Audio;
    using Microsoft.Xna.Framework.Media;

    /// <summary>
    /// Represents the background music implemented as a singleton.
    /// </summary>
    public class BGM
    {
        private static Dictionary<Game,BGM> mInstance;
        private Song sInstance;
        private Game mGame;

        private BGM(Game game)
        {
            mInstance[game] = this;
            this.mGame = game;
        }

        /// <summary>
        /// Returns the BGM instance of the corresponding game.
        /// </summary>
        /// <param name="game">game reference object.</param>
        /// <returns>Returns the BGM associated with the game object.</returns>
        public static BGM Instance(Game game)
        {
            if (game is null)
            {
                throw new ArgumentNullException(nameof(game));
            }

            if (mInstance == null)
            {
                mInstance = new Dictionary<Game, BGM>();
            }

            if (!mInstance.ContainsKey(game))
            {
                mInstance[game] = new BGM(game);
            }

            return mInstance[game];
        }

        /// <summary>
        /// Loads a sound for the BGM.
        /// </summary>
        /// <param name="name">name of the music file.</param>
        public void Load(string name)
        {
            if (this.sInstance != null)
            {
                this.sInstance.Dispose();
            }

            this.sInstance = this.mGame.Content.Load<Song>(name);

            this.Play();
        }

        /// <summary>
        /// Pauses the BGM.
        /// </summary>
        public void Pause()
        {
            MediaPlayer.Pause();
        }

        /// <summary>
        /// Stops the BGM.
        /// </summary>
        public void Stop()
        {
            MediaPlayer.Stop();
        }

        /// <summary>
        /// Plays the BGM.
        /// </summary>
        public void Play()
        {
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(this.sInstance);
        }
    }
}
