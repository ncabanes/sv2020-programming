// Ejercicio_Tema3_ Primera Semana_4 (51)

// Pide al usuario dos números enteros cortos y muestra todos los números entre 
// ellos, en hexadecimal, en la misma línea, separados por un espacio. 

// Por ejemplo, si introduce 8 y 11, deberás mostrar "8 9 a b". El programa se 
// debe comportar correctamente si introduce los números en orden contrario, es 
// decir, si primero indica 11 y 8 en vez de 8 y 11. 

using  System;
class Ejercicio_51
{
    static void Main()
    {

        Console.Write("Introduce un numero: ");
        short n1 = Convert.ToInt16(Console.ReadLine());

        Console.Write("Introduce otro numero: ");
        short n2 = Convert.ToInt16(Console.ReadLine());
        
        if (n1 <= n2 )
        {   
            for(int i = n1; i <= n2; i++)
                Console.Write( Convert.ToString(i , 16)  + " ");
        }        
        else 
        {
            for(int i = n2; i <= n1; i++)
                Console.Write( Convert.ToString(i , 16) ) + " ";
        }
        Console.WriteLine();
    }
}
