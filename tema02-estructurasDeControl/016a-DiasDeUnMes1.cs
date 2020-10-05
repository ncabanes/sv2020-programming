/* 
 * Carlos (...) - 1ºDAM
 * Ejercicio 16.a. Número de días por mes - Con mes
 */

using System;

class Ejercicio16a
{
    static void Main()
    {
        int mes;

        Console.Write("Dime el número de un mes para saber cuántos días tiene: ");
        mes = Convert.ToInt32(Console.ReadLine());

        if (mes == 1)
        {
            Console.WriteLine("Enero, 31 días.");
        }
        else if (mes == 2)
        {
            Console.WriteLine("Febrero, 28 días.");
        }
        else if (mes == 3)
        {
            Console.WriteLine("Marzo, 31 días.");
        }
        else if (mes == 4)
        {
            Console.WriteLine("Abril, 30 días.");
        }
        else if (mes == 5)
        {
            Console.WriteLine("Mayo, 31 días.");
        }
        else if (mes == 6)
        {
            Console.WriteLine("Junio, 30 días.");
        }
        else if (mes == 7)
        {
            Console.WriteLine("Julio, 31 días.");
        }
        else if (mes == 8)
        {
            Console.WriteLine("Agosto, 31 días.");
        }
        else if (mes == 9)
        {
            Console.WriteLine("Septiembre, 30 días.");
        }
        else if (mes == 10)
        {
            Console.WriteLine("Octubre, 31 días.");
        }
        else if (mes == 11)
        {
            Console.WriteLine("Noviembre, 30 días.");
        }
        else if (mes == 12)
        {
            Console.WriteLine("Diciembre, 31 días.");
        }
        else
        {
            Console.WriteLine("Solo son válidos números del 1 al 12.");
        }
    }
}


