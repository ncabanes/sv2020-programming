/*Alumno: Verónica (...)
 Crea un menú como el siguiente. El usuario deberá escoger la opción 0, 1, 2 o 
 3 y después se le mostrará la opción que ha escogido, usando "switch"*/

using System;   

class Ejercicio_59a

{   
    static void Main()   
    {   
        char eleccion;
        
        Console.WriteLine("Menú\n1.Jugar\n2.Cargar \n3.Ver mejores puntuaciones "
        +"\n0.Salir");
        Console.WriteLine();
        Console.WriteLine("Elija una opción: ");
        eleccion = Convert.ToChar(Console.ReadLine());
        
        switch (eleccion)
        {
            case '1': 
                    Console.WriteLine("Ha escogido la opción \""+eleccion
                    +"\": \"Jugar\"");
                    break;
            case '2': 
                    Console.WriteLine("Ha escogido la opción \""+eleccion
                    +"\": \"Cargar\"");
                    break;
            case '3': 
                    Console.WriteLine("Ha escogido la opción \""+eleccion
                    +"\": \"Ver mejores puntuaciones\"");
                    break;
            case '0': 
                    Console.WriteLine("Ha escogido la opción \""+eleccion
                    +"\": \"Salir\"");
                    break;
            default:
                    Console.WriteLine("No es una opción válida");
                    break;
        }
        
     }

}  
