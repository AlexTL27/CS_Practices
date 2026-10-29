namespace CalculadoraAreasVolumenes;

static class Cuadrado
{
    //Obtener área
    public static void ObtenerArea()
    {
        // lado * lado
        //Pedir lado
        float lado = MetodosAUsar.PedirFlotante("Lado del cuadrado en cm");
        
        Console.WriteLine($"La área del cuadrado es : {lado * lado}cm²");
    }
}

static class Triangulo
{
    //Obtener área
    public static void ObtenerArea()
    {
        // (base * altura) / 2
        float basefigura = MetodosAUsar.PedirFlotante("Báse del triángulo en cm");
        float altura = MetodosAUsar.PedirFlotante("Altura del triángulo en cm");

        Console.WriteLine($"La área del triángulo es : {(basefigura * altura) / 2}cm²");

    }
}


static class Cubo
{
    public static void ObtenerVolumen()
    {
        //  \(V = arista * arista * arista))
        float arista = MetodosAUsar.PedirFlotante("Arista del Cubo");
        Console.WriteLine($"El volúmen del cubo es : {arista * arista * arista}cm³");

    }
}

static class Piramide
{
    public static void ObtenerVolumen()
    {
        //  area de la base, por la altura, entre 3
        float areaBase = MetodosAUsar.PedirFlotante("Área de la base de la pirámide");
        float altura = MetodosAUsar.PedirFlotante("Áltura");

        Console.WriteLine($"El volúmen del cubo es : {(areaBase * altura) / 3}cm³");

    }
}

static class MetodosAUsar
{
    public static float PedirFlotante(string ObtenerQue)
    {
        Console.WriteLine("Obteniendo " + ObtenerQue);
        if (float.TryParse(Console.ReadLine(), out float lado))
        {
            return lado;
        }
        else
        {
            Console.WriteLine("Error");
            return 0;
        }
    }
}