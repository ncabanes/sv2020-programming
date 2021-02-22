//Patrick (...)

using System;

class PruebaPacMan
{
    Fantasma[] fantasmas;
    Nivel nivel;
    public PruebaPacMan()
    {
        fantasmas = new Fantasma[4];
        fantasmas[0] = new FantasmaRojo(15, 11);
        fantasmas[1] = new FantasmaNaranja(17, 12);
        fantasmas[2] = new FantasmaRosa(19, 13);
        fantasmas[3] = new FantasmaAzul(21, 14);
        nivel = new Nivel();
    }
    public static void Main()
    {
        PruebaPacMan pruebaPacMan = new PruebaPacMan();
        pruebaPacMan.Ejecutar();
    }
     
    public void Ejecutar()
    {
        //PruebaPacMan pruebaPacMan = new PruebaPacMan();
        bool salir = false;
        //Nivel nivel = new Nivel();
        Pac p = new Pac(13, 10);

        nivel.Mostrar();
        p.Mostrar();
        p.Mover();

        do
        {
            p.Mostrar();
            nivel.MostrarPuntuacion();

            for (int i = 0; i < fantasmas.Length; i++)
            {
                fantasmas[i].Mostrar();
            }

            ConsoleKeyInfo tecla = Console.ReadKey();
            p.Borrar();

            switch (tecla.Key)
            {
                case ConsoleKey.Escape:
                    salir = true;
                    break;
                case ConsoleKey.LeftArrow:
                    if (nivel.EsPosibleMover(p.X - 1, p.Y))
                    {
                        p.X--;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (nivel.EsPosibleMover(p.X + 1, p.Y))
                    {
                        p.X++;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (nivel.EsPosibleMover(p.X, p.Y - 1))
                    {
                        p.Y--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (nivel.EsPosibleMover(p.X, p.Y + 1))
                    {
                        p.Y++;
                    }
                    break;
                default:
                    break;
            }
            foreach (Fantasma f in fantasmas)
            {
                f.Mover();
            }

            foreach (Fantasma f in fantasmas)
                f.Mostrar();

            p.Mostrar();
            nivel.AumentarPuntuacion(nivel.ObtenerPuntosDe(p.X, p.Y));
        }
        while (!salir && !EsFinDePartida(fantasmas, p) && !nivel.FinPartida());
        Console.Clear();
        nivel.MostrarPuntuacion();
        if (nivel.FinPartida())
        {
            Console.WriteLine("Enhorabuena has ganado, los juglares cantaran tu gesta " +
                "y Nacho te aprobará este curso");
        }
        if (EsFinDePartida(fantasmas, p))
        {
            Console.WriteLine("Te has morido");
        }
    }
    
    public static bool EsFinDePartida(Fantasma[] fantasmas, Pac pac)
    {
        foreach (Fantasma f in fantasmas)
        {
            if (f.X == pac.X && f.Y == pac.Y)
            {
                return true;
            }
        }
        return false;
    }
}

// ---------------------------------

abstract class Sprite
{

    public int X { get; set; }
    public int Y { get; set; }

    public char caracter { get; set; }

    public virtual void Mover()
    {

    }

    public void Mostrar()
    {
        Console.SetCursorPosition(X, Y);
        Console.Write(caracter);
    }
    public void Borrar()
    {
        Console.SetCursorPosition(X, Y);
        Console.Write(" ");
    }
}

// ---------------------------------

class Pac : Sprite
{
    public Pac(int X, int Y)
    {
        this.X = X;
        this.Y = Y;
        caracter = 'C';
    }

    public override void Mover()
    {
    }
}

// ---------------------------------


class Fantasma : Sprite
{
    public Fantasma(int X, int Y)
    {
        this.X = X;
        this.Y = Y;
        caracter = 'A';
    }
}

// ---------------------------------

class FantasmaRojo : Fantasma
{
    Nivel nivel = new Nivel();
    public FantasmaRojo(int X, int Y) : base(X, Y)

    {
        this.X = X;
        this.Y = Y;
        caracter = 'A';
    }

    public FantasmaRojo() : this(20, 20)
    {
    }

    public override void Mover()
    {
        if (nivel.EsPosibleMover(X-1, Y))
        {
            Borrar();
            X--;
        }  
    }
}

// ---------------------------------

class FantasmaNaranja : Fantasma
{
    Nivel nivel = new Nivel();
    public FantasmaNaranja(int X, int Y) : base(X, Y)
    {
        this.X = X;
        this.Y = Y;
        caracter = 'A';
    }

    public FantasmaNaranja() : this(25, 25)
    {
    }

    public override void Mover()
    {
        if (nivel.EsPosibleMover(X+1, Y))
        {
            Borrar();
            X++;
        }
    }
}

// ---------------------------------

class FantasmaRosa : Fantasma
{
    Nivel nivel = new Nivel();
    public FantasmaRosa(int X, int Y) : base(X, Y)
    {
        this.X = X;
        this.Y = Y;
        caracter = 'A';
    }

    public FantasmaRosa() : this(30, 30)
    {
    }

    public override void Mover()
    {
        if (nivel.EsPosibleMover(X, Y-1))
        {
            Borrar();
            Y--;
        }
    }
}

// ---------------------------------

class FantasmaAzul : Fantasma
{
    Nivel nivel = new Nivel();
    public FantasmaAzul() : this(35, 35)
    {
    }

    public FantasmaAzul(int X, int Y) : base(X, Y)
    {
        this.X = X;
        this.Y = Y;
        caracter = 'A';
    }

    public override void Mover()
    {
        if (nivel.EsPosibleMover(X, Y+1))
        {
            Borrar();
            Y++;
        }
    }
}

// --------------------------------

class Nivel
{
    int marcador;
    int alturaNivel = 20;
    int anchuraNivel = 69;
    PildoraPequena pq1; 
    PildoraGrande pg1; 

    public Nivel()
    {
        marcador = 0;
        pq1 = new PildoraPequena(25, 4);
        pg1 = new PildoraGrande(17, 7);
    }

    public void AumentarPuntuacion(int cantidadPuntos)
    {
        marcador += cantidadPuntos; 
    }

    public void Mostrar()
    {
        for (int y = 1; y <= alturaNivel; y++)
        {
            for (int x = 1; x <= anchuraNivel; x++)
            {
                if (y == 1 || y == alturaNivel)
                {
                    Console.Write("-");
                }
                else if (x == 1 || x == anchuraNivel)
                {
                    Console.Write("|");
                }
                else
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
        }

        pq1.Mostrar();
        pg1.Mostrar();
    }

    public void MostrarPuntuacion()
    {
        Console.SetCursorPosition(52, 0);
        Console.WriteLine(marcador);
    }

    public bool EsPosibleMover(int x, int y)
    {
        if (x<anchuraNivel-1 && y<alturaNivel-1 && x>0 && y>0)
        {
            return true;
        }
        else
            return false;
    }

    public int ObtenerPuntosDe(int x, int y)
    {
        if (pg1.Activo && pg1.X == x && pg1.Y == y)
        {
            pg1.Activo = false;
            return pg1.Puntos;
        }
        else if (pq1.Activo && pq1.X == x && pq1.Y == y)
        {
            pq1.Activo = false;
            return pq1.Puntos;
        }
        return 0;
    }

    public bool FinPartida()
    {
        return !pq1.Activo && !pg1.Activo;  
    }
}

class PildoraPequena : Sprite
{
    public bool Activo { get; set; }
    public int Puntos { get; set; }
    public PildoraPequena(int x, int y)
    {
        X = x;
        Y = y;
        caracter = 'o';
        Puntos = 10;
        Activo = true;
    }
}

class PildoraGrande : Sprite
{
    public bool Activo { get; set; }
    public int Puntos { get; set; }
    public PildoraGrande(int x, int y)
    {
        X = x;
        Y = y;
        caracter = 'O';
        Puntos = 50;
        Activo = true;
    }
}
