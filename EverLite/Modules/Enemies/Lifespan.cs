// <copyright file="Lifespan.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.Enemies
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.Xna.Framework;

    /// <summary>
    /// 
    /// </summary>
    public class Lifespan : IUpdateable
    {
        private double totalLifespan;
        private double currentLifespan;

        /// <summary>
        /// Initializes a new instance of the <see cref="Lifespan"/> class.
        /// </summary>
        /// <param name="totalLifespan">specifies how long the object will be alive.</param>
        public Lifespan(double totalLifespan)
        {
            this.totalLifespan = totalLifespan;
            this.currentLifespan = 0;
        }

        public event EventHandler<EventArgs> EnabledChanged;

        public event EventHandler<EventArgs> UpdateOrderChanged;

        /// <summary>
        /// Gets the progression through the lifespan.
        /// </summary>
        public double Halflife {
            get
            {
                if (this.currentLifespan > this.totalLifespan)
                {
                    return 1;
                }

                return this.currentLifespan / this.totalLifespan;
            }
        }

        public bool Enabled => true;

        public int UpdateOrder => 10;

        public void Update(GameTime gameTime)
        {
            if (this.Halflife < 1)
            {
                this.currentLifespan += gameTime.ElapsedGameTime.TotalSeconds;
            }

        }
    }
}
