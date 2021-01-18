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
