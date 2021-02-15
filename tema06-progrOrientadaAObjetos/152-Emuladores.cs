//Iván (...)
/*152. Emuladores (examen, 2016-2017)

Se desea crear un emulador de múltiples ordenadores clásicos usando un 
diseño orientado a objetos.

Para ello, en primer lugar se considerará, de forma simplificada, que un 
Ordenador está formado únicamente por un Procesador y una Memoria. También nos 
interesará almacenar un nombre para cada ordenador. Los tres valores, en ese 
orden, se deberán indicar en el (único) constructor de la clase Ordenador. Sólo 
se creará un método Get para poder acceder a su nombre, pero también se 
incluirá un método ToString, que devolverá algo como ZxSpectrum, procesador 
Z80, 8 bits, 3.5 MHz, 16384 bytes de memoria.

Un Procesador contendrá una serie de posiciones internas de memoria, 
llamadas registros (por ejemplo A o AX). Por ello, queremos que esta clase 
contenga un único constructor, que recibirá tres parámetros el primero será 
el número de bits del procesador (por ejemplo, 8); el segundo será la 
velocidad de proceso, medida en Megahertzios (por ejemplo, 3.58) y el 
tercero será una cadena de texto que indicará los nombres de los registros 
separados por espacios (por ejemplo A B C D). Además, existirá un método 
AnadirOrden, que servirá para anotar órdenes que acepta este procesador. 
Estas órdenes se indicarán como dos parámetros de AnadirOrden. El primer 
parámetro indicará el código de esa orden (por ejemplo 121 en base decimal o 
0x79 en base hexadecimal) y el segundo parámetro será el equivalente en 
ensamblador de esa orden (por ejemplo, LD A, C). Más adelante, todas las 
órdenes se almacenarán en una estructura de datos, como un array, pero esta 
primera versión no debe preocuparse aún de eso, sino que en ella, el método 
AnadirOrden estará vacío. También existirá un método MostrarOrdenes, que, en
una versión posterior, mostraría toda la lista de órdenes que soporta el 
procesador, pero que por ahora sólo mostrará Lista de órdenes aún no 
disponible. Igualmente, la clase Procesador tendrá métodos Get para su 
número de bits y para su velocidad de proceso. También tendrá un método 
ToString, que devolverá algo como 8 bits, 3.5 MHz.

La clase Memoria contendrá dos atributos: el tamaño y un array de bytes 
que contendrá la información real. Existirá un constructor que recibirá como
parámetro el tamaño de la memoria, en bytes (por ejemplo, 65536) y creará 
un array de bytes de ese tamaño. También se creará un segundo constructor, 
que recibirá el tamaño de la memoria (por ejemplo, 65536) y el tamaño del 
bus de datos, medido en bits (por ejemplo, 8). Aun así, este constructor 
todavía no se va a implementar, así que delegará en el primer constructor e 
ignorará el dato del tamaño del bus de datos (pero contendrá un comentario 
TO DO en su interior, para recordar que se pretende implementar más 
adelante). La clase también tendrá métodos Get(dirección) para obtener el 
valor almacenado en una cierta posición de memoria y Set(dirección, valor) 
para guardar un cierto valor en una posición de memoria. También tendrá un 
método GetTamano, que devuelva su tamaño, medido en bytes.

Crea una clase ProcesadorZ80, que permita crear un procesador Zilog Z80 o 
derivado. Esta clase contendrá un único constructor para indicar la 
velocidad en MHz (porque el número de bits quedará prefijado a 8 y los 
registros estarán prefijados a A B C D E F H L). Su MostrarOrdenes escribirá 
en pantalla el texto Z80 seguido del aviso que se ha indicado en la clase 
procesador. Su método ToString devolverá Z80, seguido del ToString de un 
procesador genérico.

Crea una clase Procesador6502, que permita crear un procesador MOS 6502 o 
derivado. Esta clase contendrá un único constructor para indicar la 
velocidad en MHz (porque el número de bits quedará prefijado a 8 y los 
registros a A X Y). Su MostrarOrdenes escribirá en pantalla el texto 6502  
seguido del aviso previsto en la clase procesador. Su método ToString 
devolverá 6502, seguido del ToString de un procesador genérico.

Crea un programa de prueba (clase Emuladores) que tenga un array de 
ordenadores. Los dos primeros ordenadores estarán prefijados un ZxSpectrum, 
con procesador Z80 a 3.5 MHz y 16384 bytes de memoria, y un Commodore VIC-20,
con procesador 6502 a 1.1 MHz y 5120 bytes de memoria. A continuación, el 
usuario podrá elegir qué ordenadores adicionales desea introducir en el 
array, mediante un menú que le pregunte si quiere añadir un equipo basado en
el Z80 (opción 1) o en el 6502 (opción 2), o bien si quiere ver todos los 
datos que se han introducido hasta el momento (opción 3) o terminar (opción 
0). Cada vez que elija añadir un equipo, se le preguntará el nombre de éste,
la velocidad en MHz y el tamaño de su memoria.*/

using System;

class Ordenador
{
    Procesador procesador;
    Memoria memoria;
    private string nombre;

    public Ordenador(string nombre, Procesador procesador, Memoria memoria)
    {
        this.procesador = procesador;
        this.memoria = memoria;
        this.nombre = nombre;
    }

    public string GetNombre()
    {
        return nombre;
    }

    public override string ToString()
    {
        return nombre + ", procesador: " + procesador + ", " + memoria ;
    }
}

// ------------------------

