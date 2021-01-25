/* 
Ej.126.

De cara a irnos acercando a una versión orientada a objetos del proyecto de la 
colección de programas (ejercicio 102), crea una clase Programa, con atributos: 
nombre (string), descripcion (string), mesLanzamiento (byte), anyoLanzamiento 
(entero corto sin signo). Debes preparar setters y getters para todos ellos, 
pero los getters numéricos devolverán datos "int", y los setters numéricos 
recibirán datos "int". Crea también un constructor adecuado, un método Mostrar 
(void) que muestre los datos de un Programa en pantalla, y un método Contiene 
(booleano) que devuelva "true" si el nombre o la descripción contienen el texto 
que se indique como parámetro.

Hugo (...), retoques por Nacho

NOTA DEL DESARROLLADOR: aunque no se pida en el ejercicio se crea un Main
de prueba para probar los métodos de la clase "Programa"

*/

using System;

class Programa
{
    protected string nombre;
    protected string descripcion;
    protected byte mesLanzamiento;
    protected ushort anyoLanzamiento;

    public Programa(string nuevoNombre, string nuevaDescripcion,
        int nuevoMes, int nuevoAnyo)
    {
        nombre = nuevoNombre;
        descripcion = nuevaDescripcion;
        mesLanzamiento = (byte) nuevoMes;
        anyoLanzamiento = (ushort) nuevoAnyo;
    }


    public string GetNombre()
    {
        return nombre;
    }

    public string GetDescripcion()
    {
        return descripcion;
    }

    public int GetMesLanzamiento()
    {
        return mesLanzamiento;
    }

    public int GetanyoLanzamiento()
    {
        return anyoLanzamiento;
    }

    public void SetNombre(string nuevoNombre)
    {
        nombre = nuevoNombre;
    }

    public void SetDescripcion(string nuevaDescripcion)
    {
        descripcion = nuevaDescripcion;
    }

    public void SetMesLanzamiento(int nuevoMes)
    {
        mesLanzamiento = (byte)nuevoMes;
    }

    public void SetAnyoLanzamiento(int nuevoAnyo)
    {
        anyoLanzamiento = (ushort)nuevoAnyo;
    }


    public bool Contiene(string textoABuscar)
    {
        bool encontrado = false;

        if (nombre.ToUpper().Contains(textoABuscar.ToUpper()) || 
            (descripcion.ToUpper().Contains(textoABuscar.ToUpper())))
        {
            encontrado = true;
        }
        return encontrado;
    }


    public void Mostrar()
    {
        Console.WriteLine("Nombre: " + nombre);
        Console.WriteLine("Descripción: " + descripcion);
        Console.WriteLine("Mes Lanzamiento: " + mesLanzamiento);
        Console.WriteLine("Año lanzamiento: " + anyoLanzamiento);
    }
}

class PruebaPrograma
{
    static void Main()
    {
        Programa p = new Programa("Uno", "Ejemplo", 1, 2021);
        p.Mostrar();
        Console.WriteLine();
        
        p.SetDescripcion("Nueva descripción");
        p.Mostrar();
        Console.WriteLine();
        
        Console.WriteLine("Contiene \"nueva\"? " + p.Contiene("nueva"));
    }
}
