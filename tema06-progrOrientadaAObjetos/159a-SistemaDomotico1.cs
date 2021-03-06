/*
Sistema domótico (examen de 2015-2016)

Se desea crear un esqueleto para un sistema domótico (de control informatizado 
de un hogar), usando un diseño orientado a objetos.

Para ello, se creará una clase "SistemaDomótico" (como ya sabes, en tu 
implementación no deberás usar acentos en los nombres de clases, variables o 
métodos), que englobará a todas las demás. El sistema estará previsto para 
controlar:

- Ventanas. Existirá una clase Ventana. A su vez, cada ventana contendrá una 
Persiana, con métodos Subir (que subirá la persiana por completo, para dejar 
pasar toda la luz) y Bajar (que la bajará por completo, para no dejar pasar 
nada de luz), junto con sus variantes sobrecargadas Subir(porcentaje) y 
Bajar(porcentaje), que se comportarán de la siguiente forma: si la persiana 
está subida en un 40% y se indica Subir(20), pasará a estar abierta en un 60%. 
También existirá un método Abrir(porcentaje), que dejará la persiana abierta 
exactamente en el porcentaje que se indica (por ejemplo, Abrir(50) dejaría la 
persiana justo en su posición central, independientemente de donde se 
encontrase anteriormente). El (único) constructor de una Persiana recibirá como 
parámetros la posición inicial de la persiana (0 para cerrada totalmente, 100 
para abierta totalmente). El constructor de una ventana recibirá la persiana 
que contiene esa ventana (o null, si se trata de una ventana sin persiana). En 
Persiana existirá un método "get" que permitirá saber la posición y en Ventana 
un "get" para acceder a los detalles de su persiana.

- Toldos. Por simplicidad, a efectos de programación se considerará que un 
Toldo es un tipo de persiana y se emplearán los mismos métodos para 
configurarlos. El constructor de un Toldo recibirá como parámetro la posición 
inicial (0 para totalmente bajado). Existirá un método "get" que permitirá 
saber la posición.

- Puertas. Para una Puerta normal, sólo existirán los métodos Bloquear y 
Desbloquear, así como un "get" que permita saber si está bloqueada o no. El 
constructor indicará si inicialmente está bloqueada o no. Existirá un caso 
especial, las puertas de garaje, que tendrán métodos Subir, Subir(porcentaje), 
Bajar y Bajar(porcentaje), con comportamiento similar al de las ventanas.

- Calefacciones. Para cada Calefacción se podrá indicar la temperatura (en 
grados centígrados), así como Encender y Apagar ese subsistema de calefacción. 
Existirá un "GetTemperatura" y un "GetEncendido", para saber el estado. El 
constructor recibirá ambos datos como parámetros (el primer parámetro será si 
está encendida o no, el segundo será la temperatura). Existirá un segundo 
constructor que sólo reciba la temperatura y que prefijará esa temperatura pero 
dejará la calefacción apagada.

- El Horno tendrá un comportamiento similar al de la calefacción: temperatura y 
encender/apagar, con sus dos constructores y sus Get.

- Cada Luz se podrá encender o apagar y consultar su estado.

- Finalmente, también existirá un Aspirador robótico, que sólo se podrá 
encender o apagar, y para el que se podrá consultar si está encendido, así como 
el porcentaje de batería.

Todos los dispositivos tendrán un nombre (por ejemplo, "Ventana del salón" o 
"Calefacción del dormitorio 1"), un método SetNombre para fijarlo y un método 
ToString que devolverá la información relevante (por ejemplo, el nombre, la 
temperatura y el estado para una calefacción, o el nombre y la posición de un 
toldo).

La clase SistemaDomótico será la que interaccione con el usuario, para poder 
indicar qué comportamiento se desea de cada componente. En implementaciones 
reales será un panel táctil, pero en nuestra primera simulación será una 
aplicación de Consola que permitirá personalizar cada elemento del sistema 
(encender o apagar luces, subir o bajar persianas, etc).

El programa de prueba será un Main dentro de la clase SistemaDomótico, que 
añadirá 3 ventanas, una puerta de acceso, una puerta de garaje, un toldo, un 
punto de luz y dos calefacciones (todo ello dentro de un único array de 
dispositivos), y permitirá controlarlas de la siguiente forma: bloquear o 
desbloquear la puerta de acceso, encender o apagar el punto de luz, subir por 
completo o bajar por completo la puerta del garaje, subir o bajar un 25% cada 
una de las tres persianas, recoger (subir) o extender (bajar) por completo el 
toldo, subir o bajar un grado cada calefacción, ver el estado de todos los 
dispositivos.  

Recuerda evitar código repetitivo tanto como sea posible, reutilizando 
constructores o métodos cuando corresponda y, si fuera necesario, creando 
clases adicionales. 
*/

// -----------------------
// La clase Dispositivo es la base de todos los demás, abstracta

abstract class Dispositivo
{
    protected string nombre;

    public Dispositivo(string nombre) { this.nombre = nombre; }

    public void SetNombre(string nombre) { this.nombre = nombre; }

