//Jorge (...)
//1º Dam semipresencial 

/*
 * 189. Crea un programa que pregunte al usuario su fecha de nacimiento 
 * (día, mes y año) y le diga cuántos días ha vivido hasta ahora.
 * */

using System;


class Program
{
    static void Main(string[] args)
    {
        Console.Write("Indique su fecha de nacimiento (DD/MM/AAAA): ");
        string cadenaFechaNacimiento = Console.ReadLine();
        string[] arrayFechaNacimiento = cadenaFechaNacimiento.Split('/');
        DateTime fechaActual = DateTime.Now;
        DateTime fechaNacimiento = new DateTime(
            Convert.ToInt32(arrayFechaNacimiento[2]), 
            Convert.ToInt32(arrayFechaNacimiento[1]), 
            Convert.ToInt32(arrayFechaNacimiento[0]));
        

        TimeSpan diferencia = fechaActual.Subtract(fechaNacimiento);

        Console.WriteLine("Fecha Actual: {0}/{1}/{2}", 
            fechaActual.Day, fechaActual.Month, fechaActual.Year);
        Console.WriteLine("Fecha de nacimiento: {0}/{1}/{2}", 
            fechaNacimiento.Day, fechaNacimiento.Month, fechaNacimiento.Year);
        Console.WriteLine("Ha vivido {0} dias", diferencia.Days);
    }
}

