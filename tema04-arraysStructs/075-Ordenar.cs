/*75. Crea un programa que pida al usuario 10 números enteros,
 * los guarde en un array llamados "datosOriginales", y luego:

- Los copie a un array "datos1", ordene este array mediante burbuja y
* muestre su contenido.

- Los copie a un array "datos2", ordene este array mediante selección
* directa y muestre su contenido.

- Los copie a un array "datos3", ordene este array mediante inserción
* directa y muestre su contenido. */

//Patrick (...)

using System;

class Ejer_75
{
    static void Main()
    {
        const int MAXIMO = 10;
        // int[] datosOriginales = new int[MAXIMO];
        int[] datosOriginales = {1, 9, 8, 7, 5, 6, 4, 3 , 2 ,10 };
        int[] datos1 = new int[MAXIMO];
        int[] datos2 = new int[MAXIMO];
        int[] datos3 = new int[MAXIMO];

        Console.WriteLine("Escriba {0} numeros enteros a ordenar",
         MAXIMO);

        for (int i = 0; i < MAXIMO; i++)
        {
            Console.WriteLine("Escriba el dato numero {0}", i+1);
            //datosOriginales[i] = Convert.ToInt32(Console.ReadLine());
            datos1[i] = datos2[i] = datos3[i] = datosOriginales[i];
        }

        //Burbuja
        for (int i = 0; i < MAXIMO-1; i++)
        {
            for (int j = i+1; j < MAXIMO; j++)
            {
                if (datos1[i] > datos1[j])
                {
                    int aux = datos1[i];
                    datos1[i] = datos1[j];
                    datos1[j] = aux;
                }
            }
        }

        foreach (int dato in datos1)
        {
            Console.Write(dato + " ");
        }
        Console.WriteLine();


        //Seleccion directa
        for (int i = 0; i < MAXIMO-1; i++)
        {
            int posicionMenor = i;
            for (int j = i+1; j < MAXIMO; j++)
            {
                if (datos2[j] < datos2[posicionMenor])
                {
                    posicionMenor = j;
                }
            }

            if (i != posicionMenor)
            {
                int aux = datos2[i];
                datos2[i] = datos2[posicionMenor];
                datos2[posicionMenor] = aux;
            }
        }

        foreach (int dato in datos2)
        {
            Console.Write(dato + " ");
        }
        Console.WriteLine();


        //Insercion directa
        for (int i = 1; i < MAXIMO; i++)
        {
            int j= i-1;
            while (j>=0 && datos3[j] > datos3[j+1])
            {
                int aux = datos3[j];
                datos3[j] = datos3[j+1];
                datos3[j+1] = aux;
                j--;
            }
        }

        foreach (int dato in datos3)
        {
            Console.Write(dato + " ");
        }
        Console.WriteLine();
    }
}
