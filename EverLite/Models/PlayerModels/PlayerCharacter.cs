// <copyright file="PlayerCharacter.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Object class of the player character.
    /// </summary>
    public class PlayerCharacter
    {
        private readonly List<BasicWeapon> weaponChoices;
        private HealthBar healthbar;
        private BasicWeapon tempWeapon;

        public Texture2D PlayerTexture;
        public Vector2 Position;
        public bool Active;
        public float angle;
        public int Width { get; }
        public int Height { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerCharacter"/> class.
        /// Initializes the weaponlist.
        /// </summary>
        public PlayerCharacter()
        {
            this.weaponChoices = new List<BasicWeapon>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerCharacter"/> class.
        /// Initializes the weaponlist.
        /// </summary>
        /// <param name="temp">Initial weapon.</param>
        public PlayerCharacter(BasicWeapon temp)
        {
            this.weaponChoices = new List<BasicWeapon>();
            this.AddNewWeapon(temp);
        }

        public void Initialize(Texture2D texture, Vector2 position)

        {
            PlayerTexture = texture;

            // Set the starting position of the player around the middle of the screen and to the back
            Position = position;

            // Set the player to be active
            Active = true;

            // Set the player health
            //Health = 100;

            angle = 0;
        }


        /// <summary>
        /// Sometimes, these summaries are just a waste of time and total distraction to reading the code.
        /// </summary>
        /// <returns>The players </returns>
        public HealthBar GetHealthBar()
        {
            return this.healthbar;
        }

        /// <summary>
        /// Returns the player's current health.
        /// </summary>
        /// <returns>Current health.</returns>
        public int GetCurrentHealth()
        {
            return this.healthbar.CurrentHealth;
        }

        /// <summary>
        /// Checks to see if player already has the weapontype.
        /// If already exists, adds the new ammo amount.
        /// If false, adds the new weapon to the list.
        /// </summary>
        /// <param name="weapon">new weapon.</param>
        public void AddNewWeapon(BasicWeapon weapon)
        {
            int answer = this.DoesPlayerHaveWeapon(weapon);
            if (answer == -1)
            {
                this.weaponChoices.Add(weapon);
            }
            else
            {
                this.weaponChoices[answer].AddAmmo(weapon.AmmoCount);
            }
        }

        /// <summary>
        /// Returns -1 if weapon is not on list, otherwise returns index position.
        /// </summary>
        /// <param name="weapon">New weapon for comparison</param>
        /// <returns>Index position in list.</returns>
        public int DoesPlayerHaveWeapon(BasicWeapon weapon)
        {
            for (int index = 0; index < this.weaponChoices.Count(); index++)
            {
                if (this.weaponChoices[index] == weapon)
                {
                    return index;
                }
            }

            return -1;
        }

        public List<BasicWeapon> CurrentWeaponList()
        {
            return this.weaponChoices;
        }

        public BasicWeapon GetWeapon(BasicWeapon weapon)
        {
            for (int index = 0; index < this.weaponChoices.Count(); index++)
            {
                if (this.weaponChoices[index] == weapon)
                {
                    return this.weaponChoices[index];
                }
            }

            return null;
        }

        /// <summary>
        /// Sometimes, these summaries are just a waste of time and total distraction to reading the code.
        /// </summary>
        /// <param name="value">Starting and maximum health.</param>
        public void SetHealthbar(HealthBar value)
        {
            this.healthbar = value;
        }


        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 origin;
            origin.X = PlayerTexture.Width / 2;
            origin.Y = PlayerTexture.Height / 2;
            spriteBatch.Draw(PlayerTexture, Position, null, Color.White, angle, origin, .5f,
            SpriteEffects.None, 0f);
        }
    }
}
