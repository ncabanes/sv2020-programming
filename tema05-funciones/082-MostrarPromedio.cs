using System;
class ejercicio82
{
    /*82. Haz una función llamada "MostrarPromedio", que mostrará el 
    promedio de tres parámetros de tipo "double". Utilízala en un 
    programa que muestre el promedio de tres datos prefijados, que serán
    parte de un array.*/
    
    static void MostrarPromedio ( double numeroA, double numeroB, 
        double numeroC )
    {
        double promedio = (numeroA + numeroB + numeroC)/3;
        Console.WriteLine ( "El promedio es: " + promedio );     
    }
    
    static void Main()
    {
        MostrarPromedio ( 1.3, 2.2, 3.1 );
    }
}
