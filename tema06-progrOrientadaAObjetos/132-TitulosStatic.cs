using System;

/*132. Crea una variante del ejercicio anterior (131), en la que el símbolo de
 * subrayado sea un atributo "static" de la clase correspondiente, de modo que 
 * todos los títulos subrayados usen el mismo símbolo. Comprueba que el 
 * funcionamiento es correcto. */

//Iván Fernández Pastor

class Titulo
{
    protected string texto;

    public int X { get; set; }
    public int Y { get; set; }

    public Titulo()
    {

    }

    public Titulo(int nuevaX, int nuevaY, string nuevoTitulo)
    {
        X = nuevaX;
        Y = nuevaY;
        texto = nuevoTitulo;
    }

    public string GetTexto()
    {
        return texto;
    }
    public void SetTexto(string nuevoTexto)
    {
        texto = nuevoTexto;
    }
    public virtual void EscribirTexto()
    {
        Console.SetCursorPosition(X, Y);
        Console.WriteLine(texto);
    }
}

class TituloSubrayado : Titulo
{
    static char simbolo = '-';

    public TituloSubrayado()
    {

    }

    public TituloSubrayado(int nuevaX, int nuevaY, string nuevoTitulo, 
        char nuevoSimbolo)
    {
        X = nuevaX;
        Y = nuevaY;
        texto = nuevoTitulo;
        simbolo = nuevoSimbolo;
    }

    public override void EscribirTexto()
    {
        Console.SetCursorPosition(X, Y);
        Console.WriteLine(texto);
        Console.SetCursorPosition(X, Y + 1);
        for (int i = 0; i < texto.Length; i++)
        {
            Console.Write(simbolo);
        }
    }
}

class PruebaDeTitulo
{
    static void Main()
    {
        Titulo[] t = new Titulo[4];

        t[0] = new Titulo(1, 1, "Libro de Petete");
        t[1] = new Titulo(5, 5, "Recetas de la abuela");
        t[2] = new TituloSubrayado(10, 10, "Las memorias de Pedro", '-');
        t[3] = new TituloSubrayado(15, 15, "El Señor de los Anillos", '=');


        for (int i = 0; i < t.Length; i++)
            t[i].EscribirTexto();

        Console.WriteLine();
    }
}
