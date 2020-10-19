/*
Carlos (...)
Ejercicio 31. Contraseña con 3 intententos.
*/

using System;

class Ejercicio31
{
    static void Main()
    {
        int pass;
        int cont = 1;

        Console.Write("Introduzca la contraseña: ");
        pass = Convert.ToInt32(Console.ReadLine());
        
        while ((pass != 1234) && (cont < 3))
        {
            Console.Write("Contraseña incorrecta, vuelva a introducir"+
                " la contraseña: ");
            pass = Convert.ToInt32(Console.ReadLine());
            cont = cont + 1;
        }
        if (pass != 1234)
        {
            Console.WriteLine("Acceso denegado");
        }
        else
        {
            Console.WriteLine("Acceso concedido");
        }
    }
}
