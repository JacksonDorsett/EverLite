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
        int index = 0;

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

        public override bool IsEnabled { get => currentStatus; set { if (current != null) (current.Current as SpawnPattern).IsEnabled = value; } }

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
            var c = this.current.Current as SpawnPattern;
            if (currentStatus) c.Update(gameTime, position);
            
        }

        private void MoveNext(object o, EventArgs e)
        {
            currentStatus = current.MoveNext();
            if (currentStatus)
            {
                //this.Invoke();
                (current.Current as SpawnPattern).IsEnabled = true;
            }
        }
    }
}
