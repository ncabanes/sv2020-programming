using System;
using System.Reflection;

class  Ejercicio_54
{
    static void Main()
    {
        int n;
        double PiEntreCuatro = 0;
        int signo = 1;
        double denominador = 1;

        Console.WriteLine("Introduce el número de términos: ");
        n = Convert.ToInt32(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {
            PiEntreCuatro += (signo * (1 / denominador));
            denominador += 2;
            signo *= -1;
        }
        Console.WriteLine(PiEntreCuatro * 4);
    }
}
