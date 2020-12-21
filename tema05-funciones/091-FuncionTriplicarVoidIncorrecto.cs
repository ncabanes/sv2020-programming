/* Ej_91 . Crea un procedimiento llamado "Triplicar", que triplicará el 
 * valor del número entero pasado como parámetro (por ejemplo, si el 
 * parámetro es 5, se convertirá en 15), sin usar "ref". Comprueba desde
 * Main si funciona correctamente.
 */
using System;

class Ej_91
{   
    public static void Triplicar (int num)
    {
        num = num*3;
    }

    public static void Main ()
    {
        Console.WriteLine("Introduzca un numero");
        int valor = Convert.ToInt32(Console.ReadLine());
        Triplicar(valor);
        
        // Esto no deberá mostrar cambios
        Console.WriteLine("Tras triplicar tengo... " + valor);
    }
}
