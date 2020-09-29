using System;

class Ejercicio8
{
    static void Main()
    {
        int num;

        Console.WriteLine("Dame un numero:");
        num = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("La tabla de multiplicar de {0} es:", num);
        Console.WriteLine("{0} x  0 = {1}", num, num * 0);
        Console.WriteLine("{0} x  1 = {1}", num, num * 1);
        Console.WriteLine("{0} x  2 = {1}", num, num * 2);
        Console.WriteLine("{0} x  3 = {1}", num, num * 3);
        Console.WriteLine("{0} x  4 = {1}", num, num * 4);
        Console.WriteLine("{0} x  5 = {1}", num, num * 5);
        Console.WriteLine("{0} x  6 = {1}", num, num * 6);
        Console.WriteLine("{0} x  7 = {1}", num, num * 7);
        Console.WriteLine("{0} x  8 = {1}", num, num * 8);
        Console.WriteLine("{0} x  9 = {1}", num, num * 9);
        Console.WriteLine("{0} x 10 = {1}", num, num * 10);

    }
}
