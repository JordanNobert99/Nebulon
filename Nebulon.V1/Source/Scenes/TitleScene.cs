using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebulon.V1.Source.Scenes
{
    public class TitleScene : Scene
    {

        public TitleScene(GraphicsDevice graphicsDevice) : base(graphicsDevice) { }

        public override void LoadContent()
        {
            base.LoadContent();

            // Load the Title Scene resources
        }

        public override void UnloadContent()
        {
            base.UnloadContent();

            // Unload resources
        }

        public override void Update(GameTime gameTime)
        {
            // Handle input, buttons, and scene swapping
        }

        public override void DrawGame(GameTime gameTime, SpriteBatch spriteBatch)
        {
            // Draw the game
        }
        public override void DrawUI(GameTime gameTime, SpriteBatch spriteBatch)
        {
            // Draw the UI
        }
    }
}
