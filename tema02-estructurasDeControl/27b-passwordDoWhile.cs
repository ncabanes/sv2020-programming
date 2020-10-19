/* Pide repetidamente una contraseña numérica hasta que se introduzca 1234.
 * usando "while"
 * Hugo (...)
 */

using System;

class Ejercicio_27b
{
    static void Main()
    {
        int contrasenya = 1234, intento;
        
        Console.WriteLine("Introduce una contraseña:");
        intento = Convert.ToInt32(Console.ReadLine());
        
        while (intento != contrasenya)
        {
            Console.WriteLine("CONTRASEÑA INCORRECTA");
            
            Console.WriteLine("Introduce una contraseña:");
            intento = Convert.ToInt32(Console.ReadLine());
        }
        
        Console.WriteLine("CONTRASEÑA CORRECTA. PUEDES PASAR");
    }
}
