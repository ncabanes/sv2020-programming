using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MiniFreddy
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D personaje;
        private Vector2 posicionPersonaje;
        private int velocidadPersonaje = 200;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            _graphics.PreferredBackBufferWidth = 1280; 
            _graphics.PreferredBackBufferHeight = 720; 
            _graphics.ApplyChanges();
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            posicionPersonaje = new Vector2(400, 500);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            personaje = Content.Load<Texture2D>("personaje");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
                    || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            var estadoTeclado = Keyboard.GetState();

            if (estadoTeclado.IsKeyDown(Keys.Left)) 
                posicionPersonaje.X -= velocidadPersonaje * 
                    (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (estadoTeclado.IsKeyDown(Keys.Right))
                posicionPersonaje.X += velocidadPersonaje *
                    (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (estadoTeclado.IsKeyDown(Keys.Up))
                posicionPersonaje.Y -= velocidadPersonaje *
                    (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (estadoTeclado.IsKeyDown(Keys.Down))
                posicionPersonaje.Y += velocidadPersonaje *
                    (float)gameTime.ElapsedGameTime.TotalSeconds;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(32, 32, 32));

            _spriteBatch.Begin(); 
            _spriteBatch.Draw(personaje,
                new Rectangle((int)posicionPersonaje.X, (int)posicionPersonaje.Y, 
                    personaje.Width, personaje.Height),
                Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
