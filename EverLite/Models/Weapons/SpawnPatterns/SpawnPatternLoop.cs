using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EverLite.Models.Weapons.SpawnPatterns
{
    class SpawnPatternLoop : SpawnPatternCycle
    {

        SpawnPattern[] spawnPatterns;
        public SpawnPatternLoop(List<Bullet> bullets, SpawnPattern[] patterns) : base(bullets, patterns)
        {

            
            spawnPatterns = patterns;
            
        }

        //public override bool IsEnabled { get => cycle.IsEnabled; set { if (cycle != null) cycle.IsEnabled = value; } }

       

        public override void Update(GameTime gameTime, Vector2 position)
        {
            
            if(IsEnabled) base.Update(gameTime, position);
            if (!IsEnabled)
            {
                Reset();
            }
        }

        protected override void Spawn(Vector2 spawnPosition)
        {
            throw new NotImplementedException();
        }
    }
}
