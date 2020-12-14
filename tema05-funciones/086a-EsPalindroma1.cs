/*86. Crea una función llamada "EsPalindroma", que devolverá true si el parámetro 
es una palabra palíndroma (que se lee igual de izquierda a derecha que de 
derecha a izquierda), o falso en caso contrario. Pide al usuario un texto y 
responde si es palíndromo.
Iván (...)
*/

using System;

public class Ejercicio86
{
    public static void Main()
    {
        string texto;
        
        Console.WriteLine("Introduce un texto: ");
        texto = Console.ReadLine();
        Console.WriteLine();
        
        if (EsPalindroma(texto))
        {
            Console.WriteLine("Es palindroma.");
        }
        else
        {
            Console.WriteLine("No es palindroma.");
        }
    }
    
    static bool EsPalindroma(string texto)
    {
        bool palindroma = false;
        int longitud = texto.Length;
        string textoInvertido = "";
        
        foreach(char letra in texto)
        {
            textoInvertido =  letra + textoInvertido;
        }
        
        if (texto == textoInvertido)
        {
            palindroma = true;
        }
        
        return palindroma;
    }
}
