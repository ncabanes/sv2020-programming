// Cuadrado hueco
// Marina (...)

using System;
class Ejercicio_36
{
    static void Main()
    {
        int tamanyo;
        int fila = 1;
        int columna = 1;
        string simbolo;

        Console.WriteLine("Introduce el tamaño del cuadrado");
        tamanyo = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Introduce el simbolo");
        simbolo = Console.ReadLine();

        while (fila <= tamanyo)
        {
            while (columna <= tamanyo)
            {
                if (fila == 1 || fila == tamanyo 
                    || columna == 1 || columna == tamanyo)
                {
                    Console.Write(simbolo);
                }
                else
                {
                    Console.Write(" ");
                }
                columna++;
            }
            Console.WriteLine();
            fila++;
            columna = 1;
        }
    }
}
