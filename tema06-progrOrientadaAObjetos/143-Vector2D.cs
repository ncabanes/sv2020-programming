// Alejandro (...)

/*
143. Crea una clase Vector2D que represente un vector en el espacio
bidimensional (con coordenadas X e Y). Debe tener:

 - Un constructor para establecer los valores de X e Y.

 - Setters y getters para ambos, o propiedades, a tu criterio.

 - Un método "ToString", que devolvería algo como "<2, -3>"

 - Un método "GetLongitud" para devolver la longitud (módulo) del vector
    (raíz cuadrada de x2 + y2)

 - Un método "Sumar", para sumar un vector (que se pasará como parámetro) al 
    actual (el resultado será: <x + x, y + y>)

 - Crea un programa de prueba, que permita probar estas funcionalidades.
*/


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
}

// ------------------

class PruebaDeVectores
{
    static void Main()
    {
        Vector2D vector1 = new Vector2D(1, 5);
        Console.WriteLine(vector1.ToString());
        
        Vector2D vector2 = new Vector2D(4, -1);
        Console.WriteLine(vector2.ToString());
        
        vector1.sumar(vector2);
        Console.WriteLine(vector1.ToString());
    }
}
