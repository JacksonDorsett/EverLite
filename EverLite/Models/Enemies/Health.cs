namespace EverLite
{
    using System;

    class Health
    {
        int totalHealth;
        int currentHealth;
        private SoundManager sound;
        private VolumeManager volume;

        public Health(int health)
        {
            this.totalHealth = this.currentHealth = health;
            this.sound = SoundManager.Instance;
            this.volume = VolumeManager.Instance;
        }

        public event EventHandler OnDeath;

        public int CurrentHealth { get => this.currentHealth; }

        public void TakeDamage(int damage)
        {
            this.currentHealth -= damage;
            if (this.currentHealth <= 0)
            {
                this.OnDeath?.Invoke(this, new EventArgs());

                this.sound.Explosion1.Play(volume: volume.SoundLevel, pitch: 0.0f, pan: 0.0f);
            }
        }
    }
}
