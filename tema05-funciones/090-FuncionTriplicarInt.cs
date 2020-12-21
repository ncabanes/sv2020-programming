/*90. Crea una función entera llamada "Triplicar", que devolverá triplicado
el valor del número entero pasado como parámetro (por ejemplo, si el parámetro
es 5, se devolverá 15). Pruébala desde Main.*/

//ALBERTO (...)


using System;

class EJERCICIO90
{
    static void Main()
    {
        Console.WriteLine(Triplicar(5));
    }
    
    static int Triplicar(int numero)
    {
        int resultado = numero * 3;
        return resultado;
    }
}

