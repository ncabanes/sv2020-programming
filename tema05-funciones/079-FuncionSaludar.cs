/* Alejandro (...) */
/* 79. Crea una función llamada "Saludar", que escriba "Hola, " 
 * seguido del nombre que se indique como parámetro (string). 
 * Empléala en un programa que pregunte al usuario su nombre 
 * y luego le salude.*/
 
using System;

class FuncionSaludar 
{
    public static void Saludar(string nombre)
    {
        Console.WriteLine("Hola, {0}", nombre);
    }

    public static void Main()
    {
        
        string nombreUsuario;
        
        Console.WriteLine("Dime tu nombre ");
        nombreUsuario = Console.ReadLine();
        Saludar(nombreUsuario);
    }
}
