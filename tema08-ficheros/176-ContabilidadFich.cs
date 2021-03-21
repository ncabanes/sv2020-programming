//Jorge (...)
//1º Dam Semipresencial

/*Ejericio 176
 * Crea una nueva versión de la contabilidad doméstica con listas (ej. 163b),
 * partiendo de la versión oficial, que guarde datos en fichero y cargue
 * datos de fichero.
 * 
 */

using System;
using System.Collections.Generic;
using System.IO;

//Iván (...), retoques por Nacho

class Ejercicio176
{
    struct tipoGasto
    {
        public string fecha;
        public string descripcion;
        public string categoria;
        public double importe;
    }

   
    static void Main()
    {
        List<tipoGasto> gastos = new List<tipoGasto>();
        bool salir = false;

        gastos = cargarBD();

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
                    tipoGasto nuevoRegistro;

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
                    gastos.Add(nuevoRegistro);
                    salvarDato(nuevoRegistro);
                    break;

                case "2":  // Mostrar una categoría
                    Console.WriteLine("Mostrar los datos");
                    Console.Write("Escriba la \"Categoría\" a buscar: ");
                    string categoriaBuscar = Console.ReadLine();
                    Console.WriteLine("Escriba rango de fechas: ");
                    Console.Write("Desde: ");
                    int fechaDesde = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Hasta: ");
                    int fechaHasta = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    double totalIngresos = 0;

                    for (int i = 0; i < gastos.Count; i++)
                    {
                        if ((gastos[i].categoria == categoriaBuscar)
                            && (Convert.ToInt32(gastos[i].fecha) >= fechaDesde)
                            && (Convert.ToInt32(gastos[i].fecha) <= fechaHasta))
                        {
                            string anyo = gastos[i].fecha.Substring(0, 4);
                            string mes = gastos[i].fecha.Substring(4, 2);
                            string dia = gastos[i].fecha.Substring(6, 2);

                            Console.Write((i + 1) + " - "
                                + dia + "/" + mes + "/" + anyo
                                + " - " + gastos[i].descripcion
                                + " (" + gastos[i].categoria
                                + ") - " + gastos[i].importe.ToString("N2"));
                            totalIngresos += gastos[i].importe;
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

                    for (int i = 0; i < gastos.Count; i++)
                    {
                        // Localizamos el sexto espacio, si existe
                        string descripcionMostrar = gastos[i].descripcion;
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
                        if ((gastos[i].descripcion.ToUpper().Contains(buscarGastos))
                            || (gastos[i].categoria.ToUpper().Contains(buscarGastos)))
                        {
                            Console.Write("Nº " + (i + 1) + " - Fecha: "
                                + gastos[i].fecha + " - Descripción: "
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

                    if (modRegistro >= gastos.Count)
                    {
                        Console.WriteLine("Registro no encontrado");
                    }
                    else
                    {
                        string respuesta;
                        tipoGasto registroModificar = gastos[modRegistro];
                        Console.WriteLine("Fecha: {0}",
                            gastos[modRegistro].fecha);
                        Console.Write("Fecha (Intro = NO modifica): ");
                        respuesta = Console.ReadLine();
                        if (respuesta != "")
                        {
                            registroModificar.fecha = respuesta;
                        }
                        Console.WriteLine();

                        Console.WriteLine("Descripción anterior: {0}",
                            gastos[modRegistro].descripcion);
                        Console.Write("Descripción (Intro = NO modifica): ");
                        respuesta = Console.ReadLine();
                        if (respuesta != "")
                        {
                            registroModificar.descripcion = respuesta;
                        }
                        Console.WriteLine();

                        Console.WriteLine("Categoría anterior: {0}",
                            gastos[modRegistro].categoria);
                        Console.Write("Categoría (Intro = NO modifica): ");
                        respuesta = Console.ReadLine();
                        if (respuesta != "")
                        {
                            registroModificar.categoria = respuesta;
                        }
                        Console.WriteLine();

                        Console.WriteLine("Importe anterior: {0}",
                            gastos[modRegistro].importe.ToString("N2"));
                        Console.Write("Importe (Intro = NO modifica): ");
                        respuesta = Console.ReadLine();
                        if (respuesta != "")
                        {
                            registroModificar.importe =
                                Convert.ToDouble(respuesta);
                        }
                        Console.WriteLine(); gastos[modRegistro] = registroModificar;
                    }
                    guardarTodosLosDatos(gastos);

                    break;

                case "5":  // Borrar
                    Console.Write("Eliminar Nº Registro: ");
                    int posicBorrar = Convert.ToInt32(Console.ReadLine()) - 1;

                    if (posicBorrar >= gastos.Count)
                    {
                        Console.WriteLine("Registro no encontrado");
                    }
                    else
                    {
                        Console.WriteLine("Desea borrar el Registro: \"{0}\"",
                            posicBorrar + 1);
                        Console.Write("Nº " + (posicBorrar + 1)
                                + " - Fecha: " + gastos[posicBorrar].fecha
                                + " - Descripción: " + gastos[posicBorrar].descripcion
                                + " - Categoría: (" + gastos[posicBorrar].categoria
                                + ") - Importe: "
                                + gastos[posicBorrar].importe.ToString("N2"));
                        Console.WriteLine();
                        Console.WriteLine("'S' = Confirmar / 'N' = Cancelar");
                        string confirmar = Console.ReadLine().ToUpper();

                        if (confirmar == "S")
                        {
                            gastos.RemoveAt(posicBorrar);
                            Console.WriteLine("CONFIRMADO");
                            Console.WriteLine("Ha borrado el registro: {0}",
                                posicBorrar + 1);
                        }
                        else
                        {
                            Console.WriteLine("CANCELADO");
                        }
                    }
                    guardarTodosLosDatos(gastos);

                    break;

                case "6": // Ordenar
                    for (int i = 0; i < gastos.Count - 1; i++)
                    {
                        for (int j = i + 1; j < gastos.Count; j++)
                        {
                            if ((gastos[i].fecha.CompareTo(gastos[j].fecha) > 0)
                                ||
                                ((gastos[i].fecha == gastos[j].fecha) &&
                                (String.Compare(gastos[i].descripcion,
                                    gastos[j].descripcion, true) > 0)))
                            {
                                tipoGasto aux = gastos[i];
                                gastos[i] = gastos[j];
                                gastos[j] = aux;
                            }
                        }
                    }
                    Console.WriteLine("Datos ordenados");
                    guardarTodosLosDatos(gastos);

                    break;

                case "7":  // Normalizar descripciones
                    Console.WriteLine("Vamos a proceder a normalizar las " +
                        "descripciones");
                    Console.WriteLine();


                    for (int x = 0; x < gastos.Count; x++)
                    {
                        tipoGasto c = gastos[x];

                        // Espacios iniciales y finales
                        c.descripcion = c.descripcion.Trim();

                        // Espacios intermedios redundantes
                        while (c.descripcion.Contains("  "))
                        {
                            c.descripcion = c.descripcion.Replace("  ", " ");
                        }

                        // Corregir mayúscuas
                        if (c.descripcion == c.descripcion.ToUpper())
                        {
                            c.descripcion =
                                    c.descripcion.Substring(0, 1) +
                                    c.descripcion.Substring(1).ToLower();
                        }

                        // Y volcamos los cambios
                        gastos[x] = c;
                    }

                    Console.WriteLine("Descripciones normalizadas!");
                    guardarTodosLosDatos(gastos);

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


    //Metodo para salvar el ultimo dato evitando grabar todos los registros.
    private static void salvarDato(tipoGasto gasto)
    {
        StreamWriter ficheroWrite;
        
        string nombreArchivo = "contabilidadBD.txt";
        string linea;

        try
        {
            linea = gasto.fecha + "|" + gasto.descripcion + "|" + 
                gasto.categoria + "|" + gasto.importe.ToString();
            ficheroWrite = File.AppendText(nombreArchivo);
            ficheroWrite.WriteLine(linea);
            ficheroWrite.Close();
        }
        catch (PathTooLongException)
        {
            Console.WriteLine("Nombre de fichero destino demasiado largo!");
        }
        catch (IOException e)
        {
            Console.WriteLine("No se ha podido escribir el archivo");
            Console.WriteLine("Motivo: {0}", e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error al guardar el archivo");
            Console.WriteLine("Motivo: {0}", e.Message);
        }
    }
    
    private static void guardarTodosLosDatos(List<tipoGasto> gastos)
    {
        List<string> listaAux = new List<string>();
        string nombreArchivo = "contabilidadBD.txt";
        string linea;
        if (gastos.Count > 0)
        {
            try
            {
                StreamWriter ficheroWrite = File.AppendText(nombreArchivo);
                foreach (tipoGasto gasto in gastos)
                {
                    linea = gasto.fecha + "|" + gasto.descripcion + "|" + 
                        gasto.categoria + "|" + gasto.importe.ToString();
                    ficheroWrite.WriteLine(linea);
                }
                ficheroWrite.Close();
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("Nombre de fichero de destino demasiado largo!");
            }
            catch (IOException e)
            {
                Console.WriteLine("No se ha podido escribir el archivo");
                Console.WriteLine("Motivo: {0}", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al guardar el archivo");
                Console.WriteLine("Motivo: {0}", e.Message);
            }
        }
        else
            AvisoSinProgramas();
    }

    private static void AvisoSinProgramas()
    {
        Console.WriteLine("No hay programas");
    }

    private static List<tipoGasto> cargarBD()
    {
        StreamReader ficheroRead;
        string nombreArchivo = "contabilidadBD.txt";
        List<tipoGasto> gastos = new List<tipoGasto>();
        
        if (! File.Exists(nombreArchivo))
            return gastos;
        
        string linea;
        tipoGasto gasto;

        try
        {
            ficheroRead = File.OpenText(nombreArchivo);
            linea = ficheroRead.ReadLine();
            while(linea!=null)
            {
                string[] gastosAux = linea.Split('|');
                gasto.fecha = gastosAux[0];
                gasto.descripcion = gastosAux[1];
                gasto.categoria = gastosAux[2];
                gasto.importe = Convert.ToDouble(gastosAux[3]);
                gastos.Add(gasto);
                linea = ficheroRead.ReadLine();

            }

            ficheroRead.Close();
        }
        catch(PathTooLongException)
        {
            Console.WriteLine("Nombre de fichero de origen demasiado largo!");
        }
        catch(IOException e)
        {
            Console.WriteLine("No se ha podido leer el archivo");
            Console.WriteLine("Motivo: {0}", e.Message);
        }
        catch (Exception e)
            {
                Console.WriteLine("Error al leer el archivo");
                Console.WriteLine("Motivo: {0}", e.Message);
            }
        return gastos;

    }
}
