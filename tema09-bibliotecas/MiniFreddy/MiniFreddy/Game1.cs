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

        private Texture2D enemigo; 
        private Vector2 posicionEnemigo; 
        private Vector2 velocidadEnemigo;

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
            base.Initialize();

            posicionPersonaje = new Vector2(400, 500);
            posicionEnemigo = new Vector2(300, 100);
            velocidadEnemigo = new Vector2(150, 100);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            personaje = Content.Load<Texture2D>("personaje");
            enemigo = Content.Load<Texture2D>("enemigo");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
                    || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Movimiento del personaje, con teclado
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

            // Movimiento automático del enemigo
            posicionEnemigo.X += velocidadEnemigo.X * 
                (float)gameTime.ElapsedGameTime.TotalSeconds; 
            posicionEnemigo.Y += velocidadEnemigo.Y * 
                (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Rebote en los bordes. TO DO: Evitar "números mágicos"
            if ((posicionEnemigo.X < 20) || (posicionEnemigo.X > 1200)) 
                velocidadEnemigo.X = -velocidadEnemigo.X; 
            if ((posicionEnemigo.Y < 20) || (posicionEnemigo.Y > 700))
                velocidadEnemigo.Y = -velocidadEnemigo.Y;

            // Comprobación de colisiones
            if (new Rectangle((int)posicionPersonaje.X, (int)posicionPersonaje.Y, 
                personaje.Width, personaje.Height).Intersects(
                    new Rectangle((int)posicionEnemigo.X, (int)posicionEnemigo.Y, 
                    enemigo.Width, enemigo.Height))) 
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(32, 32, 32));

            _spriteBatch.Begin();
            _spriteBatch.Draw(enemigo, 
                new Rectangle((int)posicionEnemigo.X, (int)posicionEnemigo.Y, 
                    enemigo.Width, enemigo.Height), Color.White);
            _spriteBatch.Draw(personaje,
                new Rectangle((int)posicionPersonaje.X, (int)posicionPersonaje.Y, 
                    personaje.Width, personaje.Height),
                Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
