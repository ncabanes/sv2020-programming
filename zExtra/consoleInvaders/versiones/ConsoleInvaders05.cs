/*
Console Invaders, V05 (ej 6.4.4)

Amplía el esqueleto del ConsoleInvaders (ejercicio 6.3.6): Crea una clase 
"Sprite", de la que heredarán "Nave" y "Enemigo". La nueva clase contendrá 
todos los atributos y métodos que son comunes a las antiguas (todos los 
existentes, por ahora). A cambio, verás que tanto la nave como el enemigo 
tendrán la misma “imagen”, pero eso lo solucionaremos pronto.

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

class Sprite
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

//-------------------------

class Nave : Sprite
{
    
}

//---------------------

class Enemigo : Sprite
{
    
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
