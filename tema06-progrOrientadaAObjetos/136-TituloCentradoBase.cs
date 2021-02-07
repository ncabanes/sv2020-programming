using System;

/*

Ej.136

A partir de la "solución oficial" del ejercicio 122 (TituloCentrado), crea una 
versión en la que no haya constructor vacío en la clase Titulo, sino que se 
utilice la palabra "base" donde sea necesario

*/

class Titulo
{
    protected int x;
    protected int y;
    protected string texto;

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

    public void SetTexto(string nuevoTexto) { texto = nuevoTexto; }
    public void SetX(int nuevoX) { x = nuevoX; }
    public void SetY(int nuevoY) { y = nuevoY; }

    public void Mostrar()
    {
        Console.SetCursorPosition(x, y);
        Console.WriteLine(texto);
    }
}

// --------

class TituloSubrayado : Titulo
{
    public TituloSubrayado(int columna, int fila, string texto)
        : base(columna, fila, texto)
    {
    }
    
    public new void Mostrar()
    {
        Console.SetCursorPosition(x, y);
        Console.WriteLine(texto);
        Console.SetCursorPosition(x, y + 1);
        Console.WriteLine(new string('-', texto.Length));
    }
}

// --------

class TituloCentrado: Titulo
{
    public TituloCentrado(int fila, string texto)
        : base(40-texto.Length/2, fila, texto)
    {
    }
    
    public new void Mostrar()
    {
        for( int i = 0; i < y; i++)
        {
            Console.WriteLine();
        }
        for (int j = 0; j < (80 - texto.Length) / 2; j++)
        {
            Console.Write(" ");
        }
        Console.WriteLine(texto);

    }
}

// --------

class PruebaDeTitulo
{
    static void Main()
    {
        TituloCentrado t3 = new TituloCentrado(4, "EYYYYY");
        t3.Mostrar();
    }
}
