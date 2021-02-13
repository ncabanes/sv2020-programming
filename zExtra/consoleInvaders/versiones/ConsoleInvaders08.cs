/* Console Invaders, V08 (ej 6.7.3)

Amplía el esqueleto del ConsoleInvaders (6.6.3): La clase Enemigo tendrá un 
segundo constructor, sin parámetros, que prefijará su posición inicial a 
(100,80) para estas primeras pruebas. La clase Nave tendrá un segundo 
constructor, con parámetros X e Y, para poder colocar la nave en otra posición 
desde Main. Verás que hay código repetitivo en esos dos contructores, pero más 
adelante lo optimizaremos.*/

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

//---------------------

class Partida
{
    public void Lanzar()
    {
        bool mover = false;
        ConsoleKeyInfo tecla;
        
        Nave n = new Nave();
        Enemigo e = new Enemigo();

        n.MoverA(500, 600);
        e.MoverA(100, 80);

        do
        {
            Console.Clear();
            
            n.Dibujar();
            e.Dibujar();

            tecla = Console.ReadKey();
            
            if(tecla.Key == ConsoleKey.LeftArrow)
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
        imagen  = "/\\";
    }
    
    public Nave(int newX, int newY)
    {
        x = newX / 12;
        y = newY / 30;
        imagen  = "/\\";
    }
    
    public void MoverDerecha()
    {
        if (x < 1023/12)
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
        imagen  = "][";
    }
    
    public Enemigo()
    {
        x = 100 / 12;
        y = 80 / 30;
        imagen  = "][";
    }
}
