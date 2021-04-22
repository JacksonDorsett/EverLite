namespace EverLite
{
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Shooting pattern interface.
    /// </summary>
    interface IShootingPattern
    {
        void Shoot(Vector2 position);
    }
}
