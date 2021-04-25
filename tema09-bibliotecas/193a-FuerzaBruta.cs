using System;
using System.Diagnostics;

/*193. Intenta romper la contraseña de un archivo comprimido, lanzando un 
 * descompresor y verificando si el valor devuelto es 0. Tendrás un fichero 
 * compartido llamado "c.7z" en Aules y en GitHub, cuya contraseña es un 
 * número de 4 cifras (entre 0000 y 9999), y también tendrás el (des)compresor
 * de línea de comandos 7za.exe (la orden para descomprimir probando una
 * contraseña 1234 es "7za x c.7z -p1234").*/

//Iván (...)

class Ejercicio_193
{
   static void Main()
   {
        int clave = 0;
        bool salir = false;
        string programa = "7za.exe";
        string parametros;
       
        while (!salir)
        {
            parametros = "x c.7z -p" + clave.ToString("0000") + " -y";

            Process unZip = new Process();
            unZip.StartInfo.FileName = programa;
            unZip.StartInfo.Arguments = parametros;
            unZip.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            unZip.Start();
            unZip.WaitForExit();

            if (unZip.ExitCode == 0)
                salir = true;
            else
                clave++;

            Console.SetCursorPosition(0,0);
            Console.WriteLine("Probando: " + clave.ToString("0000"));
        }
        Console.WriteLine("Contraseña encontrada --> " + clave);
   }
}
