/*Alumno: Verónica (..)
104. Crea una función ContarMm que obtenga la cantidad de letras mayúsculas 
(en el rango A-Z) y letras minúsculas (en el rango a-z) que hay en la cadena 
que se pasa como parámetro (sin tener en cuenta ñ ni vocales acentuadas, sólo 
el alfabeto inglés). */

using System;

class Ejercicio_104
{
    static void Main()
    {
        int mays = 0, mins = 0;
        ContarMm ("Este es un Texto", out mays, out mins);

        Console.WriteLine ("Mayúsculas: " + mays + ", minúsculas: " + mins);
        
    }
    
    static void ContarMm(string texto, out int mayus, out int minus)
    {
        mayus = 0; 
        minus = 0;
        
        foreach (char letra in texto)
        {
            if( letra >= 'A' && letra <= 'Z')
            {
                mayus++;
            }
            
            if( letra >= 'a' && letra <= 'z')
            {
                minus++;
            }
        }
    }
}
