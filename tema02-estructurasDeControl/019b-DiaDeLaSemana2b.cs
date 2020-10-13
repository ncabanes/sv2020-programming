// Nombre de un día de la semana
// (V2: "Fin de semana")
// Variante "b": caso 6 vacío

using System;

class Ejercicio_19
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
            case 3: Console.WriteLine("Miércoles"); break;
            case 4: Console.WriteLine("Jueves"); break;
            case 5: Console.WriteLine("Viernes"); break;
            case 6: 
            case 7: Console.WriteLine("Fin de semana"); break;
            default: Console.WriteLine("Día no válido"); break;
        }
    }
}
