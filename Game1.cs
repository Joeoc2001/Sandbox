using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HeeseungSandbox
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _blankRectangle;

        private Vector2 _orangeRectPos;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _orangeRectPos = new Vector2(100, 100);
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _blankRectangle = new Texture2D(GraphicsDevice, 1, 1);
            _blankRectangle.SetData(new[] { Color.White });
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();

            _spriteBatch.Dispose();
            _blankRectangle.Dispose();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            _orangeRectPos.X += (float)(gameTime.ElapsedGameTime.TotalSeconds * 40.0);
            _orangeRectPos.Y += (float)(gameTime.ElapsedGameTime.TotalSeconds * 20.0);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            _spriteBatch.Draw(_blankRectangle, new Rectangle((int)_orangeRectPos.X, (int)_orangeRectPos.Y, 10, 10), Color.Orange);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}