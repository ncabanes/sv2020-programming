using System;
using System.Collections.Generic;

// Iván (...), retoques menores por Nacho

// Versión mejorada: dos criterios de ordenación

/*
165. Crea un programa de C# que pueda almacenar datos de ciudades. Para cada 
ciudad, debe permitir al usuario almacenar la siguiente información:

• Nombre (por ejemplo, Alicante)

• País (por ejemplo, España)

• Población (por ejemplo, 300.000)

El programa debe permitir al usuario realizar las siguientes operaciones:

1 - Añadir una nueva ciudad. El nombre y el país no pueden estar vacíos. Una 
población desconocida (introducida en blanco, pulsando Intro sin teclear nada) 
debe almacenarse como un 0.

2 - Mostrar todas las ciudades, cada ciudad en una línea (número de registro, 
nombre y país, como en "1- Alicante, España"). Si el nombre de la ciudad tiene 
más de 20 caracteres, debes mostrar los primeros 20 caracteres seguidos de 
"..." (como en "San Vicente del Rasp..."). Debes hacer una pausa después de 
cada 24 filas, que escriba "Pulse Intro para seguir". Si el usuario presiona 
Intro y no escribe ningún texto, se mostrarán los siguientes 24 datos, pero si 
teclea "fin" y luego presiona Intro, no se mostrarán más datos.

3 - Buscar ciudades que contengan un determinado texto en su nombre o en el 
nombre del país (búsqueda parcial, sin distinción de mayúsculas y minúsculas). 
Debe mostrar el número de ficha, el nombre, el país y la población, todo ello 
en la misma línea, haciendo una pausa después de cada 24 filas. Si no se había 
introducido la población, debe mostrar "Población desconocida" en lugar de 0.

4 - Modificar una ciudad: debe pedir al usuario su número de registro (contando 
desde 1), mostrar el valor anterior de cada campo y permitir que el usuario 
presione Intro si decide no modificar alguno de los datos. Se le debe volver a 
pedir si introduce un número de registro incorrecto, tantas veces como sea 
necesario (pero podrá escribir 0 como número de registro para indicar que 
quiere salir sin modificar nada). Antes de almacenar cada dato, se deben 
eliminar los espacios iniciales, los espacios finales y los espacios duplicados 
de cada campo.

5 - Insertar una ciudad, en la posición escogida por el usuario (contando desde 
1). Se le debe avisar (pero no volver a pedir) si introduce un número de 
registro incorrecto. Se debe validar los datos como en la opción 1.

6 - Eliminar una ciudad, en la posición introducida por el usuario (contando 
desde 1). Se le debe avisar (pero no volver a pedir) si introduce un número de 
registro incorrecto. El programa debe mostrar el registro que se eliminará y 
pedir confirmación antes de la eliminación. Además, debe avisar al usuario en 
caso de borrar el último dato que quedaba.

7 - Ordenar los datos. Se le preguntará al usuario si desea ordenar en función 
del nombre de la ciudad o del nombre del país, y el programa actuará en 
consecuencia.

8 - Buscar posibles errores ortográficos: mostrará los registros que contienen 
dos símbolos de puntuación consecutivos (.. o ,,) o una letra repetida tres 
veces (como Misssissippi).

S - Salir (como no almacenamos la información, se perderá).
*/

class Ejercicio_165
{
    struct DatosCiudad
    {
        public string nombre;
        public string pais;
        public int poblacion;
    }

    static void MostrarMenu()
    {
        Console.WriteLine("1. Añadir nueva ciudad.");
        Console.WriteLine("2. Mostrar todas las ciudades");
        Console.WriteLine("3. Buscar ciudad.");
        Console.WriteLine("4. Modificar una ciudad.");
        Console.WriteLine("5. Insertar ciudad.");
        Console.WriteLine("6. Eliminar ciudad.");
        Console.WriteLine("7. Ordenar.");
        Console.WriteLine("8. Buscar posible errores ortográficos.");
        Console.WriteLine("S. Salir.");
    }

    static void Anyadir(List<DatosCiudad> ciudades)
    {
        DatosCiudad c = PedirCiudad();
        ciudades.Add(c);
    }

