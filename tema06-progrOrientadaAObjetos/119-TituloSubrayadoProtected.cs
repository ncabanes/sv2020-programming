//Iván (...)

/*
119: Crea una nueva versión de clase "Titulo" y "TituloSubrayado", 
en la que los atributos sean "protected". Pruébalas en "Main".
*/

using System;

class Titulo
{
    protected string texto;

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
        // En esta versión no hay problemas en acceder 
        // a "texto", porque es "protected":
        
        Console.WriteLine(texto);
        for(int i = 0; i <= texto.Length; i++)
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
