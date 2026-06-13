using System.Runtime.CompilerServices;

namespace SeleccionPersonajes
{
    internal class Program
    {
        static string[] personajes = { "1.-Guerrero", "2.-Mago", "3.-Obrero", "4.-Goblin", "5.-Ladron", "6.-Curandero", "7.-Arquero", "8.-Rey" };
        static int posicionActual = 0;




        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Selecciona un personaje con  \"A\" y \"D\" :  " + PintarPersonajes());

                ConsoleKeyInfo tecla = Console.ReadKey(intercept: true);

                if (tecla.Key == ConsoleKey.A)
                {
                    //el módulo de c#, no se comporta como módulo matematico, regresa el residuo de una resta, por eso se suma la cantidad de personajes
                    posicionActual = (posicionActual - 1 + 8) % 8;

                }
                if (tecla.Key == ConsoleKey.D)
                {
                    posicionActual = (posicionActual + 1) % 8;


                }
               
            }
            
        }


        private static string PintarPersonajes()
        {
            int con = -1;
            string personajeSeleccionado = "";

           foreach(var personaje in personajes)
            {
                con++;
                Console.Write("   ");
                Console.BackgroundColor = ConsoleColor.Red;

                if (con == posicionActual)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.Write(personaje);
                    personajeSeleccionado = personaje;
                    Console.BackgroundColor = ConsoleColor.Red;
                    continue;
                }
                Console.Write(personaje);

                
            }
            Console.BackgroundColor = ConsoleColor.Black;

            Console.WriteLine(" ");
           return personajeSeleccionado;
        }
    }
}
