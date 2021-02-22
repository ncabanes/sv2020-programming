using System;

/*158. Crea una nueva versión de PacMan (ejercicio 149), partiendo de la 
 * solución oficial, con los siguientes cambios:

- Debe existir una clase "Nivel", que represente un nivel del juego (con su 
laberinto y sus píldoras de 2 tamaños). Tendrá un método Mostrar(), que dibuje
el nivel en pantalla, así como un método bool EsPosibleMoverA(x, y), que 
permitirá saber si tanto Pac como los fantasmas pueden moverse a una cierta 
casilla o no, y como un método int ObtenerPuntosDe(x, y), que permitirá saber 
qué puntos se obtendrán en cierta posición del laberinto cuando Pac se 
desplace a ella (y eliminará la píldora correspondiente).

- No es necesario que el movimiento de los fantasmas recuerde al original, ni 
que gestiones los cambios de estado de los fantasmas, ni ningún otro detalle 
más avanzado.

- Pac sólo podrá moverse a posiciones factibles.

- Habrá un marcador que muestre los puntos obtenidos.

- La partida terminará si se recogen todas las píldoras o si algún fantasma 
alcanza a Pac.*/

//Iván (...)

/*Me he picado mucho con este ejercicio, seguramente
 * no sea la forma más adecuada de plantear un laberinto, pero me he divertido
 * bastante */

