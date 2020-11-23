//Carmen (...)

/*
Crea un array que permita almacenar hasta 1000 números reales de doble 
precisión. Muestra un menú que le permita: Añadir un nuevo dato al final, 
insertar un dato en una cierta posición, borrar el dato que hay en una cierta 
posición, ver todos los datos en su orden original, ver todos los datos en 
orden inverso, mostrar el máximo de los datos, mostrar el mínimo de los datos, 
buscar un cierto dato, salir. La opción de Buscar preguntará el dato que se 
quiere localizar y responderá si ese dato aparece en el array o no.
*/

using System; 

class Ejercicio66
{
    static void Main()
    {
        int capacidad=1000;
        double[] datos= new double[capacidad];
        int cantidad=0;
        
        double dato;
        int posicion;
        int opcion;
        
        do
        {
            Console.WriteLine("Elija una opción del menú: ");
            Console.WriteLine("1.Añadir un dato al final");
            Console.WriteLine("2.Insertar un dato");
            Console.WriteLine("3.Borrar el dato insertado");
            Console.WriteLine("4.Ver los datos en orden");
            Console.WriteLine("5.Ver datos en orden inverso");
            Console.WriteLine("6. Ver el máximo número");
            Console.WriteLine("7.Ver el número mínimo");
            Console.WriteLine("8.Buscar un dato"); 
            Console.WriteLine("9.Salir");
            
            opcion = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            
            switch (opcion)
            {
                case 1: 
                    if (cantidad < capacidad)
                    {
                        Console.WriteLine("Dato a añadir? ");
                        dato = Convert.ToDouble(Console.ReadLine());
                        datos[cantidad] = dato;
                        cantidad++;
                    }
                    else
                        Console.WriteLine("No hay espacio para más datos");
                    break;
                    
                case 2: 
                    Console.Write("Dato a insertar? ");
                    dato = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Posición? ");
                    posicion = Convert.ToInt32(Console.ReadLine());
                    if (cantidad < capacidad)
                    {
                        for (int i = cantidad; i > posicion-1; i--)
                            datos[i]= datos[i-1];
                        datos[posicion-1]= dato;
                        cantidad++;
                    }
                    break;

                case 3:
                    Console.Write("Borrar el dato de la posición: ");
                    posicion= Convert.ToInt32(Console.ReadLine());
                    for (int i =  posicion-1; i < cantidad-1; i++)
                        datos[i]= datos[i+1];
                    cantidad--;
                    break;
                    
                case 4: 
                    Console.Write("Datos en orden... ");
                    for (int i = 0; i< cantidad; i++)
                        Console.WriteLine("{0} ", datos[i]);
                    Console.WriteLine();
                    break;

                case 5:
                    Console.WriteLine("Datos al revés... ");
                    for (int i = cantidad-1; i >= 0; i--)
                        Console.Write("{0} ", datos[i]);
                    Console.WriteLine();
                    break;
                    
                case 6: 
                    Console.Write("Buscando el máximo... ");
                    double maximo = datos[0];
                    for (int i = 1; i < cantidad; i++)
                        if (datos[i] > maximo)
                            maximo = datos[i];
                    Console.WriteLine("El máximo es {0}", maximo);
                    break;

                case 7: Console.Write("Buscando el mínimo... ");
                    double minimo = datos[0];
                    for (int i = 1; i < cantidad; i++)
                        if (datos[i] < minimo)
                            minimo = datos[i];   
                    Console.WriteLine("El mínimo es {0}", minimo);
                    break;

                case 8:
                    Console.WriteLine("Buscar un dato: ");
                    Console.Write("¿Qué dato quiere localizar? ");
                    int n2= Convert.ToInt32(Console.ReadLine());
        
                    bool encontrado = false;
                    for (int i = 0; i < cantidad; i++)
                        if (datos [i] == n2)
                            encontrado= true;
                    if (encontrado)
                        Console.WriteLine("El número sí está entre los datos");
                    else
                        Console.WriteLine("El número no estaba entre los datos");
                break;
            }
        }
        while (opcion != 9); 
           
        Console.WriteLine("Ha elegido usted salir. Hasta otra");
    }
}
