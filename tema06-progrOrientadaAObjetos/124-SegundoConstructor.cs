/* Verónica (...)
 
124. Crea un segundo constructor para la clase "Título", que permita escoger 
el texto, pero prefije la Y a 10, y la X a 40 menos la mitad de la longitud 
del texto. Crea un "Main" que pruebe ambos constructores.*/

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
    {
         x = 40 - textoElegido.Length / 2;
         y = 10;
         texto = textoElegido;
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
         x = 40-texto.Length/2;
         y = linea;
         texto = input;
    }

}

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
