//Iván (...)

/*
118. Crea una clase "TituloSubrayado", que herede de "Titulo" y que mostrará 
guiones debajo del título. Tu fuente contendrá las tres clases: Titulo (sin 
modificar), TituloSubrayado y PruebaDeTitulo. Pruébalo en "Main". Quizá 
obtengas algún error de compilación...
*/

using System;

class Titulo
{
    private string texto;

    public string GetTexto()
    {
        return texto;
    }
    public void SetTexto(string nuevoTexto)
    {
        texto = nuevoTexto;
    }
    public void EscribirTexto()
    {
        Console.WriteLine(texto);
    }
}

class TituloSubrayado : Titulo
{
    private char simbolo = '-';
    
    public new void EscribirTexto()
    {
        // El siguiente planteamiento falla, 
        // porque "texto" es "private" en "Titulo":
        
        /*
        Console.WriteLine(texto);
        for(int i = 0; i <= texto.Length; i++)
        {
            Console.Write(simbolo);
        }
        */
        
        // Planteamiento alternativo
        
        Console.WriteLine( GetTexto() );
        for(int i = 0; i <= GetTexto().Length; i++)
        {
            Console.Write(simbolo);
        }
    }
}

class PruebaDeTitulo
{
    static void Main()
    {
        TituloSubrayado ts = new TituloSubrayado();
        ts.SetTexto("hola que tal");
        ts.EscribirTexto();
    }
}