    private static DatosCiudad PedirCiudad()
    {
        DatosCiudad c;
        do
        {
            Console.Write("Ciudad: ");
            c.nombre = Console.ReadLine();

            if (c.nombre == "")
            {
                Console.WriteLine("No puede estar vacía");
            }
        }
        while (c.nombre == "");

        do
        {
            Console.Write("País: ");
            c.pais = Console.ReadLine();

            if (c.pais == "")
            {
                Console.WriteLine("No puede estar vacío");
            }
        }
        while (c.pais == "");

        Console.Write("Población: ");
        string poblacionTemp = Console.ReadLine();
        if (poblacionTemp == "")
        {
            c.poblacion = 0;
        }
        else
        {
            c.poblacion = Convert.ToInt32(poblacionTemp);
        }

        return c;
    }

    static void MostrarTodos(List<DatosCiudad> ciudades)
    {
        if (ciudades.Count < 1)
        {
            Console.WriteLine("No hay datos.");
        }
        else
        {
            int i = 0;
            bool interrumpido = false;
            while (i < ciudades.Count && ! interrumpido)
            {
                if (ciudades[i].nombre.Length > 20)
                {
                    Console.WriteLine((i + 1) + " - "
                        + ciudades[i].nombre.Substring(0, 20) + "..., "
                        + ciudades[i].pais);
                }
                else
                {
                    Console.WriteLine((i + 1) + " - " + ciudades[i].nombre + ", "
                    + ciudades[i].pais);
                }
                i++;
                if (i % 24 == 23)
                {
                    Console.WriteLine("Pulse Intro para seguir");
                    string textosalir = Console.ReadLine();
                    if (textosalir == "fin")
                    {
                        interrumpido = true;
                        Console.Clear();
                    }
                }
            }
        }
    }

    static void Buscar(List<DatosCiudad> ciudades)
    {
        Console.WriteLine("Buscar ciudad");
        string textoBusuqueda = Console.ReadLine().ToUpper();
        Console.WriteLine();
        int filaActual = 0;
        for (int i = 0; i < ciudades.Count; i++)
        {
            if ((ciudades[i].nombre.ToUpper().Contains(textoBusuqueda))
                || (ciudades[i].pais.ToUpper().Contains(textoBusuqueda)))
            {
                if (ciudades[i].poblacion == 0)
                {
                    Console.WriteLine((i + 1) + " - " + ciudades[i].nombre + ", "
                     + ciudades[i].pais + " - Población desconocida");
                }
                else
                {
                    Console.WriteLine((i + 1) + " - " + ciudades[i].nombre + ", "
                        + ciudades[i].pais + " - Población: "
                        + ciudades[i].poblacion);
                }
                filaActual++;
            }

            if (filaActual == 24)
            {
                Console.WriteLine("Pulse Intro para seguir");
                Console.ReadLine();
                filaActual = 0;
            }
        }
    }

    static void Modificar(List<DatosCiudad> ciudades)
    {
        bool registroValido = false;
        bool salir = false;
        int numRegCiudad;
        do
        {
            Console.Write("Número de registro: ");
            numRegCiudad = Convert.ToInt32(Console.ReadLine());

            if ((numRegCiudad > ciudades.Count) || (numRegCiudad < 1))
            {
                Console.WriteLine("Número de registro de ciudad no encontrado.");
            }
            else if (numRegCiudad == 0)
            {
                salir = true;
                Console.Clear();
            }
            else
                registroValido = true;
        }
        while (!registroValido && !salir);

        if (!salir)
        {
            DatosCiudad c = ciudades[numRegCiudad - 1];
            string respuesta;

            Console.WriteLine("Ciudad: {0}", c.nombre);
            Console.Write("Nueva ciudad (Intro = NO modifica): ");
            respuesta = Console.ReadLine();
            if (respuesta != "")
            {
                c.nombre = respuesta;
            }

            Console.WriteLine("País: {0}", c.pais);
            Console.Write("Nuevo país (Intro = NO modifica): ");
            respuesta = Console.ReadLine();
            if (respuesta != "")
            {
                c.pais = respuesta;
            }

            Console.WriteLine("Población: {0}", c.poblacion);
            Console.Write("Nueva población (Intro = NO modifica): ");
            respuesta = Console.ReadLine();
            if (respuesta != "")
            {
                c.poblacion = Convert.ToInt32(respuesta);
            }

            //Eliminamos espacios iniciales, finales y duplicados
            c.nombre = NormalizarTexto(c.nombre);
            c.pais = NormalizarTexto(c.pais);

            ciudades[numRegCiudad - 1] = c;
        }
    }

