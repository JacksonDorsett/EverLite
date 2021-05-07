namespace EverLite.Models.Items
{
    using ScriptInterperiter;
    using Microsoft.Xna.Framework;
    using System;
    using System.Collections.Generic;

    class ItemsFactory
    {
        public static Item Create(string type, Vector2 position)
        {
            switch (type)
            {
                case "seismic":
                    return new SeismicCharge(SpriteLoader.LoadSprite("sesmic_charge"), MovementFactory.Create("Stationary", 0, new List<Vector2>() { position }));
                default:
                    throw new NotImplementedException("other types of items are not supported");

            }
        }
    }
}
