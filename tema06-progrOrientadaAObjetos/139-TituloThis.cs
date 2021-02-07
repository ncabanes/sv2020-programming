/* 
 
139. Crea una nueva versión del ejercicio 138 (anterior), en la que el 
constructor de la clase "Titulo" que sólo recibe un parámetro se apoye en el 
que recibe tres, usando la palabra "this".

*/

using System;

class Titulo
{
    protected string texto;
    protected int x, y;
    
    public Titulo(int nuevaX, int nuevaY, 
        string nuevoTexto)
    {
        x = nuevaX;
        y = nuevaY;
        texto = nuevoTexto;
    }
    
    public Titulo(string textoElegido)
        : this(40 - textoElegido.Length / 2, 10, textoElegido)
    {
    }
    
    public void Mostrar()
    {
        Console.SetCursorPosition(x,y);
        Console.WriteLine(texto);
    }
        
    ~ Titulo()
    {
        Console.WriteLine("Destruyendo texto");
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
        Console.SetCursorPosition(x,y);
        Console.WriteLine(texto);
        Console.SetCursorPosition(x,y + 1);
        Console.WriteLine(new string ('-',texto.Length));
    }

}

// --------

class TituloCentrado : Titulo
{
    // Alternativa 1, como ej. 136
    /*
    public TituloCentrado(int linea, string input)
        : base(40-input.Length/2, linea, input)
    {
    }
    */
    
    // Alternativa 2, usando el segundo constructor
    public TituloCentrado(int linea, string input)
        : base(input)
    {
        y = linea;
    }
    
    public new void Mostrar()
    {
        Console.SetCursorPosition(x,y);
        Console.WriteLine(texto);
        Console.SetCursorPosition(x,y + 1);
        Console.WriteLine(new string ('-',texto.Length));
    }
}

// --------

class PruebaDeTitulo
{
    static void Main()
    {
        Titulo t1 = new Titulo(35, 11, "Hola");
        t1.Mostrar();
        
        Titulo t2 = new Titulo("Constructor con título elegido");
        t2.Mostrar();    
    }
}
