/*
Carlos (...)
Ejercicio 62.Días de la semana
*/

using System;

class Ejercicio62
{
    static void Main()
    {
        string[] dia = {"LUNES", "MARTES", "MIÉRCOLES", "JUEVES", "VIERNES", 
            "SÁBADO", "DOMINGO"};
        for (int i = 0; i < 7; i++)
        {
            Console.Write(dia[i] + " ");
        }
        Console.WriteLine();
        
        Console.Write("Introduce un día en formato numérico: ");
        try 
        {
            int ndia = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("El {0} sería {1}.", ndia, dia[(ndia-1)]);
        }
        catch (Exception)
        {
            Console.WriteLine("Valor no válido.");
        }
    }
}
