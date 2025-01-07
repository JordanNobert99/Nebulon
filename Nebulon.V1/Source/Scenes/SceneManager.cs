using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebulon.V1.Source.Scenes
{
    public class SceneManager
    {
        private Scene currentScene;

        public void SetScene(Scene newScene)
        {
            // Unload current scene if it exists
            currentScene?.UnloadContent();

            // Initialize the new scene
            currentScene = newScene;
            currentScene.Initialize();
            currentScene.LoadContent();
        }

        public void Update(GameTime gameTime)
        {
            currentScene?.Update(gameTime);
        }
        public void DrawGame(GameTime gameTime, SpriteBatch spriteBatch)
        {
            currentScene?.DrawGame(gameTime, spriteBatch);
        }
        public void DrawUI(GameTime gameTime, SpriteBatch spriteBatch)
        {
            currentScene?.DrawUI(gameTime, spriteBatch);
        }
    }
}
