//Iván (...)

/*
A partir de la "solución oficial" de la clase "TituloSubrayado" (ej. 119), crea 
una nueva versión, que incluya un constructor para TituloSubrayado que reciba 
como parámetro el carácter con el que se desea que el texto aparezca subrayado. 
Comprueba que se comporta correctamente.
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
    public virtual void EscribirTexto()
    {
        Console.WriteLine(texto);
    }
}

class TituloSubrayado : Titulo
{
    protected char simbolo;
    public TituloSubrayado (char nuevoSimbolo)
    {
        simbolo = nuevoSimbolo; 
    }
    public override void EscribirTexto()
    {
        Console.WriteLine(texto);
        for (int i = 0; i <= texto.Length; i++)
        {
            Console.Write(simbolo);
        }
    }
}

class PruebaDeTitulo
{
    static void Main()
    {
        TituloSubrayado ts = new TituloSubrayado('*');
        ts.SetTexto("hola que tal");
        ts.EscribirTexto();
    }
}
