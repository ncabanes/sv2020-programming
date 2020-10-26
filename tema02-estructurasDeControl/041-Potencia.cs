/* 41. Crea un programa que le pida al usuario dos números enteros y 
muestre su potencia. Debes usar productos repetitivos.
(Sugerencia: recuerda que 3 ^ 5 = 3 * 3 * 3 * 3 * 3 = 243)*/

using System;

class Ejer_41
{
    static void Main()
    {
        int b, exponente, resultado;
        
        Console.WriteLine("Introduzca la base de la potencia");
        b = Convert.ToInt32(Console.ReadLine());
        
        Console.WriteLine("Introduzca el exponente");
        exponente = Convert.ToInt32(Console.ReadLine());
        
        resultado = 1;
        for (int i = 1; i <= exponente; i++)
        {
            resultado *= b;
            
        }
        Console.Write(resultado);
    }
}
