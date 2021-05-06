namespace EverLite
{
    using System;

    class Health
    {
        int totalHealth;
        int currentHealth;
        private SoundManager sound;

        public Health(int health)
        {
            this.totalHealth = this.currentHealth = health;
            this.sound = SoundManager.Instance;
        }

        public event EventHandler OnDeath;

        public int CurrentHealth { get => this.currentHealth; }

        public void TakeDamage(int damage)
        {
            this.currentHealth -= damage;
            if (this.currentHealth <= 0)
            {
                this.OnDeath?.Invoke(this, new EventArgs());
                this.sound.Explosion1.Play();
            }
        }
    }
}
