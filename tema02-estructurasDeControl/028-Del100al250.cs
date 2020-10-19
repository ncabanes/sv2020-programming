/* Alejandro (...)
 * Programa que muestra los numeros del 100 al 250 
 * en linea
 * CON WHILE*/
 
using System;

class Del100al250
{
    static void Main()
    {
        int num = 100;
        
        while (num <= 250)
        {
            Console.Write(" " + num);
            num = num + 1;
        }
    }
}
