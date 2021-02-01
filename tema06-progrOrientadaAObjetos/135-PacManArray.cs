//Patrick (...)

/*
135. Crea una nueva versión del ejercicio 134 (anterior, PacMac), en la que los 
4 fantasmas formen parte de un mismo array. Cada fantasma pertenecerá a su 
propia clase, que heredará de Fantasma: el primer fantasma será de la clase 
FantasmaRojo, y su método Mover mostrará el texto "Fantasma rojo en 
movimiento". El segundo será de la clase FantasmaNaranja, y su método Mover 
mostrará el texto "Fantasma naranja en movimiento". Las clases FantasmaRosa y 
FantasmaAzul tendrán comportamientos similares. En el cuerpo del programa, haz 
que los 5 personajes se muevan una vez. Comprueba que aparecen textos 
distintos.
*/

using System;

class PruebaPacMan
{
    static void Main()
    {
        Pac p = new Pac(13, 10);
        p.Mostrar();
        p.Mover();
        Fantasma[] fantasmas = new Fantasma[4];
        fantasmas[0] = new FantasmaRojo(15, 11);
        fantasmas[1] = new FantasmaNaranja(17, 12);
        fantasmas[2] = new FantasmaRosa(19, 13);
        fantasmas[3] = new FantasmaAzul(21, 14);

        for (int i = 0; i < fantasmas.Length; i++)
        {
            fantasmas[i].Mostrar();
            fantasmas[i].Mover();
        }
    }
}

// ---------------------------------

class Sprite
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
        
        Console.WriteLine("Soy Pac y me muevo");
    }
}

// ---------------------------------


class Fantasma : Sprite
{
    public Fantasma(){}
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
    public FantasmaRojo(int X, int Y)
    {
        this.X = X;
        this.Y = Y;
        caracter = 'A';
    }

    public override void Mover()
    {
        Console.WriteLine("Fantasma rojo en movimiento");
    }
}

// ---------------------------------

class FantasmaNaranja : Fantasma
{
    public FantasmaNaranja(int X, int Y)
    {
        this.X = X;
        this.Y = Y;
        caracter = 'A';
    }

    public override void Mover()
    {
        Console.WriteLine("Fantasma naranja en movimiento");
    }
}

// ---------------------------------

class FantasmaRosa : Fantasma
{
    public FantasmaRosa(int X, int Y)
    {
        this.X = X;
        this.Y = Y;
        caracter = 'A';
    }

    public override void Mover()
    {
        Console.WriteLine("Fantasma rosa en movimiento");
    }
}

// ---------------------------------

class FantasmaAzul : Fantasma
{
    public FantasmaAzul(int X, int Y)
    {
        this.X = X;
        this.Y = Y;
        caracter = 'A';
    }

    public override void Mover()
    {
        Console.WriteLine("Fantasma azul en movimiento");
    }
}
