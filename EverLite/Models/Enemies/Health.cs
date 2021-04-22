namespace EverLite
{
    using System;

    class Health
    {
        int totalHealth;
        int currentHealth;

        public Health(int health)
        {
            this.totalHealth = this.currentHealth = health;
        }

        public event EventHandler OnDeath;

        public int CurrentHealth { get => this.currentHealth; }

        public void TakeDamage(int damage)
        {
            this.currentHealth -= damage;
            if (this.currentHealth <= 0)
            {
                this.OnDeath?.Invoke(this, new EventArgs());
            }
        }
    }
}
