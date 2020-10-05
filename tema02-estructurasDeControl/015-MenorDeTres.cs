// Jorge (...)
// Ejercicio 15. Dice que número es el menor de tres

using System;

class MenorDe3
{
    static void Main()
    {
        int n1, n2, n3;

        Console.Write("Introduce un número: ");
        n1 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Introduce un número: ");
        n2 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Introduce un número: ");
        n3 = Convert.ToInt32(Console.ReadLine());

        if ((n1 <= n2) && (n1 <= n3))
        {
            Console.WriteLine(("{0} es el numero menor."), n1);
        }
        else if ((n2 <= n1) && (n2 <= n3))
        {
            Console.WriteLine(("{0} es el numero menor."), n2);
        }
        else
        {
            Console.WriteLine(("{0} es el numero menor."), n3);
        }
    }
}
