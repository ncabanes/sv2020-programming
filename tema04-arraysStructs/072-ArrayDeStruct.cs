//Gonzalo (...)

//72. Crea un "struct" para almacenar algunos datos de personas, de momento sólo:
//nombre (cadena de texto) y fecha de nacimiento (días, mes, año, en forma de 
//struct anidado). Pide al usuario datos de 3 personas (que serán parte de un 
//array) y luego muéstralos.

using System;

class Ejercicio72
{
    struct fechaNacimiento
    {
        public short dia;
        public short mes;
        public short anyo;        
    }   
    struct archivoPersona
    {
        public string nombre;
        public fechaNacimiento diaNacimiento;
    }
    static void Main()
    {
        archivoPersona [] personas = new archivoPersona[3];
        
        for (int i=0; i<3; i++)
        {
            Console.Write("Dame el nombre de la persona: ");
            personas[i].nombre = Console.ReadLine();
            Console.Write("El dia de nacimiento: ");
            personas[i].diaNacimiento.dia = Convert.ToInt16(Console.ReadLine());
            Console.Write("El mes de nacimiento (0-12): ");
            personas[i].diaNacimiento.mes = Convert.ToInt16(Console.ReadLine());
            Console.Write("El año de nacimiento: ");
            personas[i].diaNacimiento.anyo = Convert.ToInt16(Console.ReadLine());
        }
        Console.WriteLine();
        Console.WriteLine("Estos son los datos que hay almacenados: ");
        
        for (int i=0; i<3; i++)
        {
            Console.WriteLine("{0}, {1}-{2}-{3}", 
                personas[i].nombre, 
                personas[i].diaNacimiento.dia, 
                personas[i].diaNacimiento.mes,
                personas[i].diaNacimiento.anyo);
        }
    }
    
    
}

