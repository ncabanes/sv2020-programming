/* Ej_25
 * Programa que pide al usuario un número y asigna a una variable
 * "multiploDe5" el valor 1 si es un múltiplo de 5, o el valor 0 si
 * no lo es. usando "if" y  el operador ternario.
 * Por Jesús (...)
 */
   
using System;

class Ej_25
{
    static void Main()
    {
        int num, multiploDe5;
      
        Console.Write("Introduce un numero ");
        num = Convert.ToInt32(Console.ReadLine());

        // Con "if"
        if (num % 5 == 0)
            multiploDe5 = 1;
        else  
            multiploDe5 = 0;
        Console.WriteLine (multiploDe5);
        
        // con el operador ternário
        multiploDe5 = num % 5 == 0 ? 1 : 0;
        Console.WriteLine (multiploDe5);
      }
}
