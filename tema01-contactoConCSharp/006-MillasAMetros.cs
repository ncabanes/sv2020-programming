// JESUS (...)
// Ej_01_06 PROGRAMA PARA CONVERTIR MILLAS A METROS

using System;

class Ej_01_06
{
    static void Main()
    {
        int millas;
        int metros;
        int millasPorMetro = 1609;
        
        Console.Write("Introduce el numero de millas a transformar a metros ");
        millas = Convert.ToInt32(Console.ReadLine());
        metros = millas * millasPorMetro;
        
        Console.Write(millas);
        Console.Write(" millas equivalen a ");
        Console.Write(metros);
        Console.Write(" metros.");
    }
}
