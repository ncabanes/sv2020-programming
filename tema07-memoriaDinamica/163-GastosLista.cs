/*

Crea un programa en C# que pueda almacenar hasta 10000 gastos e ingresos, para 
crear un pequeño sistema de contabilidad doméstica. Para cada gasto (o 
ingreso), debe permitir guardar los siguientes datos:

- Fecha (8 caracteres: formato AAAAMMDD)

- Descripción del gasto o ingreso

- Categoría

- Importe (positivo si es un ingreso, negativo si es un gasto)

El programa debe permitir al usuario realizar las siguientes operaciones:

1- Añadir un nuevo gasto (la fecha debe "parecer correcta": día de 01 a 31, mes 
   de 01 a 12, año entre 1000 y 3000, y se volverá a pedir si no es así). La 
   descripción no debe estar vacía. No hace falta validar los demás datos.

2- Mostrar todos los gastos de una cierta categoría (por ejemplo, "estudios") 
   entre dos ciertas fechas (por ejemplo entre "20110101" y "20111231"). Se 
   mostrará número, fecha (en formato DD/MM/AAAA), descripción, categoría entre 
   paréntesis, e importe con dos decimales, todo ello en la misma línea, separado 
   por guiones. Al final de todos los datos se mostrará el importe total de los 
   datos mostrados.

3- Buscar gastos que contengan un cierto texto (en la descripción o en la 
   categoría, sin distinguir mayúsculas ni minúsculas). Se mostrará número, fecha 
   y descripción (la descripción se mostrará truncada en el sexto espacio en 
   blanco, en caso de existir seis espacios o más).

4- Modificar una ficha (pedirá el número de ficha al usuario; se mostrará el 
   valor anterior de cada campo y se podrá pulsar Intro para no modificar alguno 
   de los datos). Se debe avisar (pero no volver a pedir) si el usuario introduce 
   un número de ficha incorrecto. No hace falta validar ningún dato.

5- Borrar un cierto dato, a partir del número que indique el usuario. Se debe 
   avisar (pero no volver a pedir) si introduce un número incorrecto. Se debe 
   mostrar la ficha que se va a borrar y pedir confirmación antes de proceder al 
   borrado.

6- Ordenar los datos alfabéticamente, según fecha y (en caso de coincidir) 
   descripción.

7- Normalizar descripciones: eliminar espacios finales, espacios iniciales y 
   espacios duplicados. Si alguna descripción está totalmente en mayúsculas, se 
   convertirá a minúsculas (excepto la primera letra, que se conservará en 
   mayúsculas).

T- Terminar el uso de la aplicación (como no sabemos almacenar la información, 
   los datos se perderán)

*/

using System;
using System.Collections.Generic;

//Iván (...), retoques menores por Nacho

class Ejercicio_77
{
    struct contDomestica
    {
        public string fecha;
        public string descripcion;
        public string categoria;
        public double importe;
    }

