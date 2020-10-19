/* Pide repetidamente una contraseña numérica hasta que se introduzca 1234.
 * usando "do..while"
 * Hugo (..)
 */

using System;

class Ejercicio_27a
{
    static void Main()
    {
        int contrasenya = 1234, intento;
        
        do
        {
            Console.WriteLine("Introduce una contraseña:");
            intento = Convert.ToInt32(Console.ReadLine());
            
            if (intento != contrasenya)
            {
                Console.WriteLine("CONTRASEÑA INCORRECTA");
            }
        }
        while (intento != contrasenya);
        
        Console.WriteLine("CONTRASEÑA CORRECTA. PUEDES PASAR");
    }
}
