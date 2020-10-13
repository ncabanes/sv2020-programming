/* Pide un número del 1 al 10 y dice si es par, múltiplo de 5 o ambas cosas. 
 * Usando "switch"
 * Hugo (...)
 */

using System;

class Ejercicio_20
{
    static void Main()
    {
        int num;
        
        Console.WriteLine("Introduce un número del 1 al 10");
        num = Convert.ToInt32(Console.ReadLine());
        
        switch (num)
        {
            case 1: goto case 9;
            case 2: goto case 8;
            case 3: goto case 9 ;
            case 4: goto case 8;
            case 5: Console.WriteLine ("{0} es impar y múltiplo de 5", num);
                    break;
            case 6: goto case 8;
            case 7: goto case 9;
            case 8: Console.WriteLine("{0} es par", num);
                    break;
            case 9: Console.WriteLine("{0} no es par ni múltiplo de 5", num);
                    break;
            case 10: Console.WriteLine ("{0} es par y múltiplo de 5", num);
                    break;
            default: Console.WriteLine("Número fuera de rango."); 
                    break;
        }
    }
}
