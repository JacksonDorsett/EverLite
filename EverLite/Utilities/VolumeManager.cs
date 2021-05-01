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
                temp = true;
            }
            else
            {
                VolumeManager.volumeLevel = VolumeManager.tempVolume;
                MediaPlayer.Volume = VolumeManager.volumeLevel * 0.05f;
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
