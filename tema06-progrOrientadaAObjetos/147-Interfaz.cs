// Carlos (...)

/*147. Crea una interfaz "Dibujable", con un método Dibujar, y una
interfaz "Medible", con un método GetArea. Crea una clase
RectanguloEnPantalla, con atributos x1, y1 (esquina superior
izquierda), x2, y2 (esquina inferior derecha) y que debe implementar
ambas interfaces.*/

using System;

interface IDibujable
{
    void Dibujar();
}

interface IMedible
{
    double GetArea(  );
}

class RectanguloEnPantalla: IDibujable, IMedible
{
    public int X1 { get; set; }
    public int Y1 { get; set; }
    public int X2 { get; set; }
    public int Y2 { get; set; }

    public RectanguloEnPantalla ( int X1, int Y1,
        int X2, int Y2 )
    {
        this.X1 = X1;
        this.Y1 = Y1;
        this.X2 = X2;
        this.Y2 = Y2;
    }

    public void Dibujar ()
    {
        for (int fila = Y1; fila <= Y2; fila++)
        {
            for (int columna = X1; columna <= X2; columna++)
            {
                Console.SetCursorPosition ( columna, fila );
                Console.Write("#");
            }
        }
    }

    public double GetArea ()
    {
        double area;
        int ancho = X2 - X1 + 1;
        int alto = Y2 - Y1 + 1;

        area = ancho * alto;
        return area;
    }
}

// --------------------

class PruebaDeRectangulo
{
    public static void Main()
    {
        RectanguloEnPantalla r1 = new RectanguloEnPantalla(2, 2, 6, 6);
        Console.WriteLine("El área del rectángulo es " + r1.GetArea() );
        r1.Dibujar();
    }
}
