/*Alumno: Verónica (...)
92. Crea un procedimiento llamado "Triplicar", que triplicará el valor de un 
número entero que se le pasará como parámetro ref (por ejemplo, si el parámetro
es 5, se convertirá en 15). Pruébalo desde Main.*/

// Primera prueba de parámetros "ref"

using System;

class Ejercicio_92
{
    static void Triplicar(ref int num)
    {
        num *= 3;
    }
    
    static void Main()
    {
        int input;
        
        Console.Write("Introduce un número: ");
        input = Convert.ToInt32(Console.ReadLine());
        
        Triplicar(ref input);
        
        Console.WriteLine("El número triplicado es: {0}", input);
    }
}
