namespace EverLite
{
    using Microsoft.Xna.Framework.Media;

    /// <summary>
    /// Manages the volume controls.
    /// </summary>
    public class VolumeManager
    {
        private static VolumeManager instance;
        private static int volumeLevel;
        private static int tempVolume;
        private static int soundLevel;
        private static int tempSound;
        private static bool isMuted;

        /// <summary>
        /// Initializes a new instance of the <see cref="VolumeManager"/> class.
        /// </summary>
        private VolumeManager()
        {
        }

        /// <summary>
        /// Returns instance of the VolumeManager;
        /// </summary>
        public static VolumeManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new VolumeManager();
                    tempVolume = 5;
                    volumeLevel = 5;
                    isMuted = false;
                    soundLevel = 3;
                    tempSound = 3;
                }
                return instance;
            }
        }

        /// <summary>
        /// Gets current volume level.
        /// </summary>
        public int VolumeLevel
        {
            get { return VolumeManager.volumeLevel; }
        }

        /// <summary>
        /// Gets current sound level.
        /// </summary>
        public float SoundLevel
        {
            get { return VolumeManager.soundLevel * 0.05f; }
        }

        /// <summary>
        /// Mutes/unmutes game music.
        /// </summary>
        public void Mute()
        {
            bool temp = false;

            if (VolumeManager.isMuted == false)
            {
                VolumeManager.tempVolume = VolumeManager.volumeLevel;
                VolumeManager.volumeLevel = 0;
                MediaPlayer.Volume = 0.0f;
                VolumeManager.tempSound = VolumeManager.soundLevel;
                VolumeManager.soundLevel = 0;
                temp = true;
            }
            else
            {
                VolumeManager.volumeLevel = VolumeManager.tempVolume;
                MediaPlayer.Volume = VolumeManager.volumeLevel * 0.05f;
                VolumeManager.soundLevel = VolumeManager.tempSound;
                temp = false;
            }
            VolumeManager.isMuted = temp;
        }

        /// <summary>
        /// Raises the volume.
        /// </summary>
        public void VolumeUp()
        {
            if (VolumeManager.volumeLevel < 20)
            {
                VolumeManager.volumeLevel += 1;
                VolumeManager.tempVolume = VolumeManager.volumeLevel;
                MediaPlayer.Volume = VolumeManager.volumeLevel * 0.05f;
                VolumeManager.isMuted = false;
            }

            if (VolumeManager.volumeLevel <= 0)
            {
                VolumeManager.volumeLevel = 1;
                VolumeManager.tempVolume = 1;
                MediaPlayer.Volume = 0.05f;
                VolumeManager.isMuted = false;
            }
        }

        /// <summary>
        /// Raises the SFX volume.
        /// </summary>
        public void SoundUp()
        {
            if (VolumeManager.soundLevel < 20)
            {
                VolumeManager.soundLevel += 1;
                VolumeManager.tempSound = VolumeManager.soundLevel;
                VolumeManager.isMuted = false;
            }

            if (VolumeManager.soundLevel <= 0)
            {
                VolumeManager.soundLevel = 1;
                VolumeManager.tempSound = 1;
                MediaPlayer.Volume = 0.05f;
                VolumeManager.isMuted = false;
            }
        }

        /// <summary>
        /// Lowers the SFX volume.
        /// </summary>
        public void SoundDown()
        {
            if (VolumeManager.soundLevel > 0)
            {
                VolumeManager.soundLevel -= 1;
                VolumeManager.tempSound = VolumeManager.soundLevel;
            }
        }

        /// <summary>
        /// Lowers the volume.
        /// </summary>
        public void VolumeDown()
        {
            if (VolumeManager.volumeLevel > 0)
            {
                VolumeManager.volumeLevel -= 1;
                VolumeManager.tempVolume = VolumeManager.volumeLevel;
                MediaPlayer.Volume = VolumeManager.volumeLevel * 0.05f;
            }
        }
    }
}
