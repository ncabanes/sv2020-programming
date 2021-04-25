/*190. Crea un programa que muestre la hora actual en la esquina superior 
izquierda de la consola, en color cian, con fondo azul oscuro, actualizando 
cada segundo, mientras una "pelota" (una letra O) con fondo negro y color verde 
rebota en la pantalla. La pelota comenzará en unas coordenadas al azar de la 
pantalla. Debe detenerse cuando el usuario pulse Intro.*/

using System;
using System.Threading;

class PelotaYReloj
{
    static void Main()
    {
        Console.SetWindowSize(80,24);
        Console.SetBufferSize(80,24);
        
        Console.BackgroundColor = ConsoleColor.Blue;
        
        
        int x = 20;
        int y = 10;
        int velocX = 3;
        int velocY = 1;
        
        while(true)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(0,0);
            Console.WriteLine(DateTime.Now.Hour.ToString("00") + ":" +
                DateTime.Now.Minute.ToString("00") + ":" +
                DateTime.Now.Second.ToString("00"));
            
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(x, y);
            Console.Write("O");
            
            x += velocX;
            if (x < 5 || x > 74)
                velocX = -velocX;

            y += velocY;
            if (y < 2 || y > 22)
                velocY = -velocY;
            
            Console.SetCursorPosition(0, 0);
            Thread.Sleep(300);
            
            if(Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if(key.Key == ConsoleKey.S)
                    break;
            }
        }
    }
}
