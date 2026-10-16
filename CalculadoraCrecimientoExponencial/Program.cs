namespace CalculadoraCrecimientoExponencial;

class Program
{
    static void Main(string[] args)
    {
        //Si tenemos un logaritmo de base 2, cuantos puntos necesitamos para optener nivel 2,
        //Esto es simplemente hacer potencia
        
        //El logaritmo seria:
        //f(x) = log 2(x), pero ya conocemos la base, y el resultado de la funcion es el nivel a obtener
        // por lo que para obtener x solo elevamos 2 al nivel que queramos, y obtendremos los puntos necesarios
        //2 ^ 2 = 4, nivel 2
        //2 ^ 3 = 8, nivel 3
        //2 ^ 4 = 16, nivel 4
        //2 ^ 5 = 32, nivel 5
        //....
        //Desventajas: Esto crece muy rápido, el doble cada nivel
        //Algo mejor es la fórmula N = 100 * n^p, el 100 se puede modificar, al igual que la potencia
        
        //Nivel 24 antes: 16777216
        //Ahora: 57600
        int nivelJugador = 0;

        while (true)
        {
            nivelJugador++;
            Console.WriteLine($"Tu nivel actual es: {nivelJugador}\nPuntos para el siguiente nivel {PuntosSiguienteNivel(2, nivelJugador)}");
            Console.ReadLine();
            
        }
    }
    
    
    private static double PuntosSiguienteNivel(int potencia, int nivelJugador)
    {
     
        return ( 100 * (Math.Pow(nivelJugador,potencia)));
        
    }

}