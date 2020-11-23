using System;

class Ejercicio71
{
    /*Carlos (...)
    71. Crea un "struct" para almacenar algunos datos de personas, de 
    momento sólo: nombre (cadena de texto) y edad (byte). Pide al 
    usuario datos de 2 personas (sin usar todavía un array) y luego 
    muéstralos.*/
    
    struct tipoPersona
    {
        public string nombre;
        public byte edad; 
    }
    
    static void Main ()
    {
        tipoPersona persona1, persona2;
        
        Console.WriteLine ( "Introduce el nombre de la persona 1: " );
        persona1.nombre = Console.ReadLine();
        Console.WriteLine ( "Introduce su edad: " );
        persona1.edad = Convert.ToByte(Console.ReadLine());        
        
        Console.WriteLine ( "Introduce el nombre de la persona 2: " );
        persona2.nombre = Console.ReadLine();
        Console.WriteLine ( "Introduce una edad: " );
        persona2.edad = Convert.ToByte(Console.ReadLine());
        
        Console.WriteLine ();
        Console.WriteLine ("Datos persona 1: ");
        Console.WriteLine ("Nombre: " + persona1.nombre);
        Console.WriteLine ("Edad: " + persona1.edad);
            
        Console.WriteLine ("Datos persona 2: ");
        Console.WriteLine ("Nombre: " + persona2.nombre);
        Console.WriteLine ("Edad: " + persona2.edad);
    }
}
