// Ejercicio_04_7 (43)
// Productos Repetitivos

// Escribe un programa que le pida al usuario un número entero y muestre sus 
// factores primos, usando la estructura repetitiva que consideres más adecuada.

// Por ejemplo, 15 = 3 * 5, 24 = 2 * 2 * 2 * 3 

using System;

class Ejer_43
{
    static void Main()
    {
        int num;
        int divisor = 2;
        
        Console.Write("Dime un número: ");
        num = Convert.ToInt32(Console.ReadLine());
        
        Console.Write("{0} = ", num);
        
        while (num > 1)
        {
            if (num % divisor == 0)
            {
                Console.Write("{0} ", divisor);
                num = num / divisor;
            }
            else
            {
                divisor++;
            }
        }
        Console.WriteLine();
    }
}
