// Ivan (...)

/*
141. Crea una clase "Medio", que permita guardar información sobre un archivo 
multimedia genérico. Tendrá como atributos: autor, tamaño (en KB), formato (por 
ejemplo, MPEG4). También debes crear los "setters" y los "getters" 
(convencionales) para leer o cambiar estos atributos. Crea también un (único) 
constructor, para asignar un valor a los tres atributos cuando se crea un 
objeto.

Crea una clase "Imagen", que herede de "Medio" y añada los atributos "ancho" 
(por ejemplo, 1600) y "alto", con su correspondiente Set y Get, así como un 
(único) constructor específico.

Crea una clase "Sonido", también basada en "Medio", con los atributos "estereo" 
(booleano), "kbps" (por ejemplo, 192) y "duración" (en segundos), sus setters y 
getters y un constructor.

Crea una clase "Video", también heredando de "Medio", que ampliará con los 
atributos "códec" (por ejemplo, H.264), "ancho" (por ejemplo, 1600), "alto" y 
"duracion" (en segundos), sus setters y getters y un constructor adecuado.

Finalmente, crea una clase "PruebaDeMedios". con un programa de prueba que cree 
al menos un elemento de cada uno de los tipos anteriores, así como un array con 
al menos dos elementos de diferentes tipos y luego muestra sus datos en la 
pantalla.
*/

using System;

class Medio
{
    protected string autor;
    protected int tamanyo;
    protected string formato;

    public Medio(string autor, int tamanyo, string formato)
    {
        this.autor = autor;
        this.tamanyo = tamanyo;
        this.formato = formato;
    }

    public string GetAutor() { return autor; }
    public int GetTamanyo() { return tamanyo; }
    public string GetFormato() { return formato; }
    public void SetAutor(string nuevoAutor) { autor = nuevoAutor;}
    public void SetTamanyo(int nuevoTamanyo) { tamanyo = nuevoTamanyo; }
    public void SetFormato(string nuevoFormato) { formato = nuevoFormato; }

    public override string ToString(){
        return "Autor: " + autor + " Tamaño: "+ tamanyo + " Formato: " + 
        formato;
    }
}

class Imagen: Medio
{
    protected int ancho;
    protected int alto;

    public Imagen(string autor, int tamanyo, string formato, int ancho, 
        int alto) : base(autor, tamanyo, formato)
    {
        this.ancho = ancho;
        this.alto = alto;
    }
    public int GetAncho() { return ancho; }
    public int GetAlto() { return alto; }
    public void SetAncho(int ancho) { this.ancho = ancho; }
    public void SetAlto(int alto) { this.alto = alto; }
    
    public override string ToString(){
        return base.ToString() + " Ancho: " + ancho + " Alto: " + alto;
    }
}

class Sonido: Medio
{
    protected bool estereo;
    protected int kbps;
    protected int duracion;

    public Sonido(string autor, int tamanyo, string formato, bool estereo,
        int kbps, int duracion): base(autor, tamanyo, formato)
    {
        this.estereo = estereo;
        this.kbps = kbps;
        this.duracion = duracion;
    }
    public bool GetEstereo() { return estereo; }
    public int GetKbps() { return tamanyo; }
    public int GetDuracion() { return duracion; }
    public void SetEstereo(bool estereo) { this.estereo = estereo; }
    public void SetKbps(int kbps) { this.kbps = kbps; }
    public void SetDuracion(int duracion) { this.duracion = duracion; }

    public override string ToString(){
        return base.ToString() + " Estereo: " + estereo + " Kbps: " + kbps +
        " Duración: " + duracion;
    }
}

class Video: Medio
{
    protected string codec;
    protected int ancho;
    protected int alto;
    protected int duracion;

    public Video(string autor, int tamanyo, string formato, string codec, 
        int ancho, int alto, int duracion): base(autor, tamanyo, formato)

    {
        this.codec = codec;
        this.ancho = ancho;
        this.alto = alto;
        this.duracion = duracion;
    }
    
    public string GetCodec() { return codec; }
    public int GetAncho() { return ancho; }
    public int GetAlto() { return alto; }
    public int GetDuracion() { return duracion; }
    public void SetCodec(string codec) { this.codec = codec; }
    public void SetAncho(int ancho) { this.ancho = ancho; }
    public void SetAlto(int alto) { this.alto = alto; }
    public void SetDuracion(int duracion) { this.duracion = duracion; }

    public override string ToString(){
        return base.ToString() + " Codec: " + codec + " Ancho: " + ancho + 
        " Alto: " + alto + " Duración: " + duracion;
    }
}

class PruebaDeMedios
{
    public static void Main()
    {
        Medio medio1 = new Medio("Iván", 150, "jpg");
        Imagen imagen1 = new Imagen("Iván I", 150, "png", 1500, 600);
        Sonido sonido1 = new Sonido("Iván S", 150, "mp3", false, 192, 750);
        Video video1 = new Video("Iván V", 150, "mp4", "H.264", 1600, 350, 650);
        
        Medio[] medios = new Medio[4];
        medios[0] = new Medio("Iván", 150, "gif");
        medios[1] = new Imagen("Iván I2", 150, "tif", 1500, 600);
        medios[2] = new Sonido("Iván S2", 150, "ogg", false, 192, 750);
        medios[3] = new Video("Iván V2", 150, "m4v", "H.264", 1600, 350, 650);

        Console.WriteLine(imagen1);
        Console.WriteLine(medio1);
        Console.WriteLine(sonido1);
        Console.WriteLine(video1);
        Console.WriteLine();
        
        for(int i = 0; i < 4; i++)
        {
            Console.WriteLine(medios[i].ToString());
        }
    }
}
