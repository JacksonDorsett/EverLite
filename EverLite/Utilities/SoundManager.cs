namespace EverLite
{
    using Microsoft.Xna.Framework.Audio;
    using Microsoft.Xna.Framework.Media;

    public class SoundManager
    {
        private static SoundManager instance;
        
        private static SoundEffect explosion;
        private static SoundEffect explosion1;
        private static SoundEffect gunShot;
        private static SoundEffect laserShot;
        private static SoundEffect laserShot1;
        private static SoundEffect losing;

        private static Song deepSpace;
        private static Song megalovania;
        private static Song solarSystem;
        private static Song menuBG;


        private SoundManager()
        {
        }

        public static SoundManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SoundManager();
                }
                return instance;
            }
        }

        public Song DeepSpace
        {
            get { return SoundManager.deepSpace; }
        }

        public Song Megalovania
        {
            get { return SoundManager.megalovania; }
        }

        public Song SolarSystem
        {
            get { return SoundManager.solarSystem; }
        }

        public Song MenuBG
        {
            get { return SoundManager.menuBG; }
        }

        public SoundEffect Explosion
        {
            get { return SoundManager.explosion; }
        }

        public SoundEffect Explosion1
        {
            get { return SoundManager.explosion1; }
        }

        public SoundEffect GunShot
        {
            get { return SoundManager.gunShot; }
        }

        public SoundEffect Losing
        {
            get { return SoundManager.losing; }
        }

        public SoundEffect LaserShot
        {
            get { return SoundManager.laserShot; }
        }

        public SoundEffect LaserShot1
        {
            get { return SoundManager.laserShot1; }
        }

        public void SetDeepSpaceMusic(Song s)
        {
            if (SoundManager.deepSpace == null)
                SoundManager.deepSpace = s;
        }

        public void SetMegalovaniaMusic(Song s)
        {
            if (SoundManager.megalovania == null)
                SoundManager.megalovania = s;
        }

        public void SetSolarSystemMusic(Song s)
        {
            if (SoundManager.solarSystem == null)
                SoundManager.solarSystem = s;
        }

        public void SetMenuBGMusic(Song s)
        {
            if (SoundManager.menuBG == null)
                SoundManager.menuBG = s;
        }

        public void SetGunShotSound(SoundEffect se)
        {
            if (SoundManager.gunShot == null)
                SoundManager.gunShot = se;
        }

        public void SetExplosionSound(SoundEffect se)
        {
            if (SoundManager.explosion == null)
                SoundManager.explosion = se;
        }

        public void SetExplosion1Sound(SoundEffect se)
        {
            if (SoundManager.explosion1 == null)
                SoundManager.explosion1 = se;
        }

        public void SetLaserShotSound(SoundEffect se)
        {
            if (SoundManager.laserShot == null)
                SoundManager.laserShot = se;
        }

        public void SetLaserShot1Sound(SoundEffect se)
        {
            if (SoundManager.laserShot1 == null)
                SoundManager.laserShot1 = se;
        }

        public void SetLosingSound(SoundEffect se)
        {
            if (SoundManager.losing == null)
                SoundManager.losing = se;
        }
    }
}
