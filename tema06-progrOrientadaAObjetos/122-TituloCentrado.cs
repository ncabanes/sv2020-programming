using System;

/*Carlos (...)

122. Crea una clase "TituloCentrado", que herede de "Titulo" y que
muestre el texto centrado en la línea correspondiente. Su constructor
recibirá la fila ( Y ) y el texto, pero no la columna ( X ).*/

class Titulo
{
    protected int x;
    protected int y;
    protected string texto;

    public Titulo()  // Necesario (por ahora) para poder heredar
    {
    }
    
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

class TituloSubrayado : Titulo
{
    public new void Mostrar()
    {
        Console.SetCursorPosition(x, y);
        Console.WriteLine(texto);
        Console.SetCursorPosition(x, y + 1);
        Console.WriteLine(new string('-', texto.Length));
    }
}


class TituloCentrado: Titulo
{
    public TituloCentrado(int fila, string tex)
    {
        y = fila;
        texto = tex;
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

class PruebaDeTitulo
{
    static void Main()
    {
        TituloCentrado t3 = new TituloCentrado(4, "EYYYYY");
        t3.Mostrar();
    }
}
