/* Ej_12 
* Programa  que pide un número y lo muestra en pantalla. 
* Si es de menos de 3 cifras, aparecerá con ceros a 
* la izquierda hasta alcanzar las tres cifras.

* Por Jesús (...)
*/
   
using System;
class Ej_12
{
    static void Main()
    {
		int n;		
		Console.WriteLine("Introduce un número entero");
		n = Convert.ToInt32(Console.ReadLine());
		
        if (n < 10)
            Console.WriteLine("00{0}", n);
        else if (n < 100)
            Console.WriteLine("0{0}", n);
        else
            Console.WriteLine("{0}",n);

	  }
	}
