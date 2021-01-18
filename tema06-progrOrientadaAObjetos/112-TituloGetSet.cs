/*112.Crea una nueva versión de la clase "Titulo". Sus atributos serán privados 
y tendrán getters y setters. Cambia el programa y "Main" según sea necesario.
Deberás entregar sólo el fichero .cs.*/

//ALBERTO (...)

using System;

class Titulo
{
    private int x;
    private int y;
    private string texto = "texto en pantalla";

    public void Mostrar()
    {
        Console.SetCursorPosition(x, y);
        Console.WriteLine(texto);
    }

    public int GetX()
    {
        return x;
    }

    public int GetY()
    {
        return y;
    }
    
    public string GetTexto()
    {
        return texto;
    }

    public void SetX(int nuevoValorColumna)
    {
        x = nuevoValorColumna;
    }

    public void SetY(int nuevoValorFila)
    {
        y = nuevoValorFila;
    }
    
    public void SetTexto(string nuevoTexto)
    {
        texto = nuevoTexto;
    }
}

class PruebaDeTitulo
{
    static void Main()
    {
        Titulo t = new Titulo();
        t.SetX(30);
        t.SetY(10);
        t.SetTexto("Prueba de título");
        t.Mostrar();
    }
}

