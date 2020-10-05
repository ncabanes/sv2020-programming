// Roberto (...)
// Días que tiene el mes dado

using System;

class Ejercicio16b
{
    static void Main()
    {
        Console.Write("Escribe el número del mes: ");
        int mes = Convert.ToInt32( Console.ReadLine() );
        
        
        if ((mes < 1) || (mes > 12))
            Console.Write("Error: Tiene que ser un número del 1 al 12.");
        else if ((mes == 1) || (mes == 3) || (mes == 5) || (mes == 7) ||
                (mes == 8) || (mes == 10) || (mes == 12))
            Console.Write("31 días.");
        else if (mes == 2) 
            Console.Write("28 días.");
        else 
            Console.Write("30 días.");
    }
}
