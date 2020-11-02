/*
Carlos (...)
Ejercicio 51. Números en hexadecimal
*/

using System;

class Ejercicio51
{
    static void Main()
    {
        short num1;
        short num2;
        
        Console.Write("Introduce un número corto: ");
        num1 = Convert.ToInt16(Console.ReadLine());
        
        Console.Write("Introduce otro número corto: ");
        num2 = Convert.ToInt16(Console.ReadLine());
        
        if (num1 > num2) //Invertir los números
        {
            short auxiliar = num2;
            
            num2 = num1;
            num1 = auxiliar;
        }
        
        for (; num1 <= num2; num1++)
        {
            Console.Write("{0} ", Convert.ToString(num1, 16));
        }
    }
}
