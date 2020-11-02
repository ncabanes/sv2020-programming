/*  Angel (...)
    Ejercicio: Calcular volumen de un cilindro con 2 decimales */
    
using System;

class Ejercicio03
{
    static void Main()
    {
        float radio, altura, volumen;
        float pi=3.141592654f;
        
        Console.Write("Introduce el radio del cilindro: ");
        radio = Convert.ToSingle(Console.ReadLine());
        
        Console.Write("Introduce la altura del cilindro: ");
        altura = Convert.ToSingle(Console.ReadLine());
        
        volumen = pi * radio * radio * altura; 
    
        Console.WriteLine(volumen.ToString("0.00"));
    }
}
