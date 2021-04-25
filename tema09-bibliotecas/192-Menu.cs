using System;
using System.Collections.Generic;
using System.Diagnostics;

/*192. Crea un menú que permita al usuario 8 aplicaciones prefijadas,
 * pulsando las teclas del 1 al 8.*/

//Iván (...), un par de retoques por Nacho

class Ejercicio_192
{

    static void Main()
    {
        SortedList<string, string> datos =
            new SortedList<string, string>();
        datos.Add("Paint", "mspaint.exe");
        datos.Add("Bloc de notas", "notepad.exe");
        datos.Add("Calculadora", "mspaint.exe");
        datos.Add("Panel de control", "mspaint.exe");
        datos.Add("Explorador de windows", "mspaint.exe");
        datos.Add("Navegador Chrome", "chrome.exe");
        datos.Add("Total Commander", 
            "d:\\utils\\totalcmd\\TOTALCMD64.EXE");
        datos.Add("Python shell", "python.exe");

        bool salir = false;

        do
        {
            Console.Clear();
            for (int i = 0; i < datos.Count; i++)
            {
                Console.WriteLine((i+1) + ". " +
                    datos.Keys[i]);
            }
            Console.WriteLine("0. Salir");

            char opcion = Console.ReadKey(true).KeyChar;

            if (opcion >= '1' && opcion <= '8')
            {
                try
                {
                    int numeroOpcion = opcion - '1';
                    string nombre = datos[ datos.Keys[numeroOpcion] ];
                    Process proc = Process.Start(nombre);
                    proc.WaitForExit();
                }
                catch (Exception)
                {
                    Console.WriteLine("No se ha podido lanzar ese programa");
                    Console.WriteLine("Pulse Intro para continuar...");
                    Console.ReadLine();
                }
            }

            if (opcion == '0') salir = true;

        } while (!salir);
        Console.Clear();
        Console.WriteLine("Hasta luego");
    }
}