    static string NormalizarTexto(string texto)
    {
        string textoTemporal = texto.Trim();
        while (textoTemporal.Contains("  "))
        {
            textoTemporal = textoTemporal.Replace("  ", " ");
        }
        return textoTemporal;
    }

    static void Insertar(List<DatosCiudad> ciudades)
    {
        Console.Write("Escoja una posición para insertar la ciudad:");
        int posicion = Convert.ToInt32(Console.ReadLine());
        if (posicion > ciudades.Count || posicion < 1)
        {
            Console.WriteLine("Posición no encontrada");
        }
        else
        {
            Console.WriteLine("Has escogido la posicion {0}", posicion);

            DatosCiudad c = PedirCiudad();
            ciudades.Insert(posicion - 1, c);
        }
    }

    static void Borrar(List<DatosCiudad> ciudades)
    {
        Console.Write("Registro a borrar: ");
        int ciudadBorrar = Convert.ToInt32(Console.ReadLine());

        if ((ciudadBorrar > ciudades.Count) || (ciudadBorrar < 1))
        {
            Console.WriteLine("Número de registro no válido.");
        }
        else
        {
            Console.WriteLine("Se va a borrar el registro:");
            Console.WriteLine((ciudadBorrar) + " - "
                + ciudades[ciudadBorrar - 1].nombre
                + ", " + ciudades[ciudadBorrar - 1].pais);
            if (ciudadBorrar - 1 == 0)
                Console.WriteLine("Va a proceder a borrar el último registro");
            Console.WriteLine("Pulse D para borrar - Otra tecla para cancelar");
            string respuesta = Console.ReadLine().ToUpper();
            if (respuesta == "D")
                ciudades.RemoveAt(ciudadBorrar - 1);
        }
    }

    static void Ordenar(List<DatosCiudad> ciudades)
    {
        //He buscado en google + ayuda de un campañero 
        //No sabía como usar "filtrar" IComparable en struct
        Console.WriteLine("Ordenar datos");
        Console.WriteLine("1.- Por Ciudad");
        Console.WriteLine("2.- Por País");
        int tipoOrden = Convert.ToInt32(Console.ReadLine());
        if (tipoOrden == 1)
        {
            ciudades.Sort((c, otro) => string.Compare(c.nombre, otro.nombre));
        }

        if (tipoOrden == 2)
        {
            ciudades.Sort((c, otro) => string.Compare(c.pais, otro.pais));
        }
    }

    static void RevisarErroresOrtograficos(List<DatosCiudad> ciudades)
    {
        Console.WriteLine("Lista de registros con errores ortográficos");
        for (int i = 0; i < ciudades.Count; i++)
        {
            if (ciudades[i].nombre.Contains("..")
                || ciudades[i].nombre.Contains(",,")
                || ciudades[i].pais.Contains("..")
                || ciudades[i].pais.Contains(",,"))
            {
                Console.WriteLine((i + 1) + " - " + ciudades[i].nombre + ", "
                    + ciudades[i].pais);
            }

            int cantidadLetras = ciudades[i].nombre.Length;
            bool repetido = false;
            for (int j = 0; j < cantidadLetras; j++)
            {
                string letra = ciudades[i].nombre.Substring(j, 1).ToLower();
                if (ciudades[i].nombre.ToLower().Contains(letra + letra + letra))
                    repetido = true;
            }
            if (repetido == true)
            {
                Console.WriteLine((i + 1) + " - " + ciudades[i].nombre + ", "
                        + ciudades[i].pais);
            }
        }
    }


    static void Main()
    {
        List<DatosCiudad> ciudades = new List<DatosCiudad>();
        bool terminar = false;

        do
        {
            MostrarMenu();
            Console.Write("Seleccione una opción: ");
            char menu = Convert.ToChar(Console.ReadLine().ToUpper());

            switch (menu)
            {
                case '1': Anyadir(ciudades); break;
                case '2': MostrarTodos(ciudades); break;
                case '3': Buscar(ciudades); break;
                case '4': Modificar(ciudades); break;
                case '5': Insertar(ciudades); break;
                case '6': Borrar(ciudades); break;
                case '7': Ordenar(ciudades); break;
                case '8': RevisarErroresOrtograficos(ciudades); break;
                case 'S': terminar = true; break;
                default: Console.WriteLine("Opción no válido."); break;
            }
            Console.WriteLine();
        }
        while (!terminar);

        Console.WriteLine("Hasta luego");
    }
}
