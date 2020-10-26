/* Devuelve el cambio de una compra, utilizando los billetes o monedas 
 * más grandes. Disponiendo de billetes y monedas de 100, 10, 5, y 1.
 * Hugo (...)
 */
 
using System;

class Ejercicio_45
{
    static void Main()
    {
        int precio, pagado, cambio;
        
        Console.Write("Introduce el precio: ");
        precio = Convert.ToInt32(Console.ReadLine());
        Console.Write("Introduce el importe pagado: ");
        pagado = Convert.ToInt32(Console.ReadLine());
        
        cambio = pagado - precio;
        
        if (cambio > 0)
        {
            Console.Write("Tu cambio es {0}: ", cambio);         
            while (cambio / 100 >= 1)
            {    
                Console.Write("100 ");
                cambio = cambio - 100;
            }
            while (cambio / 10 >= 1)
            {
                Console.Write("10 ");    
                cambio = cambio - 10;
            }
            while (cambio / 5 >= 1)
            {
                Console.Write("5 ");
                cambio = cambio - 5;
            }
            while (cambio / 1 >= 1)
            {
                Console.Write("1 ");
                cambio = cambio - 1;
            }
        }
        else
            Console.WriteLine("Los datos introducidos no son correctos.");
        
    }
}
