using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EverLite.Components
{
    public class SceneManager
    {
        public KeyboardState keyboardState;
        private KeyboardState previousKeyboardState;


        // GameScenes for each window.
        private GameScene MenuScene;
        private GameScene TopTenScene;
        private GameScene GameWonScene;
        private GameScene GameOverScene;
        EverLite game;
        public SceneManager(EverLite game)
        {
            this.game = game;
            Initialize();
        }

        public GameScene Menu => MenuScene;

        public GameScene GameOver => GameOverScene;

        public GameScene GameWin => GameWonScene;

        public GameScene TopTen => TopTenScene;

        public GameScene NewGame => CreateNewGame();



        private void Initialize()
        {
            // creating background components
            ScrollingStarsBackgroundComponent starfield = new ScrollingStarsBackgroundComponent(game);
            PlanetBackgroundComponent planetBackground = new PlanetBackgroundComponent(game);
            PlanetExplodeBackgroundComponent planetExplodeBackground = new PlanetExplodeBackgroundComponent(game);
            PlanetRingsBackgroundCompnent planetRingsBackground = new PlanetRingsBackgroundCompnent(game);
            // creating window components
            PlayGameComponent level = new PlayGameComponent(game);
            TopTenComponent topTen = new TopTenComponent(game);
            GameWonComponent gameWon = new GameWonComponent(game);
            GameOverComponent gameOver = new GameOverComponent(game);
            MenuItemsComponent menuItems = new MenuItemsComponent(game, new Vector2(700, 250), Color.Red, Color.Yellow);

            // Listing menu options. Room to grow if we want more options.
            menuItems.AddItem("Play");
            menuItems.AddItem("Top Scores");
            menuItems.AddItem("Quit");
            MenuComponent menu = new MenuComponent(game, menuItems);

            // Putting together the GameScenes, each using a background component and a window component.
            this.MenuScene = new GameScene(game, planetBackground, menu);
            this.TopTenScene = new GameScene(game, planetBackground, topTen);
            this.GameWonScene = new GameScene(game, planetRingsBackground, gameWon);
            this.GameOverScene = new GameScene(game, planetExplodeBackground, gameOver);
            this.MenuScene = new GameScene(game, planetBackground, menu, menuItems);

            // disabling components
            foreach (GameComponent component in game.Components)
            {
                ChangeComponentState(component, false);
            }
        }

        // Resets the levelScene (where the game is played) when player wants to play again.
        public GameScene CreateNewGame()
        {
            PlayGameComponent level = new PlayGameComponent(game);
            ScrollingStarsBackgroundComponent starfield = new ScrollingStarsBackgroundComponent(game);
            return new GameScene(game, starfield, level);
        }

        // Manages the components state for the scenes so that only enabled scenes show.
        private void ChangeComponentState(GameComponent component, bool enabled)
        {
            component.Enabled = enabled;
            if (component is DrawableGameComponent)
                ((DrawableGameComponent)component).Visible = enabled;
        }

        // Switches to new windows
        public void SwitchScene(GameScene scene)
        {
            GameComponent[] usedComponents = scene.ReturnComponents();
            foreach (GameComponent component in game.Components)
            {
                bool isUsed = usedComponents.Contains(component);
                ChangeComponentState(component, isUsed);
            }
            previousKeyboardState = keyboardState;
        }
    }
}