class PruebaPacMan
{
    static void Main()
    {
        bool salir = false;
        Nivel n = new Nivel();
        n.CrearLaberinto();
        n.Mostrar();
        n.MostrarMarcador();

        Pac p = new Pac(7, 5);
        p.Mostrar();
        p.Mover();
        Fantasma[] fantasmas = new Fantasma[4];
        fantasmas[0] = new FantasmaRojo(2, 1);
        fantasmas[1] = new FantasmaNaranja(10, 8);
        fantasmas[2] = new FantasmaRosa(11, 1);
        fantasmas[3] = new FantasmaAzul(13, 7);
        do
        {
            n.Mostrar();
            n.MostrarMarcador();
            p.Mostrar();

            for (int i = 0; i < fantasmas.Length; i++)
            {
                fantasmas[i].Mostrar();
            }

            ConsoleKeyInfo tecla = Console.ReadKey();

            switch (tecla.Key)
            {
                case ConsoleKey.Escape:
                    salir = true;
                    break;
                case ConsoleKey.LeftArrow:
                    if(n.EsPosibleMoverA(p.X-1, p.Y))
                        p.X--;
                    n.ObtenerPuntosDe(p.X, p.Y);
                     break;
                case ConsoleKey.RightArrow:
                    if (n.EsPosibleMoverA(p.X+1, p.Y))
                        p.X++;
                    n.ObtenerPuntosDe(p.X, p.Y);
                    break;
                case ConsoleKey.UpArrow:
                    if (n.EsPosibleMoverA(p.X, p.Y-1))
                        p.Y--;
                    n.ObtenerPuntosDe(p.X, p.Y);
                    break;
                case ConsoleKey.DownArrow:
                    if (n.EsPosibleMoverA(p.X, p.Y+1))
                        p.Y++;
                    n.ObtenerPuntosDe(p.X, p.Y);
                    break;
                default:
                    break;
            }

            for (int i = 0; i < fantasmas.Length; i++)
            {//Falta depurar movimiento de fantasmas
                if (n.EsPosibleMoverA(fantasmas[i].X, fantasmas[i].Y + 1))
                    fantasmas[i].MoverAbajo();
                else if (n.EsPosibleMoverA(fantasmas[i].X, fantasmas[i].Y - 1))
                    fantasmas[i].MoverArriba();
                else if (n.EsPosibleMoverA(fantasmas[i].X + 1, fantasmas[i].Y))
                    fantasmas[i].MoverIzquierda();
                else if (n.EsPosibleMoverA(fantasmas[i].X - 1, fantasmas[i].Y))
                    fantasmas[i].MoverDerecha();
            }
            Console.Clear();

            foreach (Fantasma f in fantasmas)
                f.Mostrar();

            n.Mostrar();
            p.Mostrar();

            for (int i = 0; i < fantasmas.Length; i++)
            {
                if (p.X == fantasmas[i].X && p.Y == fantasmas[i].Y)
                    salir = true;
            }

            if (salir)
                
                Console.WriteLine("TE HA COMIDO EL FANTASMA!");

        }
        while (!salir);
        Console.SetCursorPosition(5, 12);
        Console.WriteLine("FIN DE LA PARTIDA!");
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

    public virtual void MoverArriba()
    {

    }

    public virtual void MoverAbajo()
    {

    }

    public virtual void MoverIzquierda()
    {

    }

    public virtual void MoverDerecha()
    {

    }

    public void Mostrar()
    {
        Console.SetCursorPosition(X, Y);
        Console.Write(caracter);
        Console.SetCursorPosition(0, 0);
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
    //public Fantasma() { }
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
    public FantasmaRojo(int X, int Y) : base(X, Y)

    {
        this.X = X;
        this.Y = Y;
        caracter = 'A';
    }

    public FantasmaRojo() : this(20, 20)
    {
    }

    public override void MoverArriba()
    {
        Y--;
    }

    public override void MoverAbajo()
    {
        Y++;
    }

    public override void MoverIzquierda()
    {
        X--;
    }

    public override void MoverDerecha()
    {
        X++;
    }
}

// ---------------------------------

class FantasmaNaranja : Fantasma
{
    public FantasmaNaranja(int X, int Y) : base(X, Y)
    {
        this.X = X;
        this.Y = Y;
        caracter = 'A';
    }

    public FantasmaNaranja() : this(25, 25)
    {
    }

    public override void MoverArriba()
    {
        Y--;
    }

    public override void MoverAbajo()
    {
        Y++;
    }

    public override void MoverIzquierda()
    {
        X--;
    }

    public override void MoverDerecha()
    {
        X++;
    }
}

// ---------------------------------

class FantasmaRosa : Fantasma
{
    public FantasmaRosa(int X, int Y) : base(X, Y)
    {
        this.X = X;
        this.Y = Y;
        caracter = 'A';
    }

    public FantasmaRosa() : this(30, 30)
    {
    }

    public override void MoverArriba()
    {
        Y--;
    }

    public override void MoverAbajo()
    {
        Y++;
    }

    public override void MoverIzquierda()
    {
        X--;
    }

    public override void MoverDerecha()
    {
        X++;
    }
}

// ---------------------------------

class FantasmaAzul : Fantasma
{
    public FantasmaAzul() : this(35, 35)
    {
    }

    public FantasmaAzul(int X, int Y) : base(X, Y)
    {
        this.X = X;
        this.Y = Y;
        caracter = 'A';
    }

    public override void MoverArriba()
    {
        Y--;
    }

    public override void MoverAbajo()
    {
        Y++;
    }

    public override void MoverIzquierda()
    {
        X--;
    }

    public override void MoverDerecha()
    {
        X++;
    }
}

// --------------------------------

class Nivel
{
    private int x, y;
    private int puntuacion = 0;
    private int contadorPildoras = 62;
    private string imagen;

    Nivel[,] n = new Nivel[15,10];

    public Nivel(int x, int y, string imagen)
    {
        this.x = x;
        this.y = y;
        this.imagen = imagen;
    }

    public Nivel()
    {

    }

    public int GetX() { return x; }

    public int GetY() { return y; }

    public string GetImagen() { return imagen; }

    public void CrearLaberinto()
    {
        n[0, 0] = new Nivel(0, 0, "_");
        n[0, 1] = new Nivel(0, 1, "|");
        n[0, 2] = new Nivel(0, 2, "|");
        n[0, 3] = new Nivel(0, 3, "|");
        n[0, 4] = new Nivel(0, 4, "|");
        n[0, 5] = new Nivel(0, 5, "|");
        n[0, 6] = new Nivel(0, 6, "|");
        n[0, 7] = new Nivel(0, 7, "|");
        n[0, 8] = new Nivel(0, 8, "|");
        n[0, 9] = new Nivel(0, 9, "|");

        n[1, 0] = new Nivel(1, 0, "_");
        n[1, 1] = new Nivel(1, 1, "O");
        n[1, 2] = new Nivel(1, 2, ".");
        n[1, 3] = new Nivel(1, 3, ".");
        n[1, 4] = new Nivel(1, 4, ".");
        n[1, 5] = new Nivel(1, 5, ".");
        n[1, 6] = new Nivel(1, 6, ".");
        n[1, 7] = new Nivel(1, 7, ".");
        n[1, 8] = new Nivel(1, 8, "O");
        n[1, 9] = new Nivel(1, 9, "_");

        n[2, 0] = new Nivel(2, 0, "_");
        n[2, 1] = new Nivel(2, 1, ".");
        n[2, 2] = new Nivel(2, 2, "|");
        n[2, 3] = new Nivel(2, 3, "|");
        n[2, 4] = new Nivel(2, 4, "|");
        n[2, 5] = new Nivel(2, 5, "|");
        n[2, 6] = new Nivel(2, 6, "|");
        n[2, 7] = new Nivel(2, 7, "|");
        n[2, 8] = new Nivel(2, 8, ".");
        n[2, 9] = new Nivel(2, 9, "_");

        n[3, 0] = new Nivel(3, 0, "_");
        n[3, 1] = new Nivel(3, 1, ".");
        n[3, 2] = new Nivel(3, 2, ".");
        n[3, 3] = new Nivel(3, 3, ".");
        n[3, 4] = new Nivel(3, 4, ".");
        n[3, 5] = new Nivel(3, 5, "|");
        n[3, 6] = new Nivel(3, 6, ".");
        n[3, 7] = new Nivel(3, 7, ".");
        n[3, 8] = new Nivel(3, 8, ".");
        n[3, 9] = new Nivel(3, 9, "_");

        n[4, 0] = new Nivel(4, 0, "_");
        n[4, 1] = new Nivel(4, 1, "|");
        n[4, 2] = new Nivel(4, 2, "|");
        n[4, 3] = new Nivel(4, 3, "|");
        n[4, 4] = new Nivel(4, 4, ".");
        n[4, 5] = new Nivel(4, 5, "|");
        n[4, 6] = new Nivel(4, 6, ".");
        n[4, 7] = new Nivel(4, 7, ".");
        n[4, 8] = new Nivel(4, 8, ".");
        n[4, 9] = new Nivel(4, 9, "_");

        n[5, 0] = new Nivel(5, 0, "_");
        n[5, 1] = new Nivel(5, 1, "|");
        n[5, 2] = new Nivel(5, 2, ".");
        n[5, 3] = new Nivel(5, 3, ".");
        n[5, 4] = new Nivel(5, 4, ".");
        n[5, 5] = new Nivel(5, 5, ".");
        n[5, 6] = new Nivel(5, 6, ".");
        n[5, 7] = new Nivel(5, 7, ".");
        n[5, 8] = new Nivel(5, 8, "|");
        n[5, 9] = new Nivel(5, 9, "_");

        n[6, 0] = new Nivel(6, 0, "_");
        n[6, 1] = new Nivel(6, 1, "|");
        n[6, 2] = new Nivel(6, 2, ".");
        n[6, 3] = new Nivel(6, 3, ".");
        n[6, 4] = new Nivel(6, 4, "|");
        n[6, 5] = new Nivel(6, 5, "|");
        n[6, 6] = new Nivel(6, 6, "|");
        n[6, 7] = new Nivel(6, 7, ".");
        n[6, 8] = new Nivel(6, 8, "|");
        n[6, 9] = new Nivel(6, 9, "_");

        n[7, 0] = new Nivel(7, 0, "_");
        n[7, 1] = new Nivel(7, 1, "|");
        n[7, 2] = new Nivel(7, 2, "|");
        n[7, 3] = new Nivel(7, 3, ".");
        n[7, 4] = new Nivel(7, 4, "");
        n[7, 5] = new Nivel(7, 5, "");
        n[7, 6] = new Nivel(7, 6, "|");
        n[7, 7] = new Nivel(7, 7, ".");
        n[7, 8] = new Nivel(7, 8, "|");
        n[7, 9] = new Nivel(7, 9, "_");

        n[8, 0] = new Nivel(8, 0, "_");
        n[8, 1] = new Nivel(8, 1, "|");
        n[8, 2] = new Nivel(8, 2, ".");
        n[8, 3] = new Nivel(8, 3, ".");
        n[8, 4] = new Nivel(8, 4, "|");
        n[8, 5] = new Nivel(8, 5, "|");
        n[8, 6] = new Nivel(8, 6, "|");
        n[8, 7] = new Nivel(8, 7, ".");
        n[8, 8] = new Nivel(8, 8, "|");
        n[8, 9] = new Nivel(8, 9, "_");
          
        n[9, 0] = new Nivel(9, 0, "_");
        n[9, 1] = new Nivel(9, 1, "|");
        n[9, 2] = new Nivel(9, 2, ".");
        n[9, 3] = new Nivel(9, 3, ".");
        n[9, 4] = new Nivel(9, 4, ".");
        n[9, 5] = new Nivel(9, 5, ".");
        n[9, 6] = new Nivel(9, 6, ".");
        n[9, 7] = new Nivel(9, 7, ".");
        n[9, 8] = new Nivel(9, 8, ".");
        n[9, 9] = new Nivel(9, 9, "_");

        n[10, 0] = new Nivel(10, 0, "_");
        n[10, 1] = new Nivel(10, 1, "|");
        n[10, 2] = new Nivel(10, 2, "|");
        n[10, 3] = new Nivel(10, 3, "|");
        n[10, 4] = new Nivel(10, 4, ".");
        n[10, 5] = new Nivel(10, 5, "|");
        n[10, 6] = new Nivel(10, 6, ".");
        n[10, 7] = new Nivel(10, 7, "|");
        n[10, 8] = new Nivel(10, 8, ".");
        n[10, 9] = new Nivel(10, 9, "_");

        n[11, 0] = new Nivel(11, 0, "_");
        n[11, 1] = new Nivel(11, 1, ".");
        n[11, 2] = new Nivel(11, 2, ".");
        n[11, 3] = new Nivel(11, 3, ".");
        n[11, 4] = new Nivel(11, 4, ".");
        n[11, 5] = new Nivel(11, 5, "|");
        n[11, 6] = new Nivel(11, 6, ".");
        n[11, 7] = new Nivel(11, 7, ".");
        n[11, 8] = new Nivel(11, 8, ".");
        n[11, 9] = new Nivel(11, 9, "_");

        n[12, 0] = new Nivel(12, 0, "_");
        n[12, 1] = new Nivel(12, 1, ".");
        n[12, 2] = new Nivel(12, 2, "|");
        n[12, 3] = new Nivel(12, 3, "|");
        n[12, 4] = new Nivel(12, 4, "|");
        n[12, 5] = new Nivel(12, 5, "|");
        n[12, 6] = new Nivel(12, 6, "|");
        n[12, 7] = new Nivel(12, 7, "|");
        n[12, 8] = new Nivel(12, 8, ".");
        n[12, 9] = new Nivel(12, 9, "_");

        n[13, 0] = new Nivel(13, 0, "_");
        n[13, 1] = new Nivel(13, 1, "O");
        n[13, 2] = new Nivel(13, 2, ".");
        n[13, 3] = new Nivel(13, 3, ".");
        n[13, 4] = new Nivel(13, 4, ".");
        n[13, 5] = new Nivel(13, 5, ".");
        n[13, 6] = new Nivel(13, 6, ".");
        n[13, 7] = new Nivel(13, 7, ".");
        n[13, 8] = new Nivel(13, 8, "O");
        n[13, 9] = new Nivel(13, 9, "_");

        n[14, 0] = new Nivel(14, 0, "_");
        n[14, 1] = new Nivel(14, 1, "|");
        n[14, 2] = new Nivel(14, 2, "|");
        n[14, 3] = new Nivel(14, 3, "|");
        n[14, 4] = new Nivel(14, 4, "|");
        n[14, 5] = new Nivel(14, 5, "|");
        n[14, 6] = new Nivel(14, 6, "|");
        n[14, 7] = new Nivel(14, 7, "|");
        n[14, 8] = new Nivel(14, 8, "|");
        n[14, 9] = new Nivel(14, 9, "|");
    }

    public void Mostrar()
    {
        foreach (Nivel laberinto in n)
        {
            Console.SetCursorPosition(GetX(), GetY());
            Console.WriteLine(laberinto);
        }
    }

    public bool EsPosibleMoverA(int x, int y)
    {
        if (n[x, y].imagen != "|" && n[x, y].imagen != "_")
            return true;
        else
            return false;
    }
    
    public int ObtenerPuntosDe(int x, int y)
    {            
        if (n[x, y].imagen == ".")
        {
            n[x, y].imagen = "";
            contadorPildoras--;
            return puntuacion++;
        }    
        else if (n[x, y].imagen == "O")
        {
            n[x, y].imagen = "";
            contadorPildoras--;
            return puntuacion += 3;
        }
        else
            return puntuacion;
    }

    public void MostrarMarcador()
    {
        Console.SetCursorPosition(17, 3);
        Console.WriteLine("MARCADOR");
        Console.SetCursorPosition(17, 4);
        Console.WriteLine("Puntuación: " + puntuacion + " ( . = x1 / O = x3)");
        Console.SetCursorPosition(17, 5);
        Console.WriteLine("Píldoras restantes: " + contadorPildoras);
    }

    public override string ToString()
    {
        Console.SetCursorPosition(GetX(), GetY());
        return imagen;
    }

    public bool Finalizar()
    {
        if (contadorPildoras == 0)
            return true;
        else
            return false;
    }
}
