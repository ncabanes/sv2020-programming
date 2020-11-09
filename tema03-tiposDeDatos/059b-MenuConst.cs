/*Alumno: Verónica (...)
Crea una nueva versión del programa anterior, que no utilice "números mágicos" 
en la orden "switch", sino constantes*/

using System;   

class Ejercicio_59b

{   
    static void Main()   
    {   
        const int JUGAR = 1;
        const int CARGAR = 2;
        const int VER_MEJORES_PUNTUACIONES = 3;
        const int SALIR = 0;
        byte eleccion;
        
        Console.WriteLine("Menú: ");
        Console.WriteLine(JUGAR +".Jugar");
        Console.WriteLine(CARGAR +".Cargar");
        Console.WriteLine(VER_MEJORES_PUNTUACIONES +".Ver mejores puntuaciones");
        Console.WriteLine(SALIR +".Salir");
       
        Console.WriteLine();
        Console.WriteLine("Elija una opción: ");
        eleccion = Convert.ToByte(Console.ReadLine());
        
        switch (eleccion)
        {
            case JUGAR: 
                    Console.WriteLine("Ha escogido la opción \""+eleccion
                    +"\": \"Jugar\"");
                    break;
            case CARGAR: 
                    Console.WriteLine("Ha escogido la opción \""+eleccion
                    +"\": \"Cargar\"");
                    break;
            case VER_MEJORES_PUNTUACIONES: 
                    Console.WriteLine("Ha escogido la opción \""+eleccion
                    +"\": \"Ver mejores puntuaciones\"");
                    break;
            case SALIR: 
                    Console.WriteLine("Ha escogido la opción \""+eleccion
                    +"\": \"Salir\"");
                    break;
            default:
                    Console.WriteLine("No es una opción válida");
                    break;
        }
        
     }

}  
