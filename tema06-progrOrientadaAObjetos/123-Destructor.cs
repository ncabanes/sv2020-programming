/* Verónica (...)

123. Añade un destructor a la clase "Titulo", que escriba "Destruyendo el 
título".*/

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
    
    public Titulo()  // Necesario (por ahora) para poder heredar
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

class TituloSubrayado : Titulo
{
    public new void Mostrar()
    {
        Console.SetCursorPosition(x,y);
        Console.WriteLine(texto);
        Console.SetCursorPosition(x,y + 1);
        Console.WriteLine(new string ('-',texto.Length));
    }

}

class TituloCentrado : Titulo
{
    public new void Mostrar()
    {
        Console.SetCursorPosition(x,y);
        Console.WriteLine(texto);
        Console.SetCursorPosition(x,y + 1);
        Console.WriteLine(new string ('-',texto.Length));
    }
    
        
    public TituloCentrado(int linea, string input)
    {
         x = 80/2;
         y = linea;
         texto = input;
    }

}

class PruebaDeTitulo
{
    static void Main()
    {
        TituloCentrado tsubcen = new TituloCentrado(15,"Hola centrado");
        tsubcen.Mostrar();
    }
}
