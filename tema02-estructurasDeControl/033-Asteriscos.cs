/* Ej_33
   * Programa  que muestre en pantalla tantos asteriscos como indique
   * el usuario, en una misma fila, usando "while"
   * Por Jesús (...)
   */
   
using System;

class Ej_33
{
    static void Main()
    {
        Console.WriteLine("Introduzca el numero de asteriscos a mostrar");
        int n = Convert.ToInt32(Console.ReadLine());
                        
        int contador = 1;
        while (contador <= n) 
        {
            Console.Write("*");
            contador++;
        }
    }
}