    public override string ToString()
    {
        return "Nombre: " + nombre;
    }
}


// -----------------------
﻿// Tenemos dispositivos con una cierta temperatura, como
// las calefacciones y los hornos

﻿class DispositivoCalefactable : Dispositivo
{
    protected int temperatura;
    protected bool encendido;

    public DispositivoCalefactable(bool encendido, int temperatura, string nombre) 
        : base(nombre)
    {
        this.temperatura = temperatura;
        this.encendido = encendido;
    }

    public DispositivoCalefactable(int temperatura, string nombre) 
        : this(false, temperatura, nombre)
    {

    }

    public bool GetEncendido() { return encendido; }
    public int GetTemperatura() { return temperatura; }

    public void SetTemperatura(int temperatura) 
    { 
        this.temperatura = temperatura; 
    }

    public void Encender() { encendido = true; }
    public void Apagar() { encendido = false; }



    public override string ToString()
    {
        return base.ToString() + ", Temperatura: " + temperatura 
                   + ", Encendido: " + encendido;
    }
}

// -----------------------
﻿// Una calefacción es un tipo de dispositivo calefactable

class Calefaccion : DispositivoCalefactable
{
    
    public Calefaccion(bool encendido, int temperatura, string nombre) 
        : base(encendido, temperatura, nombre)
    {
    }

    public Calefaccion(int temperatura, string nombre) 
        : this(false, temperatura, nombre)
    {
    }

}

// -----------------------
﻿// Un horno es un tipo de dispositivo calefactable

class Horno : DispositivoCalefactable
{

    public Horno(bool encendido, int temperatura, string nombre)
        : base(encendido, temperatura, nombre)
    {
    }

    public Horno(int temperatura, string nombre) 
        : this(false, temperatura, nombre)
    {
    }
}


// -----------------------
﻿// Hay una serie de dispositivos que se pueden encender, como las luces
// o los aspiradores

abstract class DispositivoEncendible : Dispositivo
{
    protected bool encendido;

    public DispositivoEncendible(bool encendido, string nombre) : base(nombre)
    {
        this.encendido = encendido;
    }

    public bool GetEncendido() { return encendido; }

    public void Encender() { encendido = true; }
    public void Apagar() { encendido = false; }

    public override string ToString()
    {
        return base.ToString() + ", Estado: " + encendido;
    }
}

// -----------------------
﻿// Una luz es un tipo de dispositivo encendible

class Luz : DispositivoEncendible
{
    public Luz(bool encendido, string nombre) 
        : base(encendido, nombre)
    {
    }
}

// -----------------------

class AspiradorRobotico : DispositivoEncendible
{
    protected byte bateria;

    public AspiradorRobotico(bool encendido, string nombre) 
        : base(encendido, nombre)
    {
        bateria = 75;
    }

   
    public byte GetBateria() { return bateria; }


    public override string ToString()
    {
        return base.ToString() + ", Bateria: " + bateria;
    }
}



// -----------------------
﻿// Una persiana es simplemente un dispositivo que
// puede subir y bajar

class Persiana : Dispositivo
{
    protected byte posicion;
    
    public Persiana(byte posicion, string nombre) 
        : base(nombre)
    {
        this.posicion = posicion;
    }
    
    public byte GetPosicion() { return posicion; }
    public void Subir()
    {
        posicion = 100;
    }

    public void Bajar()
    {
        posicion = 0;
    }

    public void Subir(byte porcentaje)
    {
        posicion += porcentaje;
    }

    public void Bajar(byte porcentaje)
    {
        posicion -= porcentaje;
    }
    
    public override string ToString()
    {
        return base.ToString() + ", Posicion: " + posicion;
    }
}

// -----------------------
﻿﻿// Una toldo un dispositivo es, según el enunciado,
// un tipo de persiana

class Toldo : Persiana
{
    public Toldo(byte posicion, string nombre) 
        : base(posicion, nombre)
    {
    }
}


// -----------------------
﻿// Una puerta se puede bloquear y desbloquear

class Puerta : Dispositivo
{
    protected bool bloqueada;

    public Puerta(bool bloqueada, string nombre) : base(nombre)
    {
        this.bloqueada = bloqueada;
    }

    public void Desbloquear()
    {
        bloqueada = false;
    }

    public void Bloquear()
    {
        bloqueada = true;
    }
    
    public bool GetBloqueada()
    {
        return bloqueada;
    }

    public override string ToString()
    {
        return base.ToString() + ", Bloqueo: " + bloqueada;
    }
}


// -----------------------
﻿// La puerta del garaje tiene comportamiento de puerta
// y comportamiento de persiana. Sin usar interfaces no
// podemos heredar de ambas, debemos escoger una, como puerta

class PuertaGaraje : Puerta
{
    protected byte posicion;

    public PuertaGaraje(bool bloqueda, byte posicion, string nombre) 
        : base(bloqueda, nombre)
    {
        this.posicion = posicion;
    }

    public byte GetPosicion() { return posicion; }

    public void Subir()
    {
        posicion = 100;
    }

