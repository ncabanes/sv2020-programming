class MillasAMetros
{
    static void Main()
    {
        int millas, metros;

        Console.WriteLine("Cuantas millas quieres convertir?");
        millas = Convert.ToInt32(Console.ReadLine());

        metros = millas * 1609;

        Console.WriteLine("Metros equivalentes: " + metros);
    }
}
