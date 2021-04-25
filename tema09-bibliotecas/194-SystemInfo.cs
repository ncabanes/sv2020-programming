//Alumno: Verónica (...)
/*194. Muestra información sobre el sistema: versión de Windows, versión de 
Punto Net, nombre de usuario actual, carpeta de documentos y espacio libre y 
espacio total en todas las particiones de disco (Busca información sobre 
"DriveInfo")*/

using System;
using System.Diagnostics;
using System.IO;

class Ejercicio_194
{
    static void Main(string[]args)
    {
        Console.WriteLine("Versión de Windows: " + Environment.OSVersion);
        Console.WriteLine("Versión de .Net: " + Environment.Version);
        Console.WriteLine("Usuario actual: " + Environment.UserName);
        Console.WriteLine("Carpeta de documentos: " + 
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
            
        DriveInfo[] discos = DriveInfo.GetDrives();
        foreach (DriveInfo disco in discos)
        {
            Console.WriteLine("Disco: " + disco.Name + ", Espacio libre: " + 
                 (((disco.AvailableFreeSpace/1024)/1024)/1024) + " GB de " +
                 (((disco.TotalSize/1024)/1024)/1024) + " GB.");
        }
    }
    
}
