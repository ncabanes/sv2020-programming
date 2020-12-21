//Ezequiel (...)
//multiplica sumando las veces que diga el usuario

using System;

class opcional96
{
    static int Multiplicar(int num1, int num2)
    {
        int resultado = 0;

        for(int i = 0; i < num2; i++)
        {
            resultado += num1;
        }

        return resultado;
    }//fin funcion Multiplicar

    public static void Main (string[] args) 
    {
        Console.WriteLine("Dime el primer factor");
        int numero1 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Dime el segundo");
        int numero2 = Convert.ToInt32(Console.ReadLine());
        
        Console.WriteLine("Su producto es: {0}", Multiplicar(numero1, numero2) );
    }
}
