using System;

class Ejercicio_44
{
    static void Main()
    {
        int dias;
        int primerDia;
        int posic = 0;

        Console.WriteLine("Introduce la cantidad de días: ");
        dias = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Introduce el número en la semana del primer día");
        primerDia = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("L  M  X  J  V  S  D");

        // Relleno con espacios iniciales la primera semana (3 por cada día)
        for (int j = 1; j < primerDia; j++)
        {
            Console.Write("   ");
            posic++;
        }

        // Y luego el resto de días, avanzando de línea tras cada 7 datos
        for (int i = 1; i <= dias; i++)
        {
            if (i < 10)
            {
                Console.Write("0{0} ", i);
            }
            else
            {
                Console.Write(i + " ");
            }
            posic++;
            if (posic % 7 == 0)
            {
                Console.WriteLine();
            }
        }
    }
}
