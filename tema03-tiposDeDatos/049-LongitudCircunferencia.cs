//Ruth (...)

/* 49 -  Calcula la longitud de un circunferencia, a partir de su radio,
 * que introducirá el usuario en una variable real de doble precisión 
 * (longitud = 2 * pi * radio). Tanto el valor de "pi" como el resultado 
 * (la longitud) deben estar almacenados en variables, que también serán 
 * números reales de doble precisión. */

using System;

class LongitudCircu
{
    static void Main()
    {
        double radio, longitud;
        double pi = 3.1415926535;

        Console.Write("Indíqueme el radio de la circunferencia: ");
        radio = Convert.ToDouble(Console.ReadLine());

        longitud = 2 * pi * radio;

        Console.WriteLine("Su longitud es: {0}", longitud);
    }
}
