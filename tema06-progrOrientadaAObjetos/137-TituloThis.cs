/*

137. Crea una nueva versión del ejercicio 121 (título con constructor), 
partiendo de la "solución oficial", en la que emplees "this" para que los 
parámetros puedan tener nombres como "x" en vez de "nuevaX".

*/

using System;

class Titulo
{
    private int x, y;
    private string texto;

    public Titulo(int x, int y, 
        string texto)
    {
        this.x = x;
        this.y = y;
        this.texto = texto;
    }

    public int GetX() { return x; }
    public int GetY() { return y; }
    public string GetTexto() { return texto; }

    public void SetX(int x) { this.x = x; }
    public void SetY(int y) { this.y = y; }
    public void SetTexto(string texto) { this.texto = texto; }

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

