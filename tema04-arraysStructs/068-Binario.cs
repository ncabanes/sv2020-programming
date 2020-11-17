/*68.Crea un programa que pida al usuario un número entero positivo y muestre su
equivalente en forma binaria. Supondremos que el número cabe en 8 bits (un byte)
El algoritmo es el siguiente: divide el número entre 2 tantas veces como sea 
posible hasta que el número se convierta en uno, y toma todos los restos en 
orden inverso:
35: 2 = 17, resto 1
17: 2 = 8, resto 1
8: 2 = 4, resto 0
4: 2 = 2, resto 0
2: 2 = 1, resto 0
1, terminado
por lo que el número sería 00100011.  

Iván (...)
*/

using System;

public class Ejercicio_68
{
    public static void Main()
    {
        int[] restos = new int[8];
        int numero, resultado, i = 0, divisor = 2;
        
        //Pedimos un número al usuario
        Console.WriteLine("Introduzca un número entero: ");
        numero = Convert.ToInt32(Console.ReadLine());
        for(i = 0; i < 8; i++)
        {
            resultado = numero / divisor;
            restos[7-i] = numero % divisor;
            numero = resultado;
        }
        
        Console.WriteLine("El número en binario es: ");
        for(i = 0; i < 8; i++)
        {
            Console.Write("{0}", restos[i]);
        }
    }
}
