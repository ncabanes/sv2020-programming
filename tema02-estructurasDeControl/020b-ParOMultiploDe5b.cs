/* Pide un número del 1 al 10 y dice si es par, múltiplo de 5 o ambas cosas. 
 * Usando "switch"
 * Hugo (...)
 */

using System;

class Ejercicio_20b
{
    static void Main()
    {
        int num;
        
        Console.WriteLine("Introduce un número del 1 al 10");
        num = Convert.ToInt32(Console.ReadLine());
        
        switch (num)
        {
            case 1:
            case 3:
            case 7:
            case 9: Console.WriteLine("{0} es impar", num);
                    break;
            case 5: Console.WriteLine ("{0} es impar y múltiplo de 5", num);
                    break;
            case 2:
            case 4:
            case 6:
            case 8: Console.WriteLine("{0} es par", num);
                    break;
            case 10: Console.WriteLine ("{0} es par y múltiplo de 5", num);
                    break;
            default: Console.WriteLine("Número fuera de rango."); 
                    break;
        }
    }
}
