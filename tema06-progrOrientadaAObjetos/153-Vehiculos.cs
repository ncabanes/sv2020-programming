/*
Ej.153

Crea una clase Vehiculo, con atributos: marca, modelo, cantidadDeRuedas. Crea 
un único constructor que dé valores a los 3 atributos, y getters/setters o bien 
propiedades en formato largo. También habrá un método Mostrar, que escribirá la 
marca, el modelo y la cantidad de ruedas.

Crea una clase Coche, que herede de vehículo. Su único constructor dará valor a 
marca y modelo, y prefijará las ruedas a 4. El método Mostrar, escribirá la 
marca, el modelo y la cantidad de ruedas, seguido de "(Coche)".

Crea una clase Moto, que herede de vehículo. Su único constructor dará valor a 
marca y modelo, y prefijará las ruedas a 2. El método Mostrar, escribirá la 
marca, el modelo y la cantidad de ruedas, seguido de "(Moto)".

Crea un array de 3 vehículos, que contenga un vehículo, un coche, una moto y 
luego muéstralos.
*/

// Carlos (...)

using System;


class Vehiculo
{
    private string marca;
    private string modelo;
    private byte cantidadDeRuedas;
    public string Marca
    {
        get { return marca; }
        set { marca = value; }
    }

    public string Modelo
    {
        get { return modelo; }
        set { modelo = value; }
    }

    public byte CantidadDeRuedas
    {
        get { return cantidadDeRuedas; }
        set { cantidadDeRuedas = value; }
    }

    public Vehiculo(string Marca, string Modelo, byte CantidadDeRuedas)
    {
        this.Marca = Marca;
        this.Modelo = Modelo;
        this.CantidadDeRuedas = CantidadDeRuedas;
    }

    public virtual void Mostrar()
    {
        Console.Write("Marca " + this.Marca + ", modelo " + this.Modelo +
            ", cantidad de ruedas: " + this.CantidadDeRuedas);
    }
}

// ---------------------------------------------

class Coche: Vehiculo
{
    public Coche (string Marca, string Modelo) 
        : base (Marca, Modelo, 4)
    {
    }

    public override void Mostrar()
    {
        base.Mostrar();
        Console.Write(" (coche)");
    }
}


// ---------------------------------------------

class Moto: Vehiculo
{
    public Moto(string marca, string modelo) 
        : base(marca, modelo, 2) 
    {
    }

    public override void Mostrar()
    {
        base.Mostrar();
        Console.Write(" (moto)");
    }
}


// ---------------------------------------------

class PruebaVehiculos
{
    static void Main()
    {
        Vehiculo[] vehiculos = new Vehiculo[3];

        vehiculos[0] = new Vehiculo("Seat", "600", 4);
        vehiculos[1] = new Coche("Peugeot", "206");
        vehiculos[2] = new Moto("Yamaha", "Aerox");

        foreach(Vehiculo v in vehiculos)
        {
            v.Mostrar(); 
            Console.WriteLine();
        }

    }
}

