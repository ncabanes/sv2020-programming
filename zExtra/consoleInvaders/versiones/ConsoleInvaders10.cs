/* Console Invaders, V10 (ej 6.11.3)

Amplía el esqueleto del ConsoleInvaders (6.7.3), para que haya 10 enemigos en 
una misma fila (todos compartirán una misma coordenada Y, pero tendrán distinta 
coordenada X). Necesitarás usar el constructor en la clase Enemigo que recibe 
los parámetros X e Y. */

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
        ConsoleKeyInfo tecla;

        Nave n = new Nave();
        Enemigo[] e = new Enemigo[10];
        
        n.MoverA(500, 600);

        do
        {
            Console.Clear();
            n.Dibujar();

            for (byte i = 0; i < 10; i++)
            {
                e[i] = new Enemigo((i*50) + 200, 60);
            }
            for (byte i = 0; i < 10; i++)
            {
                e[i].Dibujar();
            }

            tecla = Console.ReadKey();

            if (tecla.Key == ConsoleKey.LeftArrow)
            {
                n.MoverIzquierda();
            }

            if (tecla.Key == ConsoleKey.RightArrow)
            {
                n.MoverDerecha();
            }
        }
        while (tecla.Key != ConsoleKey.Escape);
        Console.Clear();
    }
}

//-------------------------

class Sprite
{
    protected int x;
    protected int y;
    protected string imagen;

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
        x = 500;
        y = 600;
        imagen = "/\\";
    }

    public Nave(int newX, int newY)
    {
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
