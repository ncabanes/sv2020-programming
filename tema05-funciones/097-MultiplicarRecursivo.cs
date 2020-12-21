//Gonzalo (...)
//Crea una función "MultiplicarR", que calcule y devuelva el producto de dos 
//números naturales que se indiquen como parámetros, de forma recursiva (por 
//ejemplo, puede tomar como caso base que el segundo número sea 0)

using System;

class Ejercicio96b
{
    static int MultiplicarR (int num1, int num2)
    {
        if (num2 == 0)
            return 0;
            
        return num1 + MultiplicarR (num1, num2-1);
    }
    
    static void Main()
    {
        int n1, n2;
        
        Console.Write("Dame el primer factor: ");
        n1 = Convert.ToInt32(Console.ReadLine());
        
        Console.Write("Dame el segundo factor: ");
        n2 = Convert.ToInt32 (Console.ReadLine());
        
        Console.WriteLine("El producto es: {0}", MultiplicarR(n1, n2));
    }
}
