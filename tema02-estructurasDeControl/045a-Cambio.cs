/* Ej_45
   * Programa  que devuelva el cambio de una compra, utilizando
   * monedas (o billetes) lo más grande posible.
   * Por Jesús (...)
   */
   
using System;

class Ej_45
{
    static void Main()
    {
        int precio;
        int cantidad;  
        
        Console.Write("Introduzca el precio: ");
        precio = Convert.ToInt32(Console.ReadLine());
        Console.Write("Introduzca la cantidad pagada: ");
        cantidad = Convert.ToInt32(Console.ReadLine());
        
        int cambio = cantidad - precio;
        Console.WriteLine("Tu cambio es: " + cambio);
        
        int numBilletes100 = cambio/100;
        int nuevoCambioTrasDev100 = cambio % 100;
        Console.WriteLine("billetes de 100: {0} ", numBilletes100);
        
        int numBilletes50 = nuevoCambioTrasDev100/50;
        int nuevoCambioTrasDev50 = nuevoCambioTrasDev100 % 50;
        Console.WriteLine("billetes de 50: {0} ", numBilletes50);
        
        int numBilletes10 = nuevoCambioTrasDev50/10;
        int nuevoCambioTrasDev10 = nuevoCambioTrasDev50 % 10;
        Console.WriteLine("billetes de 10: {0} ", numBilletes10);
        
        int numBilletes5 = nuevoCambioTrasDev10/5;
        int nuevoCambioTrasDev5 = nuevoCambioTrasDev10 % 5;
        Console.WriteLine("billetes de 5: {0} ", numBilletes5);
        
        int numBilletes1 = nuevoCambioTrasDev5/1;
        int nuevoCambioTrasDev1 = nuevoCambioTrasDev5 % 1;
        Console.WriteLine("billetes de 1: {0}", numBilletes1);
    }
}
