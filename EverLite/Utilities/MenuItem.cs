namespace EverLite
{
    using Microsoft.Xna.Framework;

    public class MenuItem
    {
        public string text;
        public Vector2 position;
        public float size;
        
        public MenuItem(string text, Vector2 position)
        {
            this.text = text;
            this.position = position;
            size = 0.6f;
        }
    }
}