    static void Main()
    {
        // const int MAX_INGRESOS = 10000;
        List<contDomestica> ingreso = new List<contDomestica>();
        bool salir = false;
        //int registros = 0;

        Console.WriteLine();
        Console.WriteLine("SISTEMA DE CONTABILIDAD DOMÉSTICA");

        do
        {
            Console.WriteLine();
            Console.WriteLine("1. Añadir un nuevo gasto");
            Console.WriteLine("2. Filtrar gastos");
            Console.WriteLine("3. Buscar gastos");
            Console.WriteLine("4. Modificar ficha");
            Console.WriteLine("5. Borrar dato");
            Console.WriteLine("6. Ordenador datos alfabéticamente");
            Console.WriteLine("7. Normalizar descripciones");
            Console.WriteLine("T. Terminar");
            Console.WriteLine();
            Console.WriteLine("Selección una opción: (pulse T para salir)");
            string opcion = Console.ReadLine().ToUpper();
            Console.WriteLine();

            salir = (opcion == "T");

            switch (opcion)
            {
                case "1":  // Añadir
                    contDomestica nuevoRegistro; //if (registros < MAX_INGRESOS)
                    {
                        string leerFecha;
                        bool fechaCorrecta = true;
                        do
                        {
                            Console.Write("Fecha (Formato --> AAAAMMDD): ");
                            leerFecha = Console.ReadLine();

                            int anyoNumero =
                                Convert.ToInt32(leerFecha.Substring(0, 4));
                            int mesNumero =
                                Convert.ToInt32(leerFecha.Substring(4, 2));
                            int diaNumero =
                                Convert.ToInt32(leerFecha.Substring(6, 2));

                            if (((anyoNumero < 1000) || (anyoNumero > 3000))
                                || ((mesNumero < 1) || (mesNumero > 12))
                                || ((diaNumero < 1) || (diaNumero > 31)))
                            {
                                fechaCorrecta = false;
                                Console.WriteLine("FORMATO DE FECHA ERRÓNEO");
                                Console.WriteLine();
                            }

                            nuevoRegistro.fecha = leerFecha;
                        }
                        while (!fechaCorrecta);

                        do
                        {
                            Console.Write("Descripción: ");
                            nuevoRegistro.descripcion = Console.ReadLine();

                            if (nuevoRegistro.descripcion == "")
                            {
                                Console.WriteLine("No puede estar vacía");
                                Console.WriteLine();
                            }
                        }
                        while (nuevoRegistro.descripcion == "");

                        Console.Write("Categoría: ");
                        nuevoRegistro.categoria = Console.ReadLine();

                        Console.Write("Ingreso: ");
                        nuevoRegistro.importe =
                            Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine(nuevoRegistro.importe);
                        ingreso.Add(nuevoRegistro); //registros++;
                    }
                    //else
                    //{
                    //    Console.WriteLine("No es posible añadir más registros");
                    //}
                    break;

                case "2":  // Mostrar una categoría
                    Console.WriteLine("Mostrar los datos");
                    Console.Write("Escriba la \"Categoría\" a buscar: ");
                    string buscarCategoria = Console.ReadLine();
                    Console.WriteLine("Escriba rango de fechas: ");
                    Console.Write("Desde: ");
                    int fechaDesde = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Hasta: ");
                    int fechaHasta = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    double totalIngresos = 0;

                    for (int i = 0; i < ingreso.Count; i++)
                    {
                        if ((ingreso[i].categoria == buscarCategoria)
                            && (Convert.ToInt32(ingreso[i].fecha) >= fechaDesde)
                            && (Convert.ToInt32(ingreso[i].fecha) <= fechaHasta))
                        {
                            string anyo = ingreso[i].fecha.Substring(0, 4);
                            string mes = ingreso[i].fecha.Substring(4, 2);
                            string dia = ingreso[i].fecha.Substring(6, 2);

                            Console.Write((i + 1) + " - "
                                + dia + "/" + mes + "/" + anyo
                                + " - " + ingreso[i].descripcion
                                + " (" + ingreso[i].categoria
                                + ") - " + ingreso[i].importe.ToString("N2"));
                            totalIngresos += ingreso[i].importe;
                            Console.WriteLine();
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine("TOTAL INGRESOS: {0}"
                        , totalIngresos.ToString("N2"));
                    totalIngresos = 0;
                    break;

                case "3":  // Buscar
                    Console.WriteLine("Buscar gastos");
                    Console.Write("Descripción o Categoría: ");
                    string buscarGastos = Console.ReadLine().ToUpper();
                    Console.WriteLine();

                    for (int i = 0; i < ingreso.Count; i++)
                    {
                        // Localizamos el sexto espacio, si existe
                        string descripcionMostrar = ingreso[i].descripcion;
                        int espaciosEncontrados = 0;
                        int pos = 0;
                        while (pos < descripcionMostrar.Length
                            && espaciosEncontrados < 6)
                        {
                            if (descripcionMostrar[pos] == ' ')
                                espaciosEncontrados++;
                            pos++;
                        }
                        if (espaciosEncontrados == 6)
                            descripcionMostrar = descripcionMostrar.Substring(
                                0, pos - 1);

                        // Y finalmente mostramos
                        if ((ingreso[i].descripcion.ToUpper().Contains(buscarGastos))
                            || (ingreso[i].categoria.ToUpper().Contains(buscarGastos)))
                        {
                            Console.Write("Nº " + (i + 1) + " - Fecha: "
                                + ingreso[i].fecha + " - Descripción: "
                                + descripcionMostrar);
                            Console.WriteLine();
                        }
                    }
                    break;

                case "4":  // Modificar
                    Console.WriteLine("Modificar ingreso");
                    Console.Write("Introduzca nº Ingreso: ");
                    int modRegistro = Convert.ToInt32(Console.ReadLine()) - 1;
                    Console.WriteLine();

                    if (modRegistro >= ingreso.Count)
                    {
                        Console.WriteLine("Registro no encontrado");
                    }
                    else
                    {
                        string respuesta; contDomestica registroModificar = ingreso[modRegistro];
                        Console.WriteLine("Fecha: {0}",
                            ingreso[modRegistro].fecha);
                        Console.Write("Fecha (Intro = NO modifica): ");
                        respuesta = Console.ReadLine();
                        if (respuesta != "")
                        {
                            registroModificar.fecha = respuesta;
                        }
                        Console.WriteLine();

                        Console.WriteLine("Descripción anterior: {0}",
                            ingreso[modRegistro].descripcion);
                        Console.Write("Descripción (Intro = NO modifica): ");
                        respuesta = Console.ReadLine();
                        if (respuesta != "")
                        {
                            registroModificar.descripcion = respuesta;
                        }
                        Console.WriteLine();

                        Console.WriteLine("Categoría anterior: {0}",
                            ingreso[modRegistro].categoria);
                        Console.Write("Categoría (Intro = NO modifica): ");
                        respuesta = Console.ReadLine();
                        if (respuesta != "")
                        {
                            registroModificar.categoria = respuesta;
                        }
                        Console.WriteLine();

                        Console.WriteLine("Importe anterior: {0}",
                            ingreso[modRegistro].importe.ToString("N2"));
                        Console.Write("Importe (Intro = NO modifica): ");
                        respuesta = Console.ReadLine();
                        if (respuesta != "")
                        {
                            registroModificar.importe =
                                Convert.ToDouble(respuesta);
                        }
                        Console.WriteLine(); ingreso[modRegistro] = registroModificar;
                    }
                    break;

                case "5":  // Borrar
                    Console.Write("Eliminar Nº Registro: ");
                    int posicBorrar = Convert.ToInt32(Console.ReadLine()) - 1;

                    if (posicBorrar >= ingreso.Count)
                    {
                        Console.WriteLine("Registro no encontrado");
                    }
                    else
                    {
                        Console.WriteLine("Desea borrar el Registro: \"{0}\"",
                            posicBorrar + 1);
                        Console.Write("Nº " + (posicBorrar + 1) + " - Fecha: "
                                + ingreso[posicBorrar].fecha
                                + " - Descripción: "
                                + ingreso[posicBorrar].descripcion
                                + " - Categoría: ("
                                + ingreso[posicBorrar].categoria
                                + ") - Importe: "
                                + ingreso[posicBorrar].importe.ToString("N2"));
                        Console.WriteLine();
                        Console.WriteLine("'S' = Confirmar / 'N' = Cancelar");
                        string confirmar = Console.ReadLine().ToUpper();

                        if (confirmar == "S")
                        {
                            //for (int i = posicBorrar; i < registros; i++)
                            //{
                            //    ingreso[i] = ingreso[i + 1];
                            //}
                            ingreso.RemoveAt(posicBorrar); //registros--;
                            Console.WriteLine("CONFIRMADO");
                            Console.WriteLine("Ha borrado el registro: {0}",
                                posicBorrar + 1);
                        }
                        else
                        {
                            Console.WriteLine("CANCELADO");
                        }
                    }
                    break;

                case "6": // Ordenar
                    for (int i = 0; i < ingreso.Count - 1; i++)
                    {
                        for (int j = i + 1; j < ingreso.Count; j++)
                        {
                            if ((ingreso[i].fecha.CompareTo(ingreso[j].fecha) > 0)
                                ||
                                ((ingreso[i].fecha == ingreso[j].fecha) &&
                                (String.Compare(ingreso[i].descripcion,
                                    ingreso[j].descripcion, true) > 0)))
                            {
                                contDomestica aux = ingreso[i];
                                ingreso[i] = ingreso[j];
                                ingreso[j] = aux;
                            }
                        }
                    }
                    Console.WriteLine("Datos ordenados");
                    break;

                case "7":  // Normalizar descripciones
                    Console.WriteLine("Vamos a proceder a normalizar las " +
                        "descripciones");
                    Console.WriteLine();

                    // Espacios iniciales y finales
                    for (int x = 0; x < ingreso.Count; x++)
                    {
                        contDomestica c = ingreso[x];  c.descripcion = c.descripcion.Trim(); ingreso[x]= c;
                    }

                    // Espacios intermedios redundantes
                    for (int x = 0; x < ingreso.Count; x++)
                    {
                        while (ingreso[x].descripcion.Contains("  "))
                        {
                            contDomestica c2 = ingreso[x]; c2.descripcion =
                                ingreso[x].descripcion.Replace("  ", " "); ingreso[x] = c2;
                        }
                    }

                    // Corregir mayúscuas
                    for (int x = 0; x < ingreso.Count; x++)
                    {
                        if (ingreso[x].descripcion ==
                            ingreso[x].descripcion.ToUpper())
                        {
                            contDomestica c3 = ingreso[x];c3.descripcion =
                                c3.descripcion.Substring(0, 1) +
                                c3.descripcion.Substring(1).ToLower(); ingreso[x] = c3;
                        }
                    }
                    Console.WriteLine("Descripciones normalizadas!");
                    break;

                case "T":
                    salir = true;
                    break;

                default:
                    Console.WriteLine("Opción no encontrada");
                    Console.WriteLine();
                    break;
            }
        }
        while (!salir);
        Console.WriteLine("¡Hasta otra!");
    }
}
