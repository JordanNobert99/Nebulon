using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebulon.V1.Source.Scenes
{
    public abstract class Scene
    {
        protected GraphicsDevice GraphicsDevice;

        public Scene(GraphicsDevice graphicsDevice)
        {
            GraphicsDevice = graphicsDevice;
        }

        // Initialize resources for the scene
        public virtual void Initialize() { }

        // Load Content specific to the scene
        public virtual void LoadContent() { }

        // Unload resources when the scene is unloaded
        public virtual void UnloadContent() { }

        // Handle scene-specific logic
        public abstract void Update(GameTime gameTime);

        // Handle scene-specific rendering
        public abstract void DrawGame(GameTime gameTime, SpriteBatch spriteBatch);
        public abstract void DrawUI(GameTime gameTime, SpriteBatch spriteBatch);

    }
}
