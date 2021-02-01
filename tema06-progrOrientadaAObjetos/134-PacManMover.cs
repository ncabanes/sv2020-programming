//Patrick (...)

/*
134. A partir de la "solución oficial" del esqueleto de PacMan (ejercicio 125), 
ya sea en su versión como proyecto o en un único fichero, añade un método Mover 
a la clase Sprite, que escriba en pantalla "Moviendo". Redefínelo en la clase 
Pac para que escriba "Soy Pac y me muevo". Redefínelo en la clase Fantasma para 
que escriba "Fantasma en movimiento". En el cuerpo del programa, haz que los 5 
personajes se muevan una vez.
*/

using System;

class PruebaPacMan
{
    static void Main()
    {
        Sprite s = new Sprite();
        s.Mover();
        Pac p = new Pac(8, 10);
        p.Mostrar();
        p.Mover();
        Fantasma f1 = new Fantasma(15, 12);
        f1.Mostrar();
        f1.Mover();
        Fantasma f2 = new Fantasma(17, 14);
        f2.Mostrar();
        f2.Mover();
        Fantasma f3 = new Fantasma(19, 16);
        f3.Mostrar();
        f3.Mover();
        Fantasma f4 = new Fantasma(21, 18);
        f4.Mostrar();
        f4.Mover();
    }
}
class Sprite
{


    public int X { get; set; }
    public int Y { get; set; }

    public char caracter { get; set; }
    
    public virtual void Mover()
    {
        Console.WriteLine("Moviendo");
    }

    public void Mostrar()
    {
        Console.SetCursorPosition(X, Y);
        Console.WriteLine(caracter);
    }
}

// ---------------------------------

class Pac : Sprite
{
    public Pac(int nuevaX, int nuevaY)
    {
        X = nuevaX;
        Y = nuevaY;
        caracter = 'C';
    }

    public override void Mover()
    {
        Console.WriteLine("Soy Pac y me muevo");
    }
}

// ---------------------------------


class Fantasma : Sprite
{
    public Fantasma(int nuevaX, int nuevaY)
    {
        X = nuevaX;
        Y = nuevaY;
        caracter = 'A';
    }

    public override void Mover()
    {
        Console.WriteLine("Fantasma en movimiento");
    }
}
