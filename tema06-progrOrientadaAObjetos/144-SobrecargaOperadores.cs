// Alejandro (...)

// 144. Crea una nueva versión de la clase Vector2D, sobrecargando el
// operador  "+", para sumar dos vectores pasados como parámetros

using System;

class Vector2D
{
    private double x, y;

    public Vector2D(double x, double y)
    {
        this.x = x;
        this.y = y;
    }

    public void SetX(double x) { this.x = x; }
    public void SetY(double y) { this.y = y; }
    public double GetX() { return x; }
    public double GetY() { return y; }

    public override string ToString()
    {
        return ("<" + x + "," + y + ">");
    }

    public double GetLongitud()
    {
        return Math.Sqrt(x * x + y * y);
    }

    public void sumar(Vector2D otro)
    {
        x += otro.x;
        y += otro.y;
    }
    
    public static Vector2D operator + (Vector2D v1, Vector2D v2)
    {
        Vector2D v3 = new Vector2D(v1.x + v2.x, v1.y + v2.y);

        return v3;
    }
}

// ------------------

class PruebaDeVectores
{
    static void Main()
    {
        Vector2D vector1 = new Vector2D(1, 5);
        Console.WriteLine(vector1);
        
        Vector2D vector2 = new Vector2D(4, -1);
        Console.WriteLine(vector2);
        
        Console.WriteLine(vector1 + vector2);
    }
}
