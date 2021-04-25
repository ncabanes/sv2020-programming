//Alumno: Verónica (...)
/*191. Crea un programa que muestre la lista de ficheros que hay en una cierta 
ruta que se indique en línea de comandos (o en la carpeta del ejecutable, si no 
se indica nada en línea de comandos). Para cada fichero, mostrará su nombre, 
extensión, tamaño en KB (destacando los millares, si es el caso) y fecha de 
modificación, así:

ejemplo.exe, 1.234 KB, 12-Mar-2021
ejemplo.dat, 67 KB, 13-Abr-2021*/

using System;
using System.IO;

class Ejercicio_191
{
    static void Main(string[]args)
    {
        string ruta;
        
        if (args.Length < 1)
        {
            Console.WriteLine("Al no indicar ruta, se tomará la ruta actual:");
            Console.WriteLine();
            ruta = "."; //directorio actual
        }
        else
        {
            ruta = args[0];
        }
        
        DirectoryInfo directorio = new DirectoryInfo(ruta);
        FileInfo[] infoFicheros = directorio.GetFiles();
        
        foreach (FileInfo fichero in infoFicheros)
        {
            Console.WriteLine(fichero.Name + ", " + 
                fichero.Length.ToString("N0")  + " KB, "+ 
                fichero.CreationTime.Day + "-" + 
                fichero.CreationTime.ToString("MMM").Substring(0,1).ToUpper() +
                fichero.CreationTime.ToString("MMM").Substring(1,2) + "-" +
                fichero.CreationTime.Year);
        }
    }
}
