// Jorge (...)
// Ejercicio 14. Pedir dos númerosDecir que número es el menor.
using System;

class ejercicio14
{
    static void Main()
    {
        int n1, n2;

        Console.Write("Introduce un número: ");
        n1 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Introduce otro número: ");
        n2 = Convert.ToInt32(Console.ReadLine());

        if (n1 < n2)
        {
            Console.WriteLine("{0} es el menor.", n1);
        }
        else
        {
            Console.WriteLine("{0} es el menor.", n2);
        }
    }
}
