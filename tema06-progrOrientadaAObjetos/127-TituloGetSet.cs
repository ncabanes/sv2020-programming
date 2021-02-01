/*
Ejericio 127
Jorge (...)
1º DAM Semipresencial 

Crea una nueva versión del ejercicio 121 (título con constructor), partiendo
de la "solución oficial", pero en la que, en vez de "getters" y "setters" 
convencionales, emplees "propiedades" en formato largo. Prueba su 
funcionamiento, cambiando la X y el texto antes de mostrar el título.
*/

using System;

class Titulo
{
    private int x;
    private int y;
    private string texto;

    public Titulo(int nuevaX, int nuevaY, string nuevoTexto)
    {
        x = nuevaX;
        y = nuevaY;
        texto = nuevoTexto;
    }

    public int X
    {
        get
        {
            return x;
        }
        set
        {
            x = value;
        }
    }

   // public int X { get; set; }

    public int Y
    {
        get
        {
            return y;
        }
        set
        {
            y= value;
        }
    }

    public String Texto
    {
        get
        {
            return texto;
        }
        set
        {
            texto = value;
        }
    }
  
    public void Mostrar()
    {
        Console.SetCursorPosition(x, y);
        Console.WriteLine(texto);
    }
}


class PruebaDeTitulo
{
    static void Main()
    {
        Titulo t = new Titulo(35, 11, "Hola");
        t.X = 1;
        t.Texto = "Hasta luego";
        t.Mostrar();
    }
}
