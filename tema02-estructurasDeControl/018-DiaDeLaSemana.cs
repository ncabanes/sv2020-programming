// Nombre de un día de la semana

using System;

class Ejercicio_18
{
    static void Main()
    {   
        int dias;
        Console.WriteLine("Introduce un número de día, del 1 al 7");
        dias = Convert.ToInt32(Console.ReadLine());
    
        
        switch(dias)
        {
            case 1: Console.WriteLine("Lunes"); break;
            case 2: Console.WriteLine("Martes"); break;
            case 3: Console.WriteLine("Miercole"); break;
            case 4: Console.WriteLine("Jueves"); break;
            case 5: Console.WriteLine("Viernes"); break;
            case 6: Console.WriteLine("Sábado"); break;
            case 7: Console.WriteLine("Domingo"); break;
            default: Console.WriteLine("Dái no válido"); break;
        }
    }
}

        
        
