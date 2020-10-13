//Jorge (...) - Ejercicio 21bis. Mostrar los días que tiene el mes.

using System;
class Ejercicio21bis
{
    static void Main()
    {
        int mes;

        Console.Write("Introduce un número del 1 al 12: ");
        mes = Convert.ToInt32(Console.ReadLine());

        switch (mes)
        {
            case 1:
            case 3:
            case 5:
            case 7:
            case 8:
            case 10:
            case 12:
                Console.WriteLine("31 días.");
                break;
            case 2:
                Console.WriteLine("28 días.");
                break;
            case 4:
            case 6:
            case 9:
            case 11:
                Console.WriteLine("30 días");
                break;
            default:
                Console.WriteLine("El número que has introducido no es válido.");
                break;
        }
    }
}
