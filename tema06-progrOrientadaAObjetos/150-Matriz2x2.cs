/*150. Crea una clase "Matriz2x2", que representará una matriz de números reales,
con 2 filas y 2 columnaas. Debe contener los siguientes métodos:

- Un constructor que reciba los dos valores de la primera fila y los dos de la
segunda: Matriz2x2(f1a, f1b, f2a, f2b)

- Un segundo constructor sin argumentos, que establezca todos los valores a 0

- Multiplicar ( n ), que multiplicará todos los elementos por un cierto valor.

- Sumar(m2) que sume elemento a elemento una segunda matriz.

- Debes sobrecargar el operador suma, para que también se puedan sumar "de
manera natural".

- ToString, que devolverá una cadena parecida a "  2   -7   \n  -3  4".

- Mostrar, que escribirá la matriz en pantalla.

- Deberá haber un getter con el formato Get(fila, columnaa) y un setter con el
formato Set(fila, columnaa, valor)

El programa de prueba debe crear pedir al usuario de dos matrices A y B,
multiplicar la segunda por dos, sumar A y B en un nueva matriz C y mostrar las
tres matrices en pantalla, separadas por sendas líneas en blanco.
*/

using System;

class Matriz2x2
{
    double[,] datos;

    public Matriz2x2(double f1a, double f1b, double f2a, double f2b)
    {
        datos = new double[2, 2];
        datos[0, 0] = f1a;
        datos[0, 1] = f1b;
        datos[1, 0] = f2a;
        datos[1, 1] = f2b;
    }

    public Matriz2x2() : this (0, 0, 0, 0)
    {
    }
    
    public double Get(int fila, int columna)
    {
        return datos[fila, columna];
    }

    public void Set(int fila, int columna, double val)
    {
        datos[fila, columna] = val;
    }

    public void Multiplicar(int n)
    {
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                datos[i, j] *= n;
            }
        }

    }

    public void Sumar(Matriz2x2 m2)
    {
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                datos[i, j] += m2.datos[i, j];
            }
        }

    }

    public static Matriz2x2 operator + (Matriz2x2 m1, Matriz2x2 m2)
    {
        return new Matriz2x2(
            m1.datos[0,0] + m2.datos[0,0],
            m1.datos[0,1] + m2.datos[0,1],
            m1.datos[1,0] + m2.datos[1,0],
            m1.datos[1,1] + m2.datos[1,1]);
    }

    public override string ToString()
    {
        return datos[0,0] + " " +
            datos[0,1] + "\n" +
            datos[1,0] + " " +
            datos[1,1] + "\n";
    }

    public void Mostrar()
    {
        Console.WriteLine(this);
    }

}

// ---------------------------------

class PruebaMatriz2x2
{
    static void Main()
    {
        Console.Write("Dime el dato 1,1: ");
        double a = Convert.ToDouble(Console.ReadLine());
        Console.Write("Dime el dato 1,2: ");
        double b = Convert.ToDouble(Console.ReadLine());
        Console.Write("Dime el dato 2,1: ");
        double c = Convert.ToDouble(Console.ReadLine());
        Console.Write("Dime el dato 2,2: ");
        double d = Convert.ToDouble(Console.ReadLine());
        Matriz2x2 A = new Matriz2x2(a, b, c, d);
        
        A.Mostrar();
        Console.WriteLine();

        Matriz2x2 B = new Matriz2x2();
        for (int fila = 1; fila < 3; fila++)
        {
            for (int col = 1; col < 3; col++)
            {
                Console.Write("Dime el dato {0},{1}: ", fila, col);
                double n = Convert.ToDouble(Console.ReadLine());
                B.Set(fila - 1, col - 1, n);
            }
        }
        
        B.Mostrar();
        Console.WriteLine();

        Console.WriteLine("Multiplicando por dos...");
        B.Multiplicar(2);
        B.Mostrar();
        Console.WriteLine();
        
        Console.WriteLine("Sumando...");
        Matriz2x2 C = A + B;
        Console.WriteLine(C);
    }
}

