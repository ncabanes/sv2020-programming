// Valentina (...)

/*
86. Crea una función llamada "EsPalindroma", que devolverá true si el parámetro 
es una palabra palíndroma (que se lee igual de izquierda a derecha que de 
derecha a izquierda), o falso en caso contrario. Pide al usuario un texto y 
responde si es palíndromo.
*/

using System;

class Program
{
    static bool EsPalindroma(string texto)
    {
        bool palindroma = false;
        char[] ArrayDelTexto = texto.ToCharArray();
        Array.Reverse(ArrayDelTexto);
        string textoAlReves = new string(ArrayDelTexto);

        if (texto.ToLower().Equals(textoAlReves.ToLower()))
            palindroma = true;

        return palindroma;
    }
    static void Main()
    {
        Console.WriteLine("Introduce un texto: ");
        string texto = Console.ReadLine();
        
        if (EsPalindroma(texto))            
            Console.WriteLine("Es palíndromo");            
        else
            Console.WriteLine("No es palíndromo");
    }
}
