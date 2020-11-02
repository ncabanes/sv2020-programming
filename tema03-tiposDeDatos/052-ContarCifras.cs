/*Carlos (...)
    
    52. Pide al usuario un número entero largo y respóndele cuántas 
    cifras tiene. Lo puedes conseguir dividiendo entre 10 tantas veces 
    como sea necesaria hasta que el número se convierta en 0.  
*/

using System;
class ejercicio52
{   
    static void Main()
    {
        Console.WriteLine ( "Introduce un número entero largo: " );
        long numero = Convert.ToInt64 ( Console.ReadLine () );
        int contadorCifras;
        
        contadorCifras = 0;
        while ( numero > 0 )
        {
            numero /= 10;
            contadorCifras++;
        }   
        Console.WriteLine ( contadorCifras );
    }
}
