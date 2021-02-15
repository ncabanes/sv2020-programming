
/* Eduardo (...)
 * 
 * Crea una nueva versión del ejercicio 141 (Medios), a partir de la 
 * "solución oficial", en la que la clase Medio sea abstracta, la clase 
 * Sonido sea sellada, y cambiando getters y setters convencionales por 
 * propiedades en formato compacto. Comprueba que no puedes crear objetos de 
 * la clase Medio ni heredar de la clase Sonido.s
 */

using System;

abstract class Medio
{
    public string Autor { get; set; }
    public int Tamanyo { get; set; }
    public string Formato { get; set; }

    public Medio(string autor, int tamanyo, string formato)
    {
        Autor = autor;
        Tamanyo = tamanyo;
        Formato = formato;
    }
    
    public override string ToString()
    {
        return "Autor: " + Autor + " Tamaño: " + Tamanyo + " Formato: " +
        Formato;
    }
}

class Imagen : Medio
{
    public int Ancho { get; set; }
    public int Alto { get; set; }

    public Imagen(string autor, int tamanyo, string formato, int ancho,
        int alto) : base(autor, tamanyo, formato)
    {
        Ancho = ancho;
        Alto = alto;
    }

    public override string ToString()
    {
        return base.ToString() + " Ancho: " + Ancho + " Alto: " + Alto;
    }
}

sealed class Sonido : Medio
{
    public bool Estereo { get; set; }
    public int Kbps { get; set; }
    public int Duracion { get; set; }

    public Sonido(string autor, int tamanyo, string formato, bool estereo,
        int kbps, int duracion) : base(autor, tamanyo, formato)
    {
        Estereo = estereo;
        Kbps = kbps;
        Duracion = duracion;
    }

    public override string ToString()
    {
        return base.ToString() + " Estereo: " + Estereo + " Kbps: " + Kbps +
        " Duración: " + Duracion;
    }
}

//Ahora la clase "Sonido" es SEALED asi que no podré crear clases heredadas...
/*class HeavyMetal : Sonido <-- ERROR DE COMPILACION!
{

}
*/

class Video : Medio
{

    public string Codec { get; set; }
    public int Ancho{ get; set; }
    public int Duracion { get; set; }
    public int Alto { get; set; }
    
    public Video(string autor, int tamanyo, string formato, string codec,
        int ancho, int alto, int duracion) : base(autor, tamanyo, formato)

    {
        Codec = codec;
        Ancho = ancho;
        Alto = alto;
        Duracion = duracion;
    }


    public override string ToString()
    {
        return base.ToString() + " Codec: " + Codec + " Ancho: " + Ancho +
        " Alto: " + Alto + " Duración: " + Duracion;
    }
}

class PruebaDeMedios
{
    public static void Main()
    {
        // Medio medio1 = new Medio("Iván", 150, "jpg"); ESTO YA NO SE PUEDE CREAR
        Imagen imagen1 = new Imagen("Iván I", 150, "png", 1500, 600);
        Sonido sonido1 = new Sonido("Iván S", 150, "mp3", false, 192, 750);
        Video video1 = new Video("Iván V", 150, "mp4", "H.264", 1600, 350, 650);

        Medio[] medios = new Medio[4];
        // medios[0] = new Medio("Iván", 150, "gif"); ESTO TAMPOCO SE PUEDE CREAR
        medios[1] = new Imagen("Iván I2", 150, "tif", 1500, 600);
        medios[2] = new Sonido("Iván S2", 150, "ogg", false, 192, 750);
        medios[3] = new Video("Iván V2", 150, "m4v", "H.264", 1600, 350, 650);

        Console.WriteLine(imagen1);
        // Console.WriteLine(medio1);
        Console.WriteLine(sonido1);
        Console.WriteLine(video1);
        Console.WriteLine();


        // OJO AQUI! ahora medios[0] no existe ya que no se podía crear un objeto
        // de esa clase al ser ACSTRACT... i = 1 y no i = 0
        for (int i = 1; i < 4; i++)
        {
            Console.WriteLine(medios[i].ToString());
        }
    }
}
