using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nebulon.V1.Source.Scenes;
using Nebulon.V1.Source.Tools;

namespace Nebulon.V1.Source
{
    public class GameLoop : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private WindowScaler windowScaler;

        private TitleScene titleScene;
        private SceneManager sceneManager;

        public GameLoop()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            graphics.PreferredBackBufferWidth = 1080;
            graphics.PreferredBackBufferHeight = 1920;
            graphics.IsFullScreen = false;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            windowScaler = new WindowScaler(graphics, 1080, 1920);

            titleScene = new TitleScene(GraphicsDevice);
            sceneManager = new SceneManager();
            sceneManager.SetScene(titleScene);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            sceneManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            windowScaler.ApplyScaling();
            GraphicsDevice.Clear(new(9,9,9));

            // Game
            spriteBatch.Begin(transformMatrix: windowScaler.ScaledMatrix, samplerState: SamplerState.PointClamp);
            sceneManager.DrawGame(gameTime, spriteBatch);

            spriteBatch.End();

            // UI
            spriteBatch.Begin(transformMatrix: windowScaler.ScaledMatrix, samplerState: SamplerState.PointClamp);
            sceneManager.DrawUI(gameTime, spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
