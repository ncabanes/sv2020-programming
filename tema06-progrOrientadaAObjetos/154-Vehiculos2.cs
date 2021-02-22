/* Eduardo (...=
 * 
 * Crea una nueva versión de la clase Vehículo y derivadas (ej. 153), en la que 
 * uses propiedades en formato compacto, no haya constructor vacío y reemplaces 
 * el método Mostrar por un ToString. Además, en la clase moto habrá un 
 * atributo adicional, el "tipo de licencia" necesario para conducirla.
 */

using System;

class Vehiculo
{
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public byte CantidadDeRuedas { get; set; }

    public Vehiculo (string Marca, string Modelo, byte CantidadDeRuedas)
    {
        this.Marca = Marca;
        this.Modelo = Modelo;
        this.CantidadDeRuedas = CantidadDeRuedas;
    }

    
    public override string ToString()
    {
        return "Marca: " + Marca + ", Modelo: " + Modelo +
            ", Cantidad de Ruedas: " + CantidadDeRuedas;
    }
}
//-------------------------------------
class Coche : Vehiculo
{
    public Coche(string marca, string modelo)
         : base(marca, modelo, 4)
    {
    }

    public override string ToString()
    {
        return base.ToString() + " (coche)";
    }
}
//-------------------------------------
class Moto: Vehiculo
{
    protected string tipoDeLicencia;

    public Moto (string marca, string modelo, string tipoDeLicencia)
        : base (marca, modelo, 2)
    {
        this.tipoDeLicencia = tipoDeLicencia;

    }
    public override string ToString()
    {
        return base.ToString() + " (moto)";
    }
}
//---------------------------------------
class Program
{
    static void Main()
    {
        Vehiculo[] vehiculos = new Vehiculo[3];

        vehiculos[0] = new Vehiculo("Seat", "Ibiza", 4);
        vehiculos[1] = new Coche("Mitsubishi", "Space Runner");
        vehiculos[2] = new Moto("Derbi", "Variant Start", "A2");

        foreach(Vehiculo v in vehiculos)
        {
            Console.WriteLine(v);
        }
    }
}


