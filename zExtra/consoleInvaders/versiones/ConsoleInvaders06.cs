/*
Console Invaders, V06 (ej 6.5.4)

Amplía el esqueleto del ConsoleInvaders (ejercicio 6.4.4):

Amplía la clase Nave con un método "MoverDerecha", que aumente su X en 10 
unidades, y un "MoverIzquierda", que disminuya su X en 10 unidades. Necesitarás 
hacer que esos atributos sean "protected" en la clase Sprite. El método 
"Lanzar" de la clase Partida no esperará hasta el usuario pulse Intro sin hacer 
nada, sino que ahora usará un do-while que compruebe si pulsa ESC (para salir) 
o flecha izquierda o flecha derecha (para mover la nave: sus códigos son 
ConsoleKey.LeftArrow y ConsoleKey. RightArrow). Si se pulsan las flechas, la 
nave se moverá a un lado o a otro (con los métodos que acabas de crear). Al 
principio de cada pasada del do-while se borrará la pantalla 
("Console.Clear();").

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
    protected int x;
    protected int y;
    protected string imagen = "/\\";

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
    public void MoverDerecha()
    {
        x += 10;
    }
    
    public void MoverIzquierda()
    {
        x -= 10;
    }
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
        
        bool salir = false;
        
        do
        {
            Console.Clear();

            n.Dibujar();
            e.Dibujar();

            ConsoleKeyInfo tecla = Console.ReadKey();

            if (tecla.Key == ConsoleKey.LeftArrow)
                n.MoverIzquierda();
            else if (tecla.Key == ConsoleKey.RightArrow)
                n.MoverDerecha();
            else if (tecla.Key == ConsoleKey.Escape)
               salir = true;
        }
        while (!salir);
    }
}
