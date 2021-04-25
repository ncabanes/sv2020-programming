// Segundo ejemplo de fuerza bruta: ataque de diccionario

using System;
using System.Diagnostics;
using System.IO;

class ReventarRar
{
    static void Main()
    {
        string[] palabras = File.ReadAllLines("words.txt");
        
        Process proc;
        
        for(int i = 0; i < palabras.Length; i++)
        {
            if(palabras[i].Length <= 5)  // Pista: palabra de 5 letras o menos
            {
                Console.Write(palabras[i] + " ");
                proc = Process.Start("rar.exe", "x -p" + palabras[i] +
                    " -y cb.rar");
                proc.WaitForExit();
                
                if(proc.ExitCode == 0)
                {
                    Console.WriteLine("Encontrado: " + palabras[i]);
                    break;
                }
            }
            
        }
    }
}
