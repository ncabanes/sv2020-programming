/* Console Invaders, V09 (ej 6.8.3)
Crea una versión alternativa del esqueleto del ConsoleInvaders (6.7.3) en la que
el constructor de Sprite escriba en pantalla "Creando sprite" y los constructores
de Nave escriba en pantalla "Creando nave en posición prefijada" o "Creando nave
en posición indicada por el usuario", según el caso (deberás hacer una pausa para
poder verlo antes de que se borre la pantalla). Comprueba su funcionamiento.
*/

using System;

class Juego
{
    public void Lanzar()
    {
        Bienvenida b = new Bienvenida();
        Partida p = new Partida();

        do
        {
            b.Lanzar();

            if (!b.GetSalir())
                p.Lanzar();
        }
        while (!b.GetSalir());
    }

    static void Main()
    {
        Juego j = new Juego();
        j.Lanzar();
    }
}

//-------------------------

class Bienvenida
{
    bool salir;
    public void Lanzar()
    {
        bool opcionEscogida = false;

        Console.WriteLine("Bienvenido a Console Invaders. "
            + "Pulse Intro para jugar o ESC para salir");

        do
        {
            ConsoleKeyInfo tecla = Console.ReadKey();

            if (tecla.Key == ConsoleKey.Escape)
            {
                salir = true;
                opcionEscogida = true;
            }
            else if (tecla.Key == ConsoleKey.Enter)
            {
                salir = false;
                Console.Clear();
                opcionEscogida = true;
            }
        }
        while (!opcionEscogida);
    }

    public bool GetSalir()
    {
        return salir;
    }
}

//---------------------

class Partida
{
    public void Lanzar()
    {
        bool mover = false;
        ConsoleKeyInfo tecla;

        //Líneas para probar los dos constructores de la clase Nave
        Nave n = new Nave(500, 600);
        //Nave n = new Nave();
        
        Enemigo e = new Enemigo();

        // Se añade una pausa para que se puedan leer los textos de los constructores
        Console.ReadLine();
        
        n.MoverA(500, 600);
        e.MoverA(100, 80);

        do
        {
            Console.Clear();

            n.Dibujar();
            e.Dibujar();

            tecla = Console.ReadKey();

            if (tecla.Key == ConsoleKey.LeftArrow)
            {
                n.MoverIzquierda();
                mover = true;
            }

            if (tecla.Key == ConsoleKey.RightArrow)
            {
                n.MoverDerecha();
                mover = true;
            }
        }
        while (tecla.Key != ConsoleKey.Escape || !mover);
        Console.Clear();
    }
}

//-------------------------

class Sprite
{
    protected int x;
    protected int y;
    protected string imagen;

    public Sprite()
    {
        Console.WriteLine("Creando sprite");
    }

    public int GetX()
    {
        return x;
    }
    public int GetY()
    {
        return y;
    }
    public void SetX(int nuevaX)
    {
        x = nuevaX;
    }
    public void SetY(int nuevaY)
    {
        x = nuevaY;
    }
    public void MoverA(int nuevaX, int nuevaY)
    {
        x = nuevaX / 12;
        y = nuevaY / 30;
    }

    public void Dibujar()
    {
        Console.SetCursorPosition(x, y);
        Console.Write(imagen);
    }
}

//-------------------------

class Nave : Sprite
{
    public Nave()
    {
        Console.WriteLine("Creando nave en posición prefijada");
        x = 500;
        y = 600;
        imagen = "/\\";
    }

    public Nave(int newX, int newY)
    {
        Console.WriteLine("Creando nave en posición indicada por el usuario");
        x = newX / 12;
        y = newY / 30;
        imagen = "/\\";
    }

    public void MoverDerecha()
    {
        if (x < 1023 / 12)
            x = x + 10;
    }

    public void MoverIzquierda()
    {
        if (x > 10)
            x = x - 10;
    }
}

//---------------------

class Enemigo : Sprite
{
    public Enemigo(int newX, int newY)
    {
        x = newX / 12;
        y = newY / 30;
        imagen = "][";
    }

    public Enemigo()
    {
        x = 100 / 12;
        y = 80 / 30;
        imagen = "][";
    }
}
