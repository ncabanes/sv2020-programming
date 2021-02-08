/*
Console Invaders, V02 (ej 6.3.4)

Amplía el esqueleto del ConsoleInvaders (ejercicio 6.2.2): crea un proyecto 
para Visual Studio o SharpDevelop. Además de la clase "Juego", crea una clase 
"Bienvenida" y una clase "Partida". El método "Lanzar" de la clase Juego ya 
no escribirá nada en pantalla, sino que creará un objeto de la clase 
"Bienvenida" y lo lanzará y luego creará un objeto de la clase "Partida" y lo 
lanzará. El método Lanzar de la clase Bienvenida escribirá en pantalla 
"Bienvenido a Console Invaders. Pulse Intro para jugar". El método Lanzar de 
la clase Partida escribirá en pantalla "Ésta sería la pantalla de juego. Pulse 
Intro para salir" y se detendrá hasta que el usuario pulse Intro.

*/

using System;

class Juego
{
    public void Lanzar()
    {
        Bienvenida b = new Bienvenida();
        b.Lanzar();

        Partida p = new Partida();
        p.Lanzar();
        
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
    public void Lanzar()
    {
        Console.WriteLine("Bienvenido a Console Invaders. "
            + "Pulse Intro para jugar");
        Console.ReadLine();
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
