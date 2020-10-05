using System;
//ALBERTO (...)
//CONTAR DIA EN EL AÑO

class DiaEnElAnyo
{
    static void Main()
    {
        Console.WriteLine("INTRODUCE EL MES EN NUMERO");
        int mes = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("INTRODUCE EL DIA EN NÚMERO");
        int dia = Convert.ToInt32(Console.ReadLine());

        if (mes == 1)//ENERO
            Console.Write("Es el día número: {0}", dia);
        else if (mes == 2)//FEBRERO
            Console.Write("Es el día número: {0}", dia + 31);
        else if (mes == 3)//MARZO
            Console.Write("Es el día número: {0}", dia + 31 + 28);
        else if (mes == 4)//ABRIL
            Console.Write("Es el día número: {0}", dia + 31 + 28 + 31);
        else if (mes == 5)//MAYO
            Console.Write("Es el día número: {0}", dia + 31 + 28 + 31 + 30);
        else if (mes == 6)//JUNIO
            Console.Write("Es el día número: {0}",
                dia + 31 + 28 + 31 + 30 + 31);
        else if (mes == 7)//JULIO
            Console.Write("Es el día número: {0}",
                dia + 31 + 28 + 31 + 30 + 31 + 30);
        else if (mes == 8)//AGOSTO
            Console.Write("Es el día número: {0}",
                dia + 31 + 28 + 31 + 30 + 31 + 30 + 31);
        else if (mes == 9)//SEPTIEMBRE
            Console.Write("Es el día número: {0}",
                dia + 31 + 28 + 31 + 30 + 31 + 30 + 31 + 31);
        else if (mes == 10)//OCTUBRE
            Console.Write("Es el día número: {0}",
                dia + 31 + 28 + 31 + 30 + 31 + 30 + 31 + 31 + 30);
        else if (mes == 11)//NOVIEMBRE
            Console.Write("Es el día número: {0}",
                dia + 31 + 28 + 31 + 30 + 31 + 30 + 31 + 31 + 30 + 31);
        else if (mes == 12)//DICIEMBRE
            Console.Write("Es el día número: {0}",
                dia + 31 + 28 + 31 + 30 + 31 + 30 + 31 + 31 + 30 + 31 + 30);
    }

}

