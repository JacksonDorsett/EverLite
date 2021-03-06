namespace EverLite
{
    using Microsoft.Xna.Framework;
    using System.Collections.Generic;

    public class GameScene
    {
        private List<GameComponent> components;
        private EverLite game;

        public GameScene(EverLite game, params GameComponent[] components)
        {
            this.game = game;
            this.components = new List<GameComponent>();
            foreach (GameComponent component in components)
            {
                AddComponent(component);
            }
        }

        public void AddComponent(GameComponent component)
        {
            components.Add(component);
            if (!game.Components.Contains(component))
                game.Components.Add(component);
        }

        public GameComponent[] ReturnComponents()
        {
            return components.ToArray();
        }
    }
}
