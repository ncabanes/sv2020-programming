/*Eduardo (...)

Crea una función llamada "EsPrimo", que devolverá true si el parámetro
es un número primo, o false en caso contrario. Empléala en un programa
que muestre los números primos entre el 1 y el 100. */

using System;

class ejercicio82
{
    static void Main()
    {
        Console.Write("Primos entre 1 y 100: ");
        for (int i = 0; i <= 100; i++)
        {
            if ( EsPrimo(i) )
            {
                Console.Write("{0} ",i);
            }
        }
        Console.WriteLine();
    }

    static bool EsPrimo(int numero)
    {
        bool primo = false;
        int divisores = 0;

        for (int i = numero; i >= 1; i--)
        {
            if (numero % i == 0)
                divisores ++;
        }

        if (divisores == 2)
            primo = true;

        return primo;
    }
}
