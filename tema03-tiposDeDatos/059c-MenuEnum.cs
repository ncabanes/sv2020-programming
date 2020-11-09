/*Alumno: Verónica (...)
Crea una tercera versión del programa 59, que no emplee constantes 
convencionales sino una enumeración*/

using System;   

class Ejercicio_59c

{   
    enum menu { SALIR, JUGAR, CARGAR, VER_MEJORES_PUNTUACIONES}
        
    static void Main()   
    {   
        Console.WriteLine("Menú: ");
        //Para que no imprima directamente la opción del menú (en texto),
        //hacemos typecast a int
        Console.WriteLine((int) menu.JUGAR +".Jugar");
        Console.WriteLine((int) menu.CARGAR +".Cargar");
        Console.WriteLine((int) menu.VER_MEJORES_PUNTUACIONES +".Ver mejores puntuaciones");
        Console.WriteLine((int) menu.SALIR +".Salir");
       
        Console.WriteLine();
        Console.WriteLine("Elija una opción: ");
        byte eleccion = Convert.ToByte(Console.ReadLine());
        
        switch (eleccion)
        {
            case (int) menu.JUGAR: 
                    Console.WriteLine("Ha escogido la opción \""+eleccion
                    +"\": \"Jugar\"");
                    break;
            case (int) menu.CARGAR: 
                    Console.WriteLine("Ha escogido la opción \""+eleccion
                    +"\": \"Cargar\"");
                    break;
            case (int) menu.VER_MEJORES_PUNTUACIONES: 
                    Console.WriteLine("Ha escogido la opción \""+eleccion
                    +"\": \"Ver mejores puntuaciones\"");
                    break;
            case (int) menu.SALIR: 
                    Console.WriteLine("Ha escogido la opción \""+eleccion
                    +"\": \"Salir\"");
                    break;
            default:
                    Console.WriteLine("No es una opción válida");
                    break;
        }
        
     }

}  
