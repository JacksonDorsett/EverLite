namespace EverLite
{
    using Microsoft.Xna.Framework.Graphics;

    class PlayerLifeManager
    {
        private PlayerLives lives;
        private Player player;
        private PlayerLivesDisplay display;
        private EverLite game;

        public PlayerLifeManager(EverLite game)
        {
            this.game = game;
            this.lives = new PlayerLives(3);
            this.player = Player.Instance();
            this.display = new PlayerLivesDisplay(this.lives);
            this.player.OnCollide += (sender, e) => { this.lives.TakeDamage(); };
            //this.lives.OnDeath += (sender, e) => { this.game.ChangeMusic(this.game.Megalovania);  this.game.SwitchScene(this.game.GameOverScene); };
            this.lives.OnDeath += (sender, e) => { this.game.ChangeMusic(this.game.Megalovania); this.game.SceneManager.SwitchScene(this.game.SceneManager.GameOver); };
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.display.Draw(spriteBatch);
        }
    }
}
