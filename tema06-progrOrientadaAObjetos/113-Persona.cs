/* Crea un clase "Persona", para almacenar algunos datos de personas, 
 * de momento sólo: nombre (cadena de texto), edad (byte) y eMail 
 * (cadena). Estos atributos deben ser accesibles a través de getter y 
 * setters. Crea, en el mismo fichero fuente, una clase 
 * "PruebaDePersona", que contendrá Main, y que pedirá al usuario los 
 * datos de 2 personas (sin usar todavía un array) y luego los 
 * mostrará. */
 
// Eduardo (...)

using System;

class Persona
{
    private string nombre;
    private byte edad;
    private string eMail;

    public string GetNombre() { return nombre; }
    public byte GetEdad() { return edad; }
    public string GetEmail() { return eMail; }

    public void SetNombre(string nuevoNombre) { nombre = nuevoNombre; }
    public void SetEdad(byte nuevaEdad) { edad = nuevaEdad; }
    public void SetEmail(string nuevoEmail) { eMail = nuevoEmail; }

    public void Mostrar() 
    {
        Console.WriteLine("Nombre: {0}, edad: {1}, eMail: {2}",
            nombre, edad, eMail);
    }
}

class PruebaDePersona
{
    static void Main()
    {
        Persona p1 = new Persona();
        Persona p2 = new Persona();

        Console.WriteLine("Nombre de la primera persona:");
        p1.SetNombre(Console.ReadLine());
        Console.WriteLine("Edad de la primera persona:");
        p1.SetEdad(Convert.ToByte(Console.ReadLine()));
        Console.WriteLine("Email de la primera persona:");
        p1.SetEmail(Console.ReadLine());

        Console.WriteLine("Nombre de la segunda persona:");
        p2.SetNombre(Console.ReadLine());
        Console.WriteLine("Edad de la segunda persona:");
        p2.SetEdad(Convert.ToByte(Console.ReadLine()));
        Console.WriteLine("Email de la segunda persona:");
        p2.SetEmail(Console.ReadLine());

        Console.WriteLine();
        p1.Mostrar();
        p2.Mostrar();
    }
}
