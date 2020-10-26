/*  Angel (...)
    Ejercicio: division con excepciones */

using System;

class Ejercicio10
{
    static void Main()
    {
        int numerador, denominador;
        
        try
        {
            Console.Write("Introduce el numerador: ");
            numerador = Convert.ToInt32(Console.ReadLine());
            Console.Write("Introduce el denominador: ");
            denominador = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("El resultado es: {0}", numerador/denominador);
        }
        catch(FormatException)
        {
            Console.WriteLine("No has introducido un numero.");
        }
        catch(DivideByZeroException)
        {
            Console.WriteLine("No se puede dividir entre cero.");
        }
    }
}
