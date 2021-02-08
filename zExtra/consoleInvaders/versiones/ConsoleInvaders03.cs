/*
Console Invaders, V03 (ej 6.3.5)

Amplía el esqueleto del ConsoleInvaders (ejercicio 6.3.4): El método Lanzar de 
la clase Bienvenida escribirá en pantalla "Bienvenido a Console Invaders. Pulse 
Intro para jugar o ESC para salir". Como veremos con detalle más adelante, 
puedes comprobar si se pulsa ESC con "ConsoleKeyInfo tecla = Console.ReadKey(); 
if (tecla.Key == ConsoleKey.Escape) salir = true;". El código de la tecla Intro 
es "ConsoleKey.Enter". También puedes usar "Console.Clear();" para borrar la 
pantalla. Añade un método "GetSalir" a la clase Bienvenida, que devuelva "true" 
si el usuario ha escogido Salir o "false" si ha elegido Jugar. El método Lanzar 
de la clase Juego repetirá la secuencia Bienvenida-Partida hasta que el usuario 
escoja Salir.

*/

using System;

class Juego
{
    public void Lanzar()
    {
        Bienvenida b = new Bienvenida();
        Partida p = new Partida();

        do
        {
            b.Lanzar();

            if (!b.GetSalir())
                p.Lanzar();
        }
        while (!b.GetSalir());
    }

    static void Main()
    {
        Juego j = new Juego();
        j.Lanzar();
    }
}

//-------------------------

class Bienvenida
{
    bool salir;
    public void Lanzar()
    {
        bool opcionEscogida = false;

        Console.WriteLine("Bienvenido a Console Invaders. "
            + "Pulse Intro para jugar o ESC para salir");

        do
        {
            ConsoleKeyInfo tecla = Console.ReadKey();

            if (tecla.Key == ConsoleKey.Escape)
            {
                salir = true;
                opcionEscogida = true;
            }
            else if (tecla.Key == ConsoleKey.Enter)
            {
                salir = false;
                Console.Clear();
                opcionEscogida = true;
            }
        }
        while ( ! opcionEscogida );
    }

    public bool GetSalir()
    {
        return salir;
    }
}

//-------------------------

class Partida
{
    public void Lanzar()
    {
        Console.WriteLine("Esta sería la pantalla de juego. "
            + "Pulse Intro para salir");
        Console.ReadLine();
    }
}
