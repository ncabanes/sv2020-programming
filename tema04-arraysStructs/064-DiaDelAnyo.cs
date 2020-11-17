/*
Crea un programa en C# que pida al usuario el número de un mes (por ejemplo, 3 
para marzo) y el número de un día (por ejemplo, 10) y muestre de qué número de 
día dentro del año se trata, en un año no bisiesto. Por ejemplo: como enero 
tiene 31 días y febrero 28, el 10 de marzo sería el día número 69 del año 
(31+28+10).
*/

using System;

class DiaDelAnyo
{
    static void Main()
    {
        int suma = 0;

        string[] meses = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", 
            "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };

        ushort[] dias = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        Console.WriteLine("Dime el mes (1 - 12): ");
        ushort mes = Convert.ToUInt16(Console.ReadLine());

        Console.WriteLine("Dime el dia (1 - 31): ");
        ushort dia = Convert.ToUInt16(Console.ReadLine());

        Console.WriteLine("El mes elegido es: {0}", meses[mes - 1]);

        // Primero sumo los meses anteriores
        for(ushort i = 0; i < mes - 1; i++) 
            suma += dias[i];
        
        // Y luego el día del mes actual
        suma = suma + dia;

        // Y eso es todo, amigos...
        Console.WriteLine("Es el dia numero {0} del año. ", suma);
    }
}
