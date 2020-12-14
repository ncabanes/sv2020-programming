/* Función llamada "EsPrimoPalindromo", que devuelve true si el parámetro es 
 * un número primo que también es palíndromo, o false en caso contrario. 
 * Se usa para mostrar los primos palíndromos que hay entre el 1 y el 1000.
*
* Hugo Martínez.
*/
using System;

class Ejercicio_87 
{
    static bool EsPrimoPalindromo(int numero)
    {
        int contador = 0;
        bool primo = false;
        bool palindromo = true;
        
        for (int divisor = 1; divisor <= numero / 2; divisor++)
        {
            if (numero % divisor == 0)
                contador++;
        }
        if (contador == 1)
            primo = true;
        
        if (primo)
        {
            string numeroTexto = numero.ToString();
            
            for (int i = 0; i < numeroTexto.Length / 2; i++)
            {
                if (numeroTexto[i] != numeroTexto[numeroTexto.Length-1-i])
                    palindromo = false;  
            }
        }
        
        return palindromo && primo;
    }
    
    static void Main() 
    {
        int cantidad = 0;
        for (int numero = 1; numero <= 1000; numero++)
        {
            if (EsPrimoPalindromo(numero))
            {
                cantidad++;
                Console.Write(numero + " ");
            }
        }
        Console.WriteLine();
        Console.WriteLine("{0} primos palíndromos encontrados", cantidad);
    }
}
