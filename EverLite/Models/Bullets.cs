namespace EverLite.Models
{
    using EverLite.Models;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// The Bullet class created will handle the special stuff the bullets can do.
    /// </summary>
    public class Bullets : Sprite
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Bullets"/> class.
        /// Sets isActive, angle, velocity, and spriteType fields.
        /// </summary>
        public Bullets()
            : base(true, 0, 8.0f, FactoryEnum.Bullets)
        { // TODO: Adjust bullet constructor.
        }

        /// <inheritdoc/>
        public override void Initialize(Texture2D texture, Vector2 position)
        {
            // TODO: Fix bullet logic here.
            this.texture = texture;
            this.sPosition = position;
        }

        /// <inheritdoc/>
        public override void Update()
        {
            // TODO: Add bullet update stuff.
        }

        /// <inheritdoc/>
        public override void Draw(SpriteBatch spriteBatch)
        {
            // TODO: Add bullet draw stuff.
        }
    }
}
