namespace EverLite.Models.Items
{
    using System;
    class ItemsSpriteFactory
    {
        public static SpriteN Create(string type)
        {
            switch (type)
            {
                case "seismic":
                    return SpriteLoader.LoadSprite("sesmic_charge");
                default:
                    throw new NotImplementedException("other types of items are not supported");

            }
        }
    }
}
