using System;
using System.IO;

/*182. Crea un programa que sea capaz de encriptar y desencriptar una imagen 
 * en formato BMP, intercambiando el orden de sus dos primeros bytes de modo 
 * que los visores de imágenes no la detecten como una imagen válida.*/

//Iván (...)

class Ejercicio_182
{
    static byte[] CambiarCabecera(byte[] datos)
    {
        byte aux = datos[0];
        datos[0] = datos[1];
        datos[1] = aux;

        return datos;
    }

    static void Main()
    {
        try
        {
            byte[] datos = File.ReadAllBytes("imagen.bmp");

            if ((datos[0] == 'B') && (datos[1] == 'M'))
            {
                CambiarCabecera(datos);
                File.WriteAllBytes("imagen.bmp", datos);
                Console.WriteLine("Se ha encriptado el fichero!");
                return;
            }

            if ((datos[0] == 'M') && (datos[1] == 'B'))
            {
                CambiarCabecera(datos);
                File.WriteAllBytes("imagen.bmp", datos);
                Console.WriteLine("Se ha desencriptado el fichero!");
                return;
            }
            else
            {
                Console.WriteLine("No es un BMP");
            }   
        }
        catch (IOException e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
    }
}
