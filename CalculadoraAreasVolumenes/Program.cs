namespace CalculadoraAreasVolumenes;

class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Calculadora de áreas y volúmenes");
        Console.WriteLine("Selecciona 1 para áreas y 2 para volúmenes");

        int a;
        
        if (int.TryParse(Console.ReadLine(), out a))
        {
            switch (a)
            {
                // Cuadrado y triangulo
                case 1:
                    Console.WriteLine("Obteniendo áreas");
                    Cuadrado.ObtenerArea();
                    Triangulo.ObtenerArea();

                    break;

                // Cubo, pirámide
                case 2:
                    Console.WriteLine("Obteniendo volúmenes");
                    Cubo.ObtenerVolumen();
                    Piramide.ObtenerVolumen();
                    break;
            }
        }
    }
}
