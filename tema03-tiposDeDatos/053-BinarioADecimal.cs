/*    53. Pide al usuario un número binario (por ejemplo 1101) y muestra su 
 * equivalente en decimal. Debes hacerlo de la siguiente forma: leerás un número
 *  entero largo n, e irás extrayendo cada vez su última cifra 
 * (con "cifra = n % 10") y eliminando esa cifra (con "n = n / 10"); si esa 
 * cifra es 1, deberás sumar la correspondiente potencia de 2 (que será 1 para 
 * la primera cifra que elimines, luego 2 para la siguiente, después 4, 8 y así 
 * sucesivamente). Finalmente, muestra el equivalente en binario de ese número 
 * que has obtenido (si todo ha ido bien, debería coincidir con el número 
 * original). 
 * 
 * Iván (...)
 */

using System;

public class Ejercicio_53
{
    public static void Main()
    {
        int numero;
        int cifra = 0;
        int potencia = 1;
        int resultado = 0;
        
        Console.WriteLine("Introduce un número binario: ");
        numero = Convert.ToInt32(Console.ReadLine());
        
        while (numero > 0)
        {
            cifra = numero % 10;
            resultado += cifra * potencia;
            potencia *= 2;
            numero /= 10;
        }
        
        Console.WriteLine("El numero en decimal es: {0}", resultado);
        Console.WriteLine("El numero {0} en binario es {1}", resultado,
            Convert.ToString(resultado, 2));
    }
}
