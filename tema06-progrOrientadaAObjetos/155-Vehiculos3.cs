/*
155. A partir del ejercicio anterior (Vehículo y derivadas, 154), crea un 
programa en el que se muestre un menú al usuario y se le permita introducir 
datos (en un array de 1000 vehículos) de coches o motos, mostrar todos los 
datos almacenados hasta el momento, buscar en ellos (a partir de su ToString), 
o modificar uno concreto.
*/

// Gonzalo (...)

using System;

class Vehiculo
{
    protected string marca;
    protected string modelo;
    protected int cantidadDeRuedas;

    public Vehiculo(string marca, string modelo, int cantidadDeRuedas)
    {
        this.marca = marca;
        this.modelo = modelo;
        this.cantidadDeRuedas = cantidadDeRuedas;
    }

    public string Marca { get; set; }
    public string Modelo { get; set; }
    public int CantidadDeRuedas { get; set; }

    public override string ToString()
    {
        return marca + " " + modelo + " " + cantidadDeRuedas + " ruedas.";
    }
}

// ---------------------------------

class Coche : Vehiculo
{
    public Coche(string marca, string modelo)
        : base(marca, modelo, 4)
    {
    }

    public override string ToString()
    {
        return base.ToString() + " (Coche)";
    }
}

// ---------------------------------

class Moto : Vehiculo
{
    string tipoDeLicencia = "A1";

    public Moto(string marca, string modelo)
        : base(marca, modelo, 2)
    {
    }

    public override string ToString()
    {
        return base.ToString() + ". (Moto). Licencia: " + tipoDeLicencia;
    }

}

// ---------------------------------
public class PruebaDePrograma
{
    static void Main()
    {
        Vehiculo[] misVehiculos = new Vehiculo[1000];
        string marca;
        string modelo;
        int cantidad = 0;
        int opcion;
        string texto;
        bool encontrado = false;
        int opcionAModificar;

        do
        {
            Console.Clear();
            Console.WriteLine("**********MENU**********");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("1. Introducir coche");
            Console.WriteLine("2. Introducir moto");
            Console.WriteLine("3. Mostrar vehiculos almacenados");
            Console.WriteLine("4. Buscar vehiculo");
            Console.WriteLine("5. Modificar vehiculo");
            Console.WriteLine();
            Console.WriteLine("0. Salir");
            Console.WriteLine();
            Console.Write("Elija una opcion: ");
            opcion = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
                    
            switch (opcion)
            {
                case 1:
                    // Nota: falta comprobar si cabe
                    Console.Write("Introduzca marca: ");
                    marca = Console.ReadLine();
                    Console.Write("Introduzca modelo: ");
                    modelo = Console.ReadLine();
                    misVehiculos[cantidad] = new Coche(marca, modelo);
                    cantidad++;
                    break;

                case 2:
                    // Nota: falta comprobar si cabe
                    Console.Write("Introduzca marca: ");
                    marca = Console.ReadLine();
                    Console.Write("Introduzca modelo: ");
                    modelo = Console.ReadLine();
                    misVehiculos[cantidad] = new Moto(marca, modelo);
                    cantidad++;
                    break;

                case 3:
                    foreach (Vehiculo v in misVehiculos)
                    {
                        Console.WriteLine(v);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Pulsa ENTER para volver al MENU");
                    Console.ReadLine();
                    break;

                case 4:
                    Console.Write("Texto a buscar: ");
                    texto = Console.ReadLine();
                    for (int i = 0; i < cantidad; i++)
                    {
                        encontrado = false;
                        if (misVehiculos[i].ToString().ToUpper().Contains
                            (texto.ToUpper()))
                        {
                            encontrado = true;
                        }
                        if (encontrado)
                        {
                            Console.WriteLine(misVehiculos[i]);
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine("Pulsa ENTER para volver al MENU");
                    Console.ReadLine();
                    break;

                case 5:
                    int nuevaOpcion;

                    Console.Write("Indica que espacio desea modificar: ");
                    opcionAModificar = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine();
                    Console.WriteLine("1. Nuevo Coche");
                    Console.WriteLine("2. Nueva moto");
                    Console.WriteLine();
                    Console.Write("indica el nuevo tipo de vehiculo: ");
                    nuevaOpcion = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();

                    if (opcionAModificar <= cantidad)
                    {
                        if(nuevaOpcion == 1)
                        {
                            Console.Write("Introduzca marca: ");
                            marca = Console.ReadLine();
                            Console.Write("Introduzca modelo: ");
                            modelo = Console.ReadLine();
                            Vehiculo v = new Coche(marca, modelo);

                            misVehiculos[opcionAModificar - 1] = v;
                        }
                        else if (nuevaOpcion == 2)
                        {
                            Console.Write("Introduzca marca: ");
                            marca = Console.ReadLine();
                            Console.Write("Introduzca modelo: ");
                            modelo = Console.ReadLine();
                            Vehiculo v = new Moto(marca, modelo);

                            misVehiculos[opcionAModificar - 1] = v;
                        }
                        else
                            Console.WriteLine("Opcion no valida");
                    }
                    else
                        Console.WriteLine("Ese vehiculo aun no existe");
                        Console.WriteLine();
                        Console.WriteLine("Pulsa ENTER para volver al MENU");
                        Console.ReadLine();

                    break;
            }
        }
        while (opcion != 0);

        Console.WriteLine("Gracias por su visita.... Hasta la proxima");
    }

}
