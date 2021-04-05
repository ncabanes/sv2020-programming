//Alejandro (...), retoques por Nacho
//1 DAM

using System;
using System.Collections.Generic;
using System.IO;

class CamposDBF
{
    static void Main()
    {
        string nombreDeArchivo = "CUSTOMER.DBF";
        FileStream fichero = File.OpenRead(nombreDeArchivo);
        
        // Lectura de la cabecera global
        int tamannoCabecera = 32;
        byte[] cabecera = new byte[tamannoCabecera];
        int cantidadLeida = fichero.Read(cabecera, 0, tamannoCabecera);
        if (cantidadLeida != tamannoCabecera)
            Console.WriteLine("No se ha podido leer la cabecera global");

        // Análisis de la cabecera global
        int numeroDeIdentificacion = cabecera[0];
        int anyoAct = cabecera[1];
        int mesAct = cabecera[2];
        int diaAct = cabecera[3];
        int numeroDeRegistros = cabecera[4] + cabecera[5] *256 +
            cabecera[6] *256*256 + cabecera[7]*256*256*256;
        int longitudDeCabecera = cabecera[8] + cabecera[9]*256;
        int longitudDeRegistro = cabecera[10] + cabecera[11] * 256;
        int cantidadDeCampos = (longitudDeCabecera - tamannoCabecera - 1) / 32;
        
        Console.WriteLine("Versión: " + numeroDeIdentificacion);
        Console.WriteLine("Fecha de actualización: " + diaAct.ToString("00") +
            "/" + mesAct.ToString("00") + "/" + (anyoAct+1900).ToString("0000"));
        Console.WriteLine("Registros: " + numeroDeRegistros);
        Console.WriteLine("Campos: " + cantidadDeCampos);

        // Lectura de las cabeceras de campos
        int tamannoNombreCampo = 11;
        
        for (int campo = 0; campo < cantidadDeCampos; campo++)
        {
            cantidadLeida = fichero.Read(cabecera, 0, tamannoCabecera);
            if (cantidadLeida != tamannoCabecera)
                Console.WriteLine("No se ha podido leer la cabecera del campo {0}",
                    campo+1);
            for (int letra = 0; letra < tamannoNombreCampo; letra++)
            {
                if (cabecera[letra] != 0)
                    Console.Write(Convert.ToChar(cabecera[letra]));
            }
            Console.WriteLine();
        }
        fichero.Close();
    }
}
