using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

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

        private Texture2D llave;
        private Vector2 posicionLlave;

        private int puntos = 0;
        private SpriteFont fuente;
        private System.Random random;

        private const int altoMapa = 15, anchoMapa = 26;
        private int anchoTile = 48, altoTile = 48;
        private int margenIzqdo = 0, margenSuperior = 0;
        private string[] datosNivel = new string[altoMapa];
        private Texture2D pared;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            _graphics.PreferredBackBufferWidth = 1280; 
            _graphics.PreferredBackBufferHeight = 720; 
            _graphics.ApplyChanges();
            IsMouseVisible = true;

            random = new System.Random();
            datosNivel = new string[] {
                "L        V T    T      V L",
                "L               V        L",
                "L                        L",
                "L                    A   L",
                "LSS  SSSSSSSSSFFFF SFSSSSL",
                "L                       VL",
                "LSSS                     L",
                "L                L LL    L",
                "LSSSS   DDDDDDDDDD DDD   L",
                "L                      SSL",
                "L                        L",
                "L            A       FSSSL",
                "L    SSSSSSSSSSSSS SS  PPL",
                "L                      PPL",
                "LLLLLLLLLLLLLLLLLLLLLLLLLL"
            };

        }

        protected override void Initialize()
        {
            base.Initialize();

            posicionPersonaje = new Vector2(400, 500);
            posicionEnemigo = new Vector2(300, 100);
            velocidadEnemigo = new Vector2(150, 100);
            posicionLlave = new Vector2( 
                random.Next(1000, 1100), random.Next(100, 600));
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            personaje = Content.Load<Texture2D>("personaje");
            enemigo = Content.Load<Texture2D>("enemigo");
            llave = Content.Load<Texture2D>("llave");
            pared = Content.Load<Texture2D>("pared");
            fuente = Content.Load<SpriteFont>("Bitwise");            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
                    || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Movimiento del personaje, con teclado y gamepad
            var estadoTeclado = Keyboard.GetState();
            var estadoGamePad = GamePad.GetState(PlayerIndex.One);

            if (estadoTeclado.IsKeyDown(Keys.Left)
                || estadoGamePad.DPad.Left > 0
                || estadoGamePad.ThumbSticks.Right.X < 0
                || estadoGamePad.ThumbSticks.Left.X < 0)
            {
                float nuevaX = posicionPersonaje.X - velocidadPersonaje *
                    (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (EsPosibleMover((int) nuevaX, (int) posicionPersonaje.Y,
                        personaje.Width, personaje.Height))
                    posicionPersonaje.X = nuevaX;
            }

            if (estadoTeclado.IsKeyDown(Keys.Right)
                || estadoGamePad.DPad.Right > 0
                || estadoGamePad.ThumbSticks.Right.X > 0
                || estadoGamePad.ThumbSticks.Left.X > 0)

                {
                    float nuevaX = posicionPersonaje.X + velocidadPersonaje *
                    (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (EsPosibleMover((int)nuevaX, (int)posicionPersonaje.Y,
                        personaje.Width, personaje.Height))
                    posicionPersonaje.X = nuevaX;
            }

            // TO DO: Comprobar colisiones en vertical
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

            // Comprobación de colisiones con enemigo
            if (new Rectangle((int)posicionPersonaje.X, (int)posicionPersonaje.Y, 
                personaje.Width, personaje.Height).Intersects(
                    new Rectangle((int)posicionEnemigo.X, (int)posicionEnemigo.Y, 
                    enemigo.Width, enemigo.Height))) 
                Exit();

            // Comprobación de colisiones con llave
            if (new Rectangle((int)posicionPersonaje.X, (int)posicionPersonaje.Y,
                personaje.Width, personaje.Height).Intersects(
                    new Rectangle((int)posicionLlave.X, (int)posicionLlave.Y,
                    llave.Width, llave.Height)))
            {
                puntos += 10;
                posicionLlave = new Vector2(
                    random.Next(1000, 1100), random.Next(100, 600));
                velocidadEnemigo.X *= 1.2f;
                velocidadEnemigo.Y *= 1.2f;
            }

            base.Update(gameTime);
        }

        private bool EsPosibleMover(int x, int y, int ancho, int alto)
        {
            for (int fila = 0; fila < altoMapa; fila++)
            {
                for (int colum = 0; colum < anchoMapa; colum++)
                {
                    int posX = colum * anchoTile + margenIzqdo;
                    int posY = fila * altoTile + margenSuperior;
                    switch (datosNivel[fila][colum])
                    {
                        case 'L':

                            if (new Rectangle(x, y, ancho, alto)
                                    .Intersects(new Rectangle(
                                        posX, posY, anchoTile, altoTile)))
                                return false;
                            break;
                    }
                }
            }
            return true;
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(32, 32, 32));

            _spriteBatch.Begin();

            for (int fila = 0; fila < altoMapa; fila++)
            {
                for (int colum = 0; colum < anchoMapa; colum++)
                {
                    int posX = colum * anchoTile + margenIzqdo;
                    int posY = fila * altoTile + margenSuperior;
                    switch (datosNivel[fila][colum])
                    {
                        case 'L':
                            _spriteBatch.Draw(pared,
                                new Rectangle(posX, posY, pared.Width, pared.Height), 
                                Color.White);
                            break;
                    }
                }
            }

            _spriteBatch.Draw(enemigo, 
                new Rectangle((int)posicionEnemigo.X, (int)posicionEnemigo.Y, 
                    enemigo.Width, enemigo.Height), Color.White);
            _spriteBatch.Draw(personaje,
                new Rectangle((int)posicionPersonaje.X, (int)posicionPersonaje.Y, 
                    personaje.Width, personaje.Height),
                Color.White);
            _spriteBatch.Draw(llave,
                new Rectangle((int)posicionLlave.X, (int)posicionLlave.Y,
                    llave.Width, llave.Height),
                Color.White);
            _spriteBatch.DrawString(fuente, 
                "Puntos: " + puntos, 
                new Vector2(50, 10), Color.Yellow);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
