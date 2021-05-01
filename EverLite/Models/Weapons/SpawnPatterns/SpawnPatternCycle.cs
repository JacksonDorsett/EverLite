using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Linq;
namespace EverLite.Models.Weapons.SpawnPatterns
{
    class SpawnPatternCycle : SpawnPattern
    {
        private SpawnPattern[] spawnPatterns;
        private IEnumerator current;
        private bool currentStatus;
        public SpawnPatternCycle(List<Bullet> bullets, SpawnPattern[] patterns) : base(bullets, new NoSprite(), 0, 0, 0)
        {
            this.spawnPatterns = patterns;
            foreach (var i in spawnPatterns)
            {
                i.OnComplete += this.MoveNext;
            }
            current = patterns.GetEnumerator();
            currentStatus = current.MoveNext();
        }

        public override bool IsEnabled { get => base.IsEnabled && currentStatus; set => base.IsEnabled = value; }

        public override SpawnPattern Clone()
        {
            List<SpawnPattern> lp = new List<SpawnPattern>();
            foreach (var p in spawnPatterns)
            {
                lp.Add(p.Clone());
            }
            return new SpawnPatternCycle(bulletList, lp.ToArray());
        }

        protected override void Spawn(Vector2 spawnPosition)
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime, Vector2 position)
        {
            (this.current.Current as SpawnPattern).Update(gameTime, position);
            
        }

        private void MoveNext(object o, EventArgs e)
        {
            currentStatus = current.MoveNext();
        }
    }
}