abstract class Procesador
{
    private int numBits;
    private double velocidadProcesador;
    private string registros;

    public Procesador(int numBits, double velocidadProcesador, string registros)
    {
        this.numBits = numBits;
        this.velocidadProcesador = velocidadProcesador;
        this.registros = registros;
    }

    public int GetNumBits()
    {
        return numBits;
    }

    public double GetVelocidadProcesador()
    {
        return velocidadProcesador;
    }

    public override string ToString()
    {
        return numBits + " bits, " + velocidadProcesador + " MHz";
    }
    
    public void AnadirOrden(int codigo, string orden)
    {
        // TO DO: Implementar en V2
    }

    public virtual void MostrarOrdenes()
    {
        Console.WriteLine("Lista de órdenes aún no disponible.");
    }
}

// ------------------------

class Memoria
{
    protected int tamanyo;
    protected byte[] memoria;

    public Memoria(int tamanyo)
    {
        this.tamanyo = tamanyo;
        memoria = new byte[tamanyo];
    }
    
    public Memoria(int tamanyo, int tamBusDatos): this(tamanyo)
    {
        // TO DO: Implementar en V2
    }
    
    public int GetTamanyo()
    {
        return tamanyo;
    }
    
    public int Get(int pos)
    {
        return memoria[pos];
    }
    
    public void Set(int pos, byte valor)
    {
        
        memoria[pos]= valor;
    }
    
    public override string ToString()
    {
        return tamanyo + " bytes de memoria";
    }
}

// ------------------------

class ProcesadorZ80 : Procesador
{
    public ProcesadorZ80(double velocidadProcesador) : 
        base(8, velocidadProcesador, "A B C D E F H L")
    {
    }

    public override void MostrarOrdenes()
    {
        Console.Write("Z80 ");
        base.MostrarOrdenes();
    }

    public override string ToString()
    {
        return "Z80 " + base.ToString();
    }
}

// ------------------------

class Procesador6502 : Procesador
{
    public Procesador6502(double velocidadProcesador) :
        base(8, velocidadProcesador, "A X Y")
    {
    }

    public override void MostrarOrdenes()
    {
        Console.Write("6502 ");
        base.MostrarOrdenes();
    }

    public override string ToString()
    {
        return "6502 " + base.ToString();
    }
}

// ------------------------

class Emuladores
{
    int contador = 0;
    Ordenador[] ordenadores = new Ordenador[100];
        
    private void MostrarMenu()
    {
        Console.WriteLine("1. Añadir ordenador con procesador Z80.");
        Console.WriteLine("2. Añadir ordenador con procesador 6502.");
        Console.WriteLine("3. Mostrar datos de los ordenadores almacenados.");
        Console.WriteLine("0. Salir.");
        Console.WriteLine("Seleccione una opción:");
    }
    
    void AnyadirProcesadorZ80()
    {
        Procesador procesador;
        Memoria memoria;
        
        Console.WriteLine("Indique el nombre del ordenador: ");
        string nombre = Console.ReadLine();
        Console.WriteLine("Indique la velocidad del procesador: ");
        float velocidadProcesador = Convert.ToSingle(Console.ReadLine());
        procesador = new ProcesadorZ80(velocidadProcesador);
        Console.WriteLine("Indique el tamaño de la memoria: ");
        int tamanyo = Convert.ToInt32(Console.ReadLine());
        memoria = new Memoria(tamanyo);
        
        
        ordenadores[contador] = new Ordenador(nombre, procesador, memoria);
        contador++;
    }
    
    void AnyadirProcesador6502()
    {
        Procesador procesador;
        Memoria memoria;
        
        Console.WriteLine("Indique el nombre del ordenador: ");
        string nombre = Console.ReadLine();
        Console.WriteLine("Indique la velocidad del procesador: ");
        float velocidadProcesador = Convert.ToSingle(Console.ReadLine());
        procesador = new Procesador6502(velocidadProcesador);
        Console.WriteLine("Indique el tamaño de la memoria: ");
        int tamanyo = Convert.ToInt32(Console.ReadLine());
        memoria = new Memoria(tamanyo);
        
        ordenadores[contador] = new Ordenador(nombre, procesador, memoria);
        contador++;
    }
    
    void MostrarDatos(Ordenador[] ordenadores, int contador)
    {
        for(int i = 0; i < contador; i++)
        {
            Console.WriteLine(ordenadores[i]);
        }
    }
    
    void Ejecutar()
    {
        bool salir = false;
        byte opcion;
        
        ProcesadorZ80 a = new ProcesadorZ80(3.5); 
        Memoria m1 = new Memoria(16384);
        ordenadores[0] = new Ordenador("ZxSpectrum", a, m1);
        
        Procesador6502 b = new Procesador6502(1.1);
        Memoria m2 = new Memoria(5120);
        ordenadores[1] = new Ordenador ("Commodore VIC-20", b, m2);
        
        contador = 2;
        
        do
        {
            MostrarMenu();
            opcion = Convert.ToByte(Console.ReadLine());
            Console.WriteLine();
            switch(opcion)
            {
                case 1 : AnyadirProcesadorZ80(); break;
                case 2 : AnyadirProcesador6502(); break;
                case 3 : MostrarDatos(ordenadores, contador); break;
                case 0 : salir = true; break;
                default: Console.WriteLine("Opción no válida."); break;
            }
            Console.WriteLine();
        }while(salir == false);
    }
    
    public static void Main()
    {
        Emuladores e = new Emuladores();
        e.Ejecutar();
    }
}
