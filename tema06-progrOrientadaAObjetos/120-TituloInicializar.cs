/*
Crea un método "Inicializar" para la clase "Título", que permita fijar a la vez 
los valores iniciales para x, y, texto. Pruébalo desde "Main" con los valores: 
texto = "Hola", x = 35, y = 11
*/

using System;

class Titulo
{
    private int x, y;
    private string texto;

    public void Inicializar(int nuevaX, int nuevaY, 
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
        Titulo t = new Titulo();
        t.Inicializar(35, 11, "Hola");
        t.Mostrar();
    }
}

