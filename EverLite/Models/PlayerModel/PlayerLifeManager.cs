namespace EverLite.Models.PlayerModel
{
    using global::EverLite.Models.PlayerModel;
    using Microsoft.Xna.Framework.Graphics;

    class PlayerLifeManager
    {
        private PlayerLives lives;
        private Player player;
        private PlayerLivesDisplay display;
        private EverLite game;
        private SoundManager sound;
        private VolumeManager volume;

        public PlayerLifeManager(EverLite game)
        {
            this.game = game;
            lives = new PlayerLives(3);
            player = Player.Instance();
            sound = SoundManager.Instance;
            volume = VolumeManager.Instance;
            display = new PlayerLivesDisplay(lives);
            player.OnCollide += (sender, e) => { lives.TakeDamage(); };
            lives.OnDeath += (sender, e) => { 
                this.sound.Losing.Play(volume: volume.SoundLevel, pitch: 0.0f, pan: 0.0f); 
                this.game.SceneManager.ChangeMusic(this.sound.Megalovania); 
                this.game.SceneManager.SwitchScene(this.game.SceneManager.GameOver); 
            };
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            display.Draw(spriteBatch);
        }
    }
}
