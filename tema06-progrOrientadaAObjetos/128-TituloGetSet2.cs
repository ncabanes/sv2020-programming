/* Eduardo (...)

Crea una nueva versión del ejercicio 121 (título con constructor), 
partiendo de la "solución oficial", pero en la que, en vez de "getters" 
y "setters" convencionales, emplees "propiedades" en formato compacto. 
Prueba su funcionamiento, cambiando la X y el texto antes de mostrar el 
título. */

using System;

class Titulo
{
    //private int x, y;
    //private string texto;

    public Titulo(int nuevaX, int nuevaY, string nuevoTexto)
    {
        X = nuevaX;
        Y = nuevaY;
        Texto = nuevoTexto;
    }

    public int X { get; set; }
    public int Y { get; set; }
    public string Texto { get; set; }

    public void Mostrar()
    {
        //Ojo, que ahora es "X" y no "x"
        Console.SetCursorPosition(X, Y); 
        //Lo mismo ocurre con "Texto"
        Console.WriteLine(Texto); 
    }
    
}


class PruebaDeTitulo
{
    static void Main()
    {
        Titulo t = new Titulo(40, 11, "Hola");
        t.X = 70;
        t.Texto = "Ciao!";
        t.Mostrar();
    }
}
