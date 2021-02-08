/*
Console Invaders, V04 (ej 6.3.6)

Amplía el esqueleto del ConsoleInvaders (ejercicio 6.3.5):

Crea una clase Nave, con atributos "x" e "y" (números enteros, "x" de 0 a 1023
e "y" entre 0 y 767, pensando en una pantalla de 1024x768), e imagen (un string
formado por dos caracteres, como "/\"). También tendrá un método MoverA(nuevaX,
nuevaY) que lo mueva a una nueva posición, y un método Dibujar, que muestre esa
imagen en pantalla (como esta versión es para consola, tendrás que dividir X
para que tenga un valor entre 0 y 79, y la Y entre 0 y 23; por ejemplo, puedes
dividir la X entre 12 y la Y entre 30). Puedes usar
Console.SetCursorPosition(x,y) para situarte en unas coordenadas de pantalla.

Crea también clase Enemigo, con los mismos atributos. Su imagen podría ser
"][".

El método Lanzar de la clase Partida creará una nave en las coordenadas
(500, 600) y la dibujará, creará un enemigo en las coordenadas (100, 80) y lo
dibujará, y finalmente esperará a que el usuario pulse Intro para terminar la
falsa sesión de juego.

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
        while ( ! opcionEscogida );
    }

    public bool GetSalir()
    {
        return salir;
    }
}

//-------------------------

class Nave
{
    private int x;
    private int y;
    private string imagen = "/\\";

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

//---------------------

class Enemigo
{
    private int x;
    private int y;
    private string imagen = "][";

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

//---------------------

class Partida
{
    public void Lanzar()
    {
        Nave n = new Nave();
        Enemigo e = new Enemigo();

        n.MoverA(500, 600);
        e.MoverA(100, 80);

        Console.Clear();
        n.Dibujar();
        e.Dibujar();

        Console.WriteLine("Pulse Intro para salir");
        Console.ReadLine();
    }
}
