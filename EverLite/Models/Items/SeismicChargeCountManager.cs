using EverLite.Models.PlayerModel;
using EverLite.ScriptInterperiter;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace EverLite.Models.Items
{
    class SeismicChargeCountManager
    {
        private SeismicChargeCount charges;
        private Player player;
        private SeismicChargesDisplay display;
        private EverLite game;
        private List<SeismicCharge> deployedBombs = new List<SeismicCharge>() { };
        private uint lastScore = 0;

        public List<SeismicCharge> DeployedBombs
        {
            get
            {
                return this.deployedBombs;
            }
        }

        public SeismicChargeCountManager(EverLite game)
        {
            this.game = game;
            charges = new SeismicChargeCount(3);
            player = Player.Instance();
            display = new SeismicChargesDisplay(charges);
            player.OnBombPress += (sender, e) => { this.deployedBombs.Add(charges.SpawnBomb(this.player.Position)); };
            player.OnBombPickup += (sender, e) => { this.charges.AddCharge(); };
        }

        public void Update(GameTime gameTime)
        {
            GameScore score = GameScore.Instance;
            uint diff = score.Score - lastScore;
            if (diff > 1000)
            {
                lastScore = score.Score;
                Random rand = new Random();
                Vector2 position = new Vector2(rand.Next(1, 1500), rand.Next(1, 1080));
                SeismicCharge charge = new SeismicCharge(SpriteLoader.LoadSprite("sesmic_charge"), MovementFactory.Create("Stationary", 0, new List<Vector2>() { position }));
                ItemsManager.Instance.Add(charge);
            }

            foreach (SeismicCharge charge in this.deployedBombs)
            {
                if (charge.IsAlive)
                {
                    charge.Update(gameTime);
                }
            }
            this.deployedBombs.RemoveAll(s => !s.IsAlive); // clean up
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            display.Draw(spriteBatch);
            foreach (SeismicCharge charge in this.deployedBombs)
            {
                if (charge.IsAlive)
                {
                    charge.Draw(spriteBatch);
                }
            }
        }
    }
}
