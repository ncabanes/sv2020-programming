/*Gonzalo (...)
 * 129. Crea una nueva versión del ejercicio 121 (título con constructor), 
 * partiendo de la "solución oficial", pero en la que, en vez de "getters" y 
 * "setters" convencionales, emplees "propiedades", usando el formato compacto 
 * cuando sea posible, pero teniendo en cuenta que las propiedades X e Y deben 
 * ser de tipo "int", pero ocultar datos que internamente serán de tipo "byte". 
 * Prueba su funcionamiento, cambiando la X y el texto antes de mostrar el 
 * título.*/
 
using System;

class Titulo
{
    private byte x, y;
    
    
    public Titulo(int nuevaX, int nuevaY, 
        string nuevoTexto)
    {
        X = (byte) nuevaX;
        Y = (byte) nuevaY;
        Texto = nuevoTexto;
    }
    public int X
    {
        get { return x; }
        set { x = (byte)value; }
    }
    public int Y
    {
        get { return y; }
        set { y = (byte)value; }
    }
    public string Texto { get; set; }
  
    public void Mostrar()
    {
        Console.SetCursorPosition(X, Y);
        Console.WriteLine(Texto);
    }
}
class PruebaDeTitulo
{
    static void Main()
    {
        Titulo t = new Titulo(35, 11, "Hola");
        
        t.X = 20;
        t.Texto = "Texto cambiado";
        
        t.Mostrar();
    }
}


