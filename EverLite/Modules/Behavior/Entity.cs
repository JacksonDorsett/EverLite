


namespace EverLite.Modules.Behavior
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EverLite.Modules.Sprites;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Represents an entity displayed on the screen.
    /// </summary>
    public abstract class Entity
    {
        public Entity(SpriteN sprite)
        {
            this.Sprite = sprite;
        }
        /// <summary>
        /// gets or sets the position of the entity.
        /// </summary>
        public abstract Vector2 Position { get; protected set; }

        /// <summary>
        /// gets or sets the Sprite of the Entity.
        /// </summary>
        public abstract SpriteN Sprite { get; protected set; }

        /// <summary>
        /// Update Entity every frame.
        /// </summary>
        /// <param name="gameTime">game time object.</param>
        public abstract void Update(GameTime gameTime);

        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
