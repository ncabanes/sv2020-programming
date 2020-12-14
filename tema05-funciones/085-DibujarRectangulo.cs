/* JOSE (...)
 * 
 * 85. Crea una función llamada "DibujarRectangulo", que mostrará un rectángulo 
 * con el ancho, la altura y el carácter que se indiquen como parámetros. Añade 
 * un "Main" de prueba. La función deberá aparecer después de "Main".
 */
using System;

class ejer_05_85
{
    static void Main()
    {
        int altura, ancho;
        char caracter;
        
        Console.Write("Introduce la altura: ");
        altura = Convert.ToInt32(Console.ReadLine());
        
        Console.Write("Introduce el ancho: ");
        ancho = Convert.ToInt32(Console.ReadLine());
        
        Console.Write("Introduce el carácter: ");
        caracter = Convert.ToChar(Console.ReadLine());
        
       DibujarRectangulo(altura, ancho, caracter);
    }
    
    static void DibujarRectangulo(int altura, int ancho, char caracter)
    {
        for (int fila = 1; fila <= altura; fila++)
        {
            for (int columna = 1; columna <= ancho; columna++)
            {
                Console.Write(caracter);
            }
            Console.WriteLine();
        }
       
    }
}
