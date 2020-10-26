//Jorge (...)
//Triungulo (for)

using System;

class Triangulo
{
    static void Main()
    {
        Console.Write("Tamaño? ");
        int numeroAsteriscos = Convert.ToInt32(Console.ReadLine());

        for(int fila = 1; fila <= numeroAsteriscos; fila++)
        {
            for (int columna = 1; columna <= fila; columna++)
                Console.Write("*");

            Console.WriteLine("");
        }
    }
}
