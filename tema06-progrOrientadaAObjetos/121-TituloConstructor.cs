/*

Crea una nueva versión de la clase "Titulo", usando un constructor en vez del 
método Inicializar. Pruébalo desde "Main" con los mismo valores que antes.

*/

using System;

class Titulo
{
    private int x, y;
    private string texto;

    public Titulo(int nuevaX, int nuevaY, 
        string nuevoTexto)
    {
        x = nuevaX;
        y = nuevaY;
        texto = nuevoTexto;
    }

    public int GetX() { return x; }
    public int GetY() { return y; }
    public string GetTexto() { return texto; }

    public void SetX(int nuevoX) { x = nuevoX; }
    public void SetY(int nuevoY) { y = nuevoY; }
    public void SetTexto(string nuevoTexto) { texto = nuevoTexto; }

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
        t.Mostrar();
    }
}

