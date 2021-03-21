using System;

public class Circunferencia
{
    public static void Main(string[] args)
    {
        double pi, radio, longitud;
        
        pi = 3.14159265359;
        Console.Write("Dime el radio: ");
        radio = Convert.ToDouble( Console.ReadLine() );
        longitud = 2*pi*radio;
        Console.WriteLine("Longitud de la circunferencia: " + longitud); 
    }
}
