using System;
using System.Text;

class Ejercicio76
{
    /*Carlos (...)
    
    76. Pide al usuario una frase y convierte todos sus espacios en 
    guiones bajos, usando "for" y un StringBuilder. Finalmente, muestra 
    la cadena resultante convertida a mayúsculas.*/
    
    
    static void Main ()
    {
        Console.WriteLine( "Introduce una frase: " );
        string frase = Console.ReadLine();
        
        StringBuilder fraseModificada = new StringBuilder ( frase );
        
        for (int i = 0; i < frase.Length; i++)
        {
            if ( fraseModificada[i] == ' ' )
            {
                fraseModificada[i] = '_';
            }
        }
        
        Console.WriteLine ( fraseModificada.ToString().ToUpper() );
    }
}
