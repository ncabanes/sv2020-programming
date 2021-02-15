/* Eduardo (...)
 * 
 * Crea una nueva versión de PacMan (ejercicio 135), partiendo de la 
 * solución oficial, con los siguientes cambios:
 * - La clase Sprite debe ser abstracta.
 * - No debe haber constructor vacío en Fantasma.
 * - Cada subtipo de fantasma debe tener un constructor vacío, que prefije unas 
 *   ciertas coordenadas, además del constructor que recibe X e Y.
 * - El "Mover" de cada fantasma hará algo "creíble pero sencillo". Por 
 *   ejemplo, el fantasma rojo puede moverse una posición hacia la derecha 
 *   (x++), el azul una posición hacia abajo (x--), etc.
 * - El "Mover" de cada fantasma hará algo "creíble pero sencillo". Por 
 *   ejemplo, el fantasma rojo puede moverse una posición hacia la derecha 
 *   (x++), el azul una posición hacia abajo (x--), etc.
 * - El cuerpo del programa repetirá, hasta que se pulse ESC: esperar una 
 *   tecla, mover a Pac en la dirección escogida por el usuario (en caso de que 
 *   haya pulsado una de las 4 flechas de dirección), mover a los 4 fantasmas 
 *   (una posición), dibujar los 5 sprites. 
 *   Los fantasmas se moverán a saltos, pero no es problema en esta versión. 
 *   Recuerda reutilizar código donde sea posible.
 */


using System;

class PruebaPacMan
{
    static void Main()
    {
        bool salir = false;

        Pac p = new Pac(13, 10);
        p.Mostrar();
        p.Mover();
        Fantasma[] fantasmas = new Fantasma[4];
        fantasmas[0] = new FantasmaRojo(15, 11);
        fantasmas[1] = new FantasmaNaranja(17, 12);
        fantasmas[2] = new FantasmaRosa(19, 13);
        fantasmas[3] = new FantasmaAzul(21, 14);

        do
        {
            p.Mostrar();

            for (int i = 0; i < fantasmas.Length; i++)
            {
                fantasmas[i].Mostrar();
            }

            ConsoleKeyInfo tecla = Console.ReadKey();

            switch (tecla.Key)
            {
                case ConsoleKey.Escape:
                    salir = true;
                    break;
                case ConsoleKey.LeftArrow:
                    p.X--;
                    break;
                case ConsoleKey.RightArrow:
                    p.X++;
                    break;
                case ConsoleKey.UpArrow:
                    p.Y--;
                    break;
                case ConsoleKey.DownArrow:
                    p.Y++;
                    break;
                default:
                    break;
            }
            foreach (Fantasma f in fantasmas)
                f.Mover();

            Console.Clear();

            foreach (Fantasma f in fantasmas)
                f.Mostrar();

            p.Mostrar();

        }
        while (!salir);
    }
}

// ---------------------------------

abstract class Sprite
{

    public int X { get; set; }
    public int Y { get; set; }

    public char caracter { get; set; }

    public virtual void Mover()
    {

    }

    public void Mostrar()
    {
        Console.SetCursorPosition(X, Y);
        Console.Write(caracter + " ");
    }
}

// ---------------------------------

class Pac : Sprite
{
    public Pac(int X, int Y)
    {
        this.X = X;
        this.Y = Y;
        caracter = 'C';
    }

    public override void Mover()
    {
    }
}

// ---------------------------------


class Fantasma : Sprite
{
    //public Fantasma() { }
    public Fantasma(int X, int Y)
    {
        this.X = X;
        this.Y = Y;
        caracter = 'A';
    }
}

// ---------------------------------

class FantasmaRojo : Fantasma
{
    public FantasmaRojo(int X, int Y) : base(X ,Y)

    {
        this.X = X;
        this.Y = Y;
        caracter = 'A';
    }
    
    public FantasmaRojo() : this(20,20)
    {
    }

    public override void Mover()
    {
        X--;
    }
}

// ---------------------------------

class FantasmaNaranja : Fantasma
{
    public FantasmaNaranja(int X, int Y) : base (X, Y)
    {
        this.X = X;
        this.Y = Y;
        caracter = 'A';
    }
    
    public FantasmaNaranja() : this(25, 25)
    {  
    }

    public override void Mover()
    {
        X++;
    }
}

// ---------------------------------

class FantasmaRosa : Fantasma
{
    public FantasmaRosa(int X, int Y) : base (X, Y)
    {
        this.X = X;
        this.Y = Y;
        caracter = 'A';
    }
    
    public FantasmaRosa() : this(30, 30)
    {
    }

    public override void Mover()
    {
         X--;
    }
}

// ---------------------------------

class FantasmaAzul : Fantasma
{
    public FantasmaAzul() : this(35,35)
    {
    }
    
    public FantasmaAzul(int X, int Y) : base (X, Y)
    {
        this.X = X;
        this.Y = Y;
        caracter = 'A';
    }

    public override void Mover()
    {
         X++;
    }
}