    public void Bajar()
    {
        posicion = 0;
    }

    public void Subir(byte porcentaje)
    {
        posicion += porcentaje;
    }

    public void Bajar(byte porcentaje)
    {
        posicion -= porcentaje;
    }

    public override string ToString()
    {
        return base.ToString() + ", Posicion: " + posicion;
    }
}

// -----------------------
// Y una ventana es un dispositivo genérico con persiana

class Ventana : Dispositivo
{
    protected Persiana p;

    public Ventana(Persiana p, string nombre) : base(nombre)
    {
        this.p = p;
    }

    public Persiana GetPersiana() { return p; }

    public override string ToString()
    {
        return base.ToString() + ", Persiana en: " + p.GetPosicion();
    }
}

// -----------------------
﻿// Y finalmente el supuesto panel del sistema domótico

﻿class SistemaDomótico
{
    public static void Main()
    {
        const int OBJETOS = 10;
        int canObjetios = 9;
        Dispositivo[] d = new Dispositivo[OBJETOS];
        d[0] = new Puerta(true, "Puerta de acceso");
        d[1] = new PuertaGaraje(true, 0, "Puerta garaje");
        d[2] = new Toldo(0, "Toldo");
        d[3] = new Luz(true, "Bombilla");
        d[4] = new Calefaccion(false, 20, "Cal1");
        d[5] = new Calefaccion(false, 20, "Cal2");
        d[6] = new Ventana(new Persiana(0, "Persiana 1"), "Ventana 1");
        d[8] = new Ventana(new Persiana(0, "Persiana 2"), "Ventana 2");
        d[7] = new Ventana(new Persiana(0, "Persiana 3"), "Ventana 3");
        string opcion;

        do
        {
            System.Console.WriteLine("1. Bloquear puerta");
            System.Console.WriteLine("2. Desbloquear puerta");
            System.Console.WriteLine("3. Encender luz");
            System.Console.WriteLine("4. Apagar luz");
            System.Console.WriteLine("5. Subir puerta garaje");
            System.Console.WriteLine("6. Bajar puerta garaje");
            System.Console.WriteLine("7. Subir un 25% Persiana 1");
            System.Console.WriteLine("8. Subir un 25% Persiana 2");
            System.Console.WriteLine("9. Subir un 25% Persiana 3");
            System.Console.WriteLine("10. Bajar un 25% Persiana 1");
            System.Console.WriteLine("11. Bajar un 25% Persiana 2");
            System.Console.WriteLine("12. Bajar un 25% Persiana 3");
            System.Console.WriteLine("13. Recoger toldo");
            System.Console.WriteLine("14. Extender toldo");
            System.Console.WriteLine("15. Subir un grado calefaccion");
            System.Console.WriteLine("16. Bajar un grado calefaccion");
            System.Console.WriteLine("17. Ver estado dispositivos");
            System.Console.WriteLine("0. Salir");
            opcion = System.Console.ReadLine();

            switch(opcion)
            {
                case "1":
                    ((Puerta)(d[0])).Bloquear();
                    break;

                case "2":
                    ((Puerta)(d[0])).Desbloquear();
                    break;

                case "3":
                    ((Luz)d[3]).Encender();
                    break;

                case "4":
                    ((Luz)d[3]).Apagar();
                    break;

                case "5":
                    ((PuertaGaraje) (d[1])).Subir();
                    break;

                case "6":
                    ((PuertaGaraje)(d[1])).Bajar();
                    break;

                case "7":
                    ((Persiana)(d[6])).Subir();
                    break;

                case "8":
                    ((Persiana)(d[7])).Subir();
                    break;

                case "9":
                    ((Persiana)(d[8])).Subir();
                    break;

                case "10":
                    ((Persiana)(d[6])).Bajar();
                    break;

                case "11":
                    ((Persiana)(d[7])).Bajar();
                    break;

                case "12":
                    ((Persiana)(d[8])).Bajar();
                    break;

                case "13":
                    ((Toldo)d[3]).Subir();
                    break;

                case "14":
                    ((Toldo)d[3]).Bajar();
                    break;

                case "15":
                    ((Calefaccion)d[4]).
                       SetTemperatura(((Calefaccion)d[4]).
                                      GetTemperatura()+1);
                    ((Calefaccion)d[5]).
                       SetTemperatura(((Calefaccion)d[5]).
                                      GetTemperatura() + 1);

                    break;

                case "16":
                    ((Calefaccion)d[4]).
                       SetTemperatura(((Calefaccion)d[4]).
                                      GetTemperatura() - 1);

                    ((Calefaccion)d[5]).
                       SetTemperatura(((Calefaccion)d[5]).
                                      GetTemperatura() - 1);

                    break;

                case "17":
                    for (int i = 0; i < canObjetios; i++)
                    {
                        System.Console.WriteLine(d[i]);
                    }
                    break;

                case "0":
                    System.Console.WriteLine("Bye!");
                    break;

                default:
                    System.Console.WriteLine("Wrong number!");
                    break;
            }
        } while (opcion != "0");

    }
}

