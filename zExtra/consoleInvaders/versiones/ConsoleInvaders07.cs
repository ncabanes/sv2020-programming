/*
Console Invaders, V07 (ej 6.6.3)

Amplía el esqueleto del ConsoleInvaders (ejercicio 6.5.4): La clase Nave 
tendrá un constructor, sin parámetros, que prefijará su posición inicial en las 
coordenadas 500,600. El constructor de la clase Enemigo recibirá como 
parámetros las coordenadas X e Y iniciales, para que se puedan cambiar desde el 
cuerpo del programa. La imagen de la nave y del enemigo se prefijarán en estos 
constructores.*/

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
        Enemigo e = new Enemigo(100,80);

        //n.MoverA(500, 600);
        //e.MoverA(100, 80);

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
        x = 500 / 12;
        y = 600 / 30;
        imagen  = "/\\";
    }
    public void MoverDerecha()
    {
        if (x < 1023/12)
            x += 10;
    }
    public void MoverIzquierda()
    {
        if (x > 10)
            x -= 10;
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
}
