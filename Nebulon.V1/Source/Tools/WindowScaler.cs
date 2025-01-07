using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebulon.V1.Source.Tools
{
    public class WindowScaler
    {
        private GraphicsDeviceManager graphics;
        private int designedWidth;
        private int designedHeight;

        public Rectangle ScaledViewport { get; private set; }
        public Matrix ScaledMatrix { get; private set; }
        
        public WindowScaler(GraphicsDeviceManager graphics, int designedWidth, int designedHeight)
        {
            this.graphics = graphics;
            this.designedWidth = designedWidth;
            this.designedHeight = designedHeight;
        }

        public void ApplyScaling()
        {
            // Get the actual window size
            int windowWidth = graphics.GraphicsDevice.PresentationParameters.BackBufferWidth;
            int windowHeight = graphics.GraphicsDevice.PresentationParameters.BackBufferHeight;

            // Calculate the aspect ratios
            float designedAspectRatio = (float)designedWidth / designedHeight;
            float windowAspectRatio = (float)windowWidth / windowHeight;

            // Determine the scale factor
            float scaleH = (float)windowHeight / designedHeight;
            float scaleW = (float)windowWidth / designedWidth;
            float scale = windowAspectRatio > designedAspectRatio ? scaleH : scaleW;

            // Calculate the viewport dimensions
            int viewportWidth = (int)(designedWidth * scale);
            int viewportHeight = (int)(designedHeight * scale);
            int viewportX = (windowWidth - viewportWidth) / 2;
            int viewportY = (windowHeight - viewportHeight) / 2;

            // Set the viewport
            ScaledViewport = new Rectangle(viewportX, viewportY, viewportWidth, viewportHeight);
            graphics.GraphicsDevice.Viewport = new Viewport(ScaledViewport);

            // Calculate the scale matrix
            ScaledMatrix = Matrix.CreateScale(
                (float)viewportWidth / designedWidth,
                (float)viewportHeight / designedHeight,
                1f);
        }

        public Vector2 ScaleInput(Vector2 input)
        {
            return new Vector2(
                (input.X - ScaledViewport.X) / ScaledViewport.Width * designedWidth,
                (input.Y - ScaledViewport.Y) / ScaledViewport.Height * designedHeight);
        }

    }
}
