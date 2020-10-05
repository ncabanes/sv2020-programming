/*Carlos (...)
 * Ejercicio 11
 * Dias Semana */
 
using System;

class DiasSemana
{
    static void Main ()
    {
        int numeroDeDia; 
        
        Console.WriteLine("Dime el numero de la semana");
        numeroDeDia= Convert.ToInt32(Console.ReadLine());
         
              
        if (numeroDeDia==1)
        {
            Console.WriteLine ("{0} es el LUNES",numeroDeDia);
        }
        else if (numeroDeDia==2)
        {
            Console.WriteLine ("{0} es el MARTES",numeroDeDia);
        }
        else if (numeroDeDia==3)
        {
            Console.WriteLine ("{0} es el MIERCOLES",numeroDeDia);
        }
        else if (numeroDeDia==4)
        {
            Console.WriteLine ("{0} es el JUEVES",numeroDeDia);
        }
        else if (numeroDeDia==5)
        {
            Console.WriteLine ("{0} es el VIERNES",numeroDeDia);
        }
        else if (numeroDeDia==6)
        {
            Console.WriteLine ("{0} es el SABADO",numeroDeDia);
        }
        else if (numeroDeDia==7)
        {
            Console.WriteLine ("{0} es el DOMINGO",numeroDeDia);
        }
        else
        {
            Console.WriteLine ("Recuerda que la semana solo tienes 7 dias");
        }
    }
}
    
    
    
    
    
    
    
    
    
    


