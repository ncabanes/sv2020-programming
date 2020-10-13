//Jorge (...) - Ejercicio 21. Mostrar el mes y su número de días.

using System;

class Ejercicio21
{
    static void Main()
    {
        int mes;

        Console.Write("Introduce un número del 1 al 12: ");
        mes = Convert.ToInt32(Console.ReadLine());

        switch ( mes )
        {
            case 1:
                Console.WriteLine("Enero, 31 días.");
                break;
            case 2:
                Console.WriteLine("Febrero, 28 días.");
                break;
            case 3:
                Console.WriteLine("Marzo, 31 días.");
                break;
            case 4:
                Console.WriteLine("Abril, 30 días.");
                break;
            case 5:
                Console.WriteLine("Mayo, 31 días.");
                break;
            case 6:
                Console.WriteLine("Junio, 30 días.");
                break;
            case 7:
                Console.WriteLine("Julio, 31 días.");
                break;
            case 8:
                Console.WriteLine("Agosto, 31 días.");
                break;
            case 9:
                Console.WriteLine("Septiembre, 30 días.");
                break;
            case 10:
                Console.WriteLine("Octubre, 31 días.");
                break;
            case 11:
                Console.WriteLine("Noviembre, 30 días.");
                break;
            case 12:
                Console.WriteLine("Diciembre, 31 días.");
                break;
            default:
                Console.WriteLine("El número que has introducido no es válido.");
                break;
        }
    }
}
